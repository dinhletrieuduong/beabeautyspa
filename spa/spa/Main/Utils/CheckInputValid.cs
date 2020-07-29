using System;
using System.Text.RegularExpressions;

namespace spa.Utils
{
    public class CheckInputValid
    {
        // check gradually from left to right, acording to figma design, the function check from top to bottom.
        // Function will re turn 0 if all were valid, or it will return the position where the error occur
        public static int ManuallySignUpCheckInputValid(string Username, string Pass, string conPass,
            string Fullname, int Gender, string Dob, string Email, string Phone)
        {
            if (isUsernameValid(Username) == false)
                return 1;
            if (isPasswordValid(Pass) == false)
                return 2;
            if (isConPasswordValid(Pass, conPass) == false)
                return 3;
            if (isFullNameValid(Fullname) == false)
                return 4;
            if (Dob.Length == 0)
                return 5;
            if (isGenderValid(Gender) == false)
                return 6;
            if (isEmailValid(Email) == false)
                return 7;
            if (isPhoneValid(Phone) == false)
                return 8;

            return 0;
        }

        // check gradually from left to right, acording to figma design, the function check from top to bottom.
        // Function will re turn 0 if all were valid, or it will return the position where the error occur
        public int SocialSignUpCheckInputValid(string Fullname, int Gender, string Phone)
        {

            if (isFullNameValid(Fullname) == false)
            {
                return 1;
            }
            if (isGenderValid(Gender) == false)
            {
                return 2;
            }
            if (isPhoneValid(Phone) == false)
            {
                return 3;
            }

            return 0;
        }

        // check gradually from left to right, acording to figma design, the function check from top to bottom.
        // Function will re turn 0 if all were valid, or it will return the position where the error occur
        //public int ProvideInformationCheckInputValid(string Profession, string IC, string Weight, string Height)
        //{	

        //	if(isFullNameValid(Profession) == false)
        //	{
        //		return 1;
        //	}
        //	if(isGenderValid(IC) == false)
        //	{
        //		return 2;
        //	}
        //	if(isPhoneValid(Weight) == false)
        //	{
        //		return 3;
        //	}
        //	if(isPhoneValid(Height) == false)
        //	{
        //		return 4;
        //	}


        //	return 0;	
        //}


        public static bool isUsernameValid(string username)
        {
            if (string.IsNullOrEmpty(username) || username.Length < 5)
            {
                return false;
            }
            // check username already used 

            return true;
        }

        public static bool isPasswordValid(string Pass)
        {
            if (string.IsNullOrEmpty(Pass) || Pass.Length < 5 || Pass.Length > 50)
            {
                return false;
            }

            return true;
        }

        public static bool isConPasswordValid(string Pass, string conPass)
        {
            if (string.IsNullOrEmpty(conPass) || Pass != conPass)
            {
                return false;
            }

            return true;
        }

        public static bool isEmailValid(string Email)
        {
            if (string.IsNullOrEmpty(Email))
                return false;
            string EMAIL_PATTERN = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            Regex regex = new Regex(EMAIL_PATTERN);
            Match match = regex.Match(Email);
            return match.Success ? true : false;
        }

        public static bool isPhoneValid(string Phone)
        {
            if (string.IsNullOrEmpty(Phone) || Phone.Length == 10)
            {
                return true;
            }
            int value;
            if (int.TryParse(Phone, out value) == false)
            {
                return false;
            }
            return false;
        }
        public static bool isFullNameValid(string Fullname)
        {
            if (string.IsNullOrEmpty(Fullname) || Fullname.Length < 5)
            {
                return false;
            }
            return true;
        }

        public static bool isGenderValid(int Gender)
        {
            if (Gender == -1)
            {
                return false;
            }
            return true;
        }

        public static bool isProfessionValid(string Profession)
        {
            if (string.IsNullOrEmpty(Profession) || Profession.Length == 0)
            {
                return false;
            }
            return true;
        }

        //public static bool isICValid(string IC)
        //{
        //	if(IC.Lenght == 0)
        //	{
        //		return false;
        //	}

        //    return true;
        //}

        public static bool isICValid(string IC)
        {
            if (string.IsNullOrEmpty(IC) || IC.Length == 0)
            {
                return false;
            }
            int value;
            if (int.TryParse(IC, out value) == false)
            {
                return false;
            }
            return true;
        }

        public static bool isWeightValid(string Weight)
        {
            if (string.IsNullOrEmpty(Weight) || Weight.Length == 0)
            {
                return false;
            }
            int value;
            if (int.TryParse(Weight, out value) == false)
            {
                return false;
            }
            return true;
        }

        public static bool isHeightValid(string Height)
        {
            if (string.IsNullOrEmpty(Height) || Height.Length == 0)
            {
                return false;
            }
            int value;
            if (int.TryParse(Height, out value) == false)
            {
                return false;
            }
            return true;
        }
    }
}
