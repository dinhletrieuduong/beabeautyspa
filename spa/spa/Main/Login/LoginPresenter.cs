using System;
using spa.Base;
using spa.Navigation;
using spa.Data.Model.User;
using spa.Data;
using spa.Verification;
using spa.SignUp;
using System.Collections.Generic;
using System.Diagnostics;
using spa.Main;
using Android.OS;
using System.Threading.Tasks;

namespace spa.Login
{
    public class LoginPresenter : BasePresenter
    {
        private ILoginView m_view;
        private string m_username;
        private string m_password;
        private string m_email;
        private string m_fbToken;
        private string m_token;
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

        public void UpdateEmail(string email)
        {
            m_email = email;
        }

        public void UpdateFBToken(string fbToken)
        {
            m_fbToken = fbToken;
        }

        public void UpdateToken(string token)
        {
            m_token = token;
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
            if (!m_view.IsNavigating && !m_view.IsPerformingAction)
            {
                User user = new User();
                user.email = m_email;
                user.token = m_token;
                user.fbToken = m_fbToken;
                user.username = m_username;
                user.password = m_password;
                bool isLoginSocial = !string.IsNullOrEmpty(m_email);

                m_view.OnActionStarted();
                Dictionary<int, string> resp = new Dictionary<int, string>();

                Task.Factory.StartNew(() =>
                {
                    resp = dataManager.GetUserRepository().Login(user, isLoginSocial);
                }).ContinueWith(task =>
                {
                    m_view.OnActionFinished();

                    if (resp.ContainsKey(200))
                    {
                        string token, message;
                        resp.TryGetValue(200, out token);
                        dataManager.SetToken(token);

                        m_view.OnNavigationStarted();
                        //navigationService.PushPresenter(new VerificationPresenter(navigationService));
                        navigationService.PushPresenter(new MainPresenter(navigationService));
                    }
                    else
                    {
                        if (resp.ContainsKey(400))
                            m_view.OnLoginFailed(400, "");
                        else
                            m_view.OnLoginFailed(500, "There was a problem logging you in, please try again later.");

                    }
                }, TaskScheduler.FromCurrentSynchronizationContext());

            }
        }

        public void Register()
        {
            if (!m_view.IsNavigating)
            {
                m_view.OnNavigationStarted();
                navigationService.PushPresenter(new SignUpPresenter(navigationService));
            }
        }

        public void UpdateSharePreference(SharedPrefsHelper sharedPrefsHelper)
        {
            dataManager.SetSharedPrefsHelper(sharedPrefsHelper);
            if (!string.IsNullOrEmpty(dataManager.GetToken()))
            {
                m_view.OnNavigationStarted();
                navigationService.PushPresenter(new MainPresenter(navigationService));
            }
        }
    }
}