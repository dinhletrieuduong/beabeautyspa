using System;
using spa.Data;
using spa.Data.Model.User;
using spa.Services;
using spa.Views;

namespace spa.Presenters
{
    public class SignUpPresenter : BasePresenter
    {
        private ISignUpView m_view;
        DataManager dataManager;

        private string m_username;
        private string m_password;
        private string m_fullName;
        private string m_email;
        private string m_phone;
        private string m_dob;
        private string m_gender;
        private string m_confirmPassword;

        public SignUpPresenter(INavigationService navigationService) : base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(ISignUpView view)
        {
            m_view = view;
            ValidateInput();
        }

        public void UpdateEmail(string email)
        {
            m_email = email;
            ValidateInput();
        }

        public void UpdateUserName(string username)
        {
            m_username = username;
            ValidateInput();
        }

        public void UpdatePassword(string password)
        {
            m_password = password;
            ValidateInput();
        }

        public void UpdateConfirmPassword(string confirmPassword)
        {
            m_confirmPassword = confirmPassword;
            ValidateInput();
        }

        public void UpdateFullName(string fullname)
        {
            m_fullName = fullname;
            ValidateInput();
        }

        public void UpdateGender(string gender)
        {
            m_gender = gender;
            ValidateInput();
        }

        public void UpdateDoB(string dob)
        {
            m_dob = dob;
            ValidateInput();
        }

        public void UpdatePhone(string phone)
        {
            m_phone = phone;
            ValidateInput();
        }

        private void ValidateInput()
        {
            m_view.OnInputValidated(HasValidInput());
        }

        private bool HasValidInput()
        {
            return !string.IsNullOrEmpty(m_email) &&
                !string.IsNullOrEmpty(m_username) &&
                !string.IsNullOrEmpty(m_fullName) &&
                !string.IsNullOrEmpty(m_password) &&
                !string.IsNullOrEmpty(m_confirmPassword) &&
                m_password == m_confirmPassword;
        }

        public void SignUp(bool isSignUpBySocial)
        {
            if (!m_view.IsNavigating &&
                !m_view.IsPerformingAction &&
                HasValidInput())
            {
                User user = new User(m_username, m_password, m_email, m_dob, m_phone, m_fullName, m_gender);

                m_view.OnActionStarted();

                int statusCode = dataManager.GetUserRepository().Register(user, isSignUpBySocial);

                m_view.OnActionFinished();

                if (statusCode == 200)
                {
                    m_view.OnNavigationStarted();
                    NavigationService.PushPresenter(new MainPresenter(NavigationService));
                }
                else
                {
                    m_view.OnSignUpFailed("There was a problem creating your account, please try again later.");
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