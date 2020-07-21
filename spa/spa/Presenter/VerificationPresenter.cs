using System;
using spa.Services;
using spa.View;

namespace spa.Presenter
{
    public class VerificationPresenter : BasePresenter
    {

        private IVerificationView m_view;

        public VerificationPresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IVerificationView view)
        {
            m_view = view;
            ValidateInput();
        }

        public void UpdateEmail(string email)
        {
            //m_email = email;
            ValidateInput();
        }

        public void UpdateName(string name)
        {
            //m_name = name;
            ValidateInput();
        }


        private void ValidateInput()
        {
            m_view.OnInputValidated(HasValidInput());
        }

        private bool HasValidInput()
        {
            // TODO: Perform real validation.
            //return !string.IsNullOrEmpty(m_email) &&
            //    !string.IsNullOrEmpty(m_name) &&
            //    !string.IsNullOrEmpty(m_address) &&
            //    !string.IsNullOrEmpty(m_password) &&
            //    !string.IsNullOrEmpty(m_confirmPassword) &&
            //    m_password == m_confirmPassword;
            return true;
        }

        public void Verification()
        {
            if (!m_view.IsNavigating &&
                !m_view.IsPerformingAction &&
                HasValidInput())
            {
                m_view.OnActionStarted();

                // TODO: Add logic for sign-up.
                bool verificated = true;

                m_view.OnActionFinished();

                if (verificated)
                {
                    m_view.OnNavigationStarted();
                    NavigationService.PushPresenter(new MainPresenter(NavigationService));
                }
                else
                {
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
