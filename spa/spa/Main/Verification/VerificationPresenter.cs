using System;
using spa.Navigation;
using spa.Base;
using spa.Main;
using spa.Login;
using spa.Data.Model.User;
using spa.Data;
using System.Collections.Generic;
using spa.ProvideInfor;
using System.Threading.Tasks;

namespace spa.Verification
{
    public class VerificationPresenter : BasePresenter
    {
        private IVerificationView m_view;
        DataManager dataManager;
        private string otp;
        public VerificationPresenter(INavigationService navigationService) :
            base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IVerificationView view)
        {
            m_view = view;
            ValidateInput();
        }

        public void UpdateOTP(string charOtp)
        {
            otp += charOtp;
            ValidateInput();
        }

        public void UpdateOTP()
        {
            //otp.Remove(otp.Length - 1);
            //otp = otp.Substring(0, otp.Length - 2);
            if (!string.IsNullOrEmpty(otp))
                otp = otp.Remove(otp.Length - 1);
            ValidateInput();
        }
        private void ValidateInput()
        {
            m_view.OnInputValidated(HasValidInput());
        }

        private bool HasValidInput()
        {
            return !string.IsNullOrEmpty(otp);
        }

        public void Verification()
        {
            if (!m_view.IsNavigating &&
                !m_view.IsPerformingAction &&
                HasValidInput())
            {
                var userRepo = dataManager.GetUserRepository();
                User user = new User();
                user.verifyCode = otp;
                user.token = dataManager.GetToken();
                Console.WriteLine(user.token);
                m_view.OnActionStarted();

                Dictionary<int, string> resp = new Dictionary<int, string>();
                Task.Factory.StartNew(() =>
                {
                    resp = userRepo.Verify(user);
                }).ContinueWith(task =>
                {
                    if (resp.ContainsKey(200))
                    {
                        string token;
                        resp.TryGetValue(200, out token);
                        dataManager.SetToken(token);
                        m_view.OnNavigationStarted();
                        navigationService.PushPresenter(new ProvideInforPresenter(navigationService));
                    }
                    else
                    {
                        if (resp.ContainsKey(401))
                        {
                            //string error;
                            //resp.TryGetValue(401, out error);
                            m_view.OnVerificationFailed(401, "");
                        }
                        else
                            m_view.OnVerificationFailed(500, "There was a problem verificate your account, please try again later.");
                    }
                    m_view.OnActionFinished();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            }
        }

        public void GoToLogin()
        {
            if (!m_view.IsNavigating)
            {
                m_view.OnNavigationStarted();
                navigationService.PushPresenter(new LoginPresenter(navigationService));
            }
        }
    }
}
