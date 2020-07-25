using System;
using spa.Views;
using spa.Services;
using spa.Data.Model.User;
using spa.Data;

namespace spa.Presenter
{
    public class LoginPresenter : BasePresenter
    {
        private ILoginView m_view;
        private string m_username;
        private string m_password;
        DataManager dataManager;

        public LoginPresenter(INavigationService navigationService) : base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public LoginPresenter(INavigationService navigationService, DataManager dataManager) : base(navigationService, dataManager)
        {
        }

        public void SetView(ILoginView view)
        {
            m_view = view;
            ValidateInput();
        }

        public void RemoveView()
        {
            m_view = null;
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
                bool loggedIn = dataManager.GetUserRepository().Login(user).Item3;

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