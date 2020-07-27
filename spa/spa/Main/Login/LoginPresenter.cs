﻿using System;
using spa.Base;
using spa.Navigation;
using spa.Data.Model.User;
using spa.Data;
using spa.Verification;
using spa.SignUp;

namespace spa.Login
{
    public class LoginPresenter : BasePresenter
    {
        private ILoginView m_view;
        private string m_username;
        private string m_password;
        private string m_email;
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
            if (!m_view.IsNavigating && !m_view.IsPerformingAction && HasValidInput())
            {
                User user = new User();
                user.email = m_email;
                user.token = m_token;
                user.username = m_username;
                user.password = m_password;

                m_view.OnActionStarted();

                bool isLoginSocial = string.IsNullOrEmpty(m_email);
                int statusCode = dataManager.GetUserRepository().Login(user, isLoginSocial);

                m_view.OnActionFinished();

                if (statusCode == 200)
                {
                    m_view.OnNavigationStarted();
                    NavigationService.PushPresenter(new VerificationPresenter(NavigationService));
                }
                else
                {
                    if (statusCode == 400)
                        m_view.OnLoginFailed(400, "");
                    else
                        m_view.OnLoginFailed(500, "There was a problem logging you in, please try again later.");

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