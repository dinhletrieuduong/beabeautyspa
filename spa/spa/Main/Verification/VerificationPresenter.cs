using System;
using spa.Navigation;
using spa.Base;
using spa.Main;
using spa.Login;
using spa.Data.Model.User;
using spa.Data;
using System.Collections.Generic;
using spa.ProvideInfor;

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
                User user = new User();
                user.verifyCode = otp;

                m_view.OnActionStarted();

                bool verificated = false;
                var userRepo = dataManager.GetUserRepository();
                Dictionary<int, string> resp = userRepo.Verify(user);

                if (otp.Equals("123456"))
                    verificated = true;

                m_view.OnActionFinished();

                if (verificated)
                {
                    m_view.OnNavigationStarted();
                    navigationService.PushPresenter(new ProvideInforPresenter(navigationService));
                }
                else
                {
                    otp = "";
                    m_view.OnVerificationFailed("There was a problem verificate your account, please try again later.");
                }
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
