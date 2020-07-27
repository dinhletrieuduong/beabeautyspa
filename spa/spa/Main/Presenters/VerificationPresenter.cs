using System;
using spa.Services;
using spa.Views;

namespace spa.Presenters
{
    public class VerificationPresenter : BasePresenter
    {

        private IVerificationView m_view;
        private string otp;
        public VerificationPresenter(INavigationService navigationService) :
            base(navigationService)
        {
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
                m_view.OnActionStarted();

                bool verificated = false;
                if (otp.Equals("13579"))
                    verificated = true;
                m_view.OnActionFinished();

                if (verificated)
                {
                    m_view.OnNavigationStarted();
                    NavigationService.PushPresenter(new MainPresenter(NavigationService));
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
                NavigationService.PushPresenter(new LoginPresenter(NavigationService));
            }
        }
    }
}
