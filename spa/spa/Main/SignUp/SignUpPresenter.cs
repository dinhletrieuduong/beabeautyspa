using System;
using spa.Data;
using spa.Data.Model.User;
using spa.Navigation;
using spa.Base;
using spa.Login;
using spa.Main;
using System.Collections.Generic;
using spa.Utils;
using spa.ProvideInfor;
using spa.Verification;

namespace spa.SignUp
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
        private int m_gender;
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
            if (gender.Equals("Male"))
                m_gender = 1;
            else if (gender.Equals("Female"))
                m_gender = 0;
            else
                m_gender = -1;
            ValidateInput();
        }

        public void UpdateDoB(string dob)
        {
            var dobArray = dob.Split("/");
            if (dobArray[0].Length == 1)
                dobArray[0] = "0" + dobArray[0];
            if (dobArray[1].Length == 1)
                dobArray[1] = "0" + dobArray[1];
            m_dob = dobArray[2] + "-" + dobArray[0] + "-" + dobArray[1];
            ValidateInput();
        }

        public void UpdatePhone(string phone)
        {
            m_phone = phone;
            ValidateInput();
        }

        private void ValidateInput()
        {
            //Check input valid on each edit text
            //m_view.OnInputValidated(HasValidInput());
        }

        private bool HasValidInput()
        {
            return CheckInputValid.isEmailValid(m_email) &&
                CheckInputValid.isUsernameValid(m_username) &&
                CheckInputValid.isFullNameValid(m_fullName) &&
                CheckInputValid.isPasswordValid(m_password) &&
                CheckInputValid.isConPasswordValid(m_password, m_confirmPassword);
        }

        public void SignUp()
        {
            int isValidRegister = CheckInputValid.ManuallySignUpCheckInputValid(
                    m_username, m_password, m_confirmPassword, m_fullName, m_gender, m_dob, m_email, m_phone);

            if (isValidRegister != 0)
            {
                m_view.OnSignUpFailed(400, isValidRegister.ToString());
                return;
            }

            if (!m_view.IsNavigating && !m_view.IsPerformingAction && HasValidInput())
            {
                User user = new User(m_username, m_password, m_email, m_dob, m_phone, m_fullName, m_gender);
                bool isSignUpBySocial = string.IsNullOrEmpty(m_email);

                m_view.OnActionStarted();
                var userRepository = dataManager.GetUserRepository();

                Dictionary<int, string> resp = userRepository.Register(user, isSignUpBySocial);

                m_view.OnActionFinished();

                if (resp.ContainsKey(200))
                {
                    m_view.OnNavigationStarted();
                    navigationService.PushPresenter(new VerificationPresenter(navigationService));
                }
                else
                {
                    if (resp.ContainsKey(400))
                        m_view.OnSignUpFailed(400, "Username or Email is existed");
                    else
                        m_view.OnSignUpFailed(500, "There was a problem creating your account, please try again later.");
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