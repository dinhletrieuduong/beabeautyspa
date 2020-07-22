using System;
using spa.Data.Model;
using spa.Views;
using spa.Services;

namespace spa.Presenter
{
    public class LoginPresenter : BasePresenter
    {

        private ILoginView m_view;
        private string m_username;
        private string m_password;

        public LoginPresenter(INavigationService navigationService) : base(navigationService)
        {
        }

        public void SetView(ILoginView view)
        {
            m_view = view;
            ValidateInput();
        }

        public void UpdateUsername(string username)
        {
            m_username = username;
            ValidateInput();
        }

        public void UpdatePassword(string password)
        {
            m_password = password;
            ValidateInput();
        }

        private void ValidateInput()
        {
            m_view.OnInputValidated(HasValidInput());
        }

        private bool HasValidInput()
        {
            return !string.IsNullOrEmpty(m_username) && !string.IsNullOrEmpty(m_password);
        }

        public void Login()
        {
            if (!m_view.IsNavigating && !m_view.IsPerformingAction && HasValidInput())
            {
                m_view.OnActionStarted();

                User user = new User(m_username, m_password);
                bool loggedIn = false;

                if (user.checkPassword())
                {
                    loggedIn = true;
                }

                m_view.OnActionFinished();

                if (loggedIn)
                {
                    m_view.OnNavigationStarted();
                    NavigationService.PushPresenter(new VerificationPresenter(NavigationService));
                }
                else
                {
                    m_view.OnLoginFailed("There was a problem logging you in, please try again later.");
                }
            }
        }

        public void Register()
        {
            if (!m_view.IsNavigating)
            {
                m_view.OnNavigationStarted();
                NavigationService.PushPresenter(new SignUpPresenter(NavigationService));
            }
        }

    }
}