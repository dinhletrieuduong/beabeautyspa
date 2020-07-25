using System;
using System.Text.RegularExpressions;

namespace spa.Utils
{
    public class CheckInputValid
    {
        public CheckInputValid()
        {
        }

        public static bool isUsernameValid(string username)
        {

            return true;
        }

        public static bool isPasswordValid(string pass)
        {

            return true;
        }

        public static bool isEmailValid(string email)
        {
            string EMAIL_PATTERN = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            Regex regex = new Regex(EMAIL_PATTERN);
            Match match = regex.Match(email);
            return match.Success ? true : false;
        }

        public static bool isPhoneValid(string phone)
        {

            return true;
        }
    }
}
