using System;
using System.Text.RegularExpressions;

namespace spa.Utils
{
    public class CheckInputValid
    {
    	// check gradually from left to right, acording to figma design, the function check from top to bottom.
    	// Function will re turn 0 if all were valid, or it will return the position where the error occur
        public int ManuallySignUpCheckInputValid(string Username, string Pass, string conPass, 
        	string Fullname, RadioGroup Gender, string Email, string Phone)
        {	
        	if(isUsernameValid(Username) == false)
        	{
        		return 1;
        	}
        	if(isPasswordValid(Pass) == false)
        	{
        		return 2;
        	}
        	if(isConPasswordValid(Pass, conPass) == false)
        	{
        		return 3;
        	}
        	if(isFullmeValid(Fullname) == false)
        	{
        		return 4;
        	}
        	if(isGenderValid(Gender) == false)
        	{
        		return 5;
        	}
        	if(isEmailValid(Email) == false)
        	{
        		return 6;
        	}
        	if(isPhoneValid(Phone) == false)
        	{
        		return 7;
        	}

        	return 0;	
        }

        // check gradually from left to right, acording to figma design, the function check from top to bottom.
    	// Function will re turn 0 if all were valid, or it will return the position where the error occur
        public int SocialSignUpCheckInputValid(string Fullname, RadioGroup Gender, string Phone)
        {	
        	
        	if(isFullmeValid(Fullname) == false)
        	{
        		return 1;
        	}
        	if(isGenderValid(Gender) == false)
        	{
        		return 2;
        	}
        	if(isPhoneValid(Phone) == false)
        	{
        		return 3;
        	}

        	return 0;	
        }

        // check gradually from left to right, acording to figma design, the function check from top to bottom.
    	// Function will re turn 0 if all were valid, or it will return the position where the error occur
        public int ProvideInformationCheckInputValid(string Profession, string IC, string Weight, string Height)
        {	
        	
        	if(isFullmeValid(Profession) == false)
        	{
        		return 1;
        	}
        	if(isGenderValid(IC) == false)
        	{
        		return 2;
        	}
        	if(isPhoneValid(Weight) == false)
        	{
        		return 3;
        	}
        	if(isPhoneValid(Height) == false)
        	{
        		return 4;
        	}


        	return 0;	
        }


        public static bool isUsernameValid(string username)
        {
        	if(username.Lenght < 5)
        	{
        		return false
        	}
        	// check username already used 

            return true;
        }

        public static bool isPasswordValid(string Pass)
        {
        	if(Pass.Lenght < 5 || Pass.Lenght > 50)
        	{
        		return false;
        	}

            return true;
        }

        public static bool isConPasswordValid(string Pass, string conPass)
        {
        	if(Pass != conPass)
        	{
        		return false;
        	}

            return true;
        }

        public static bool isEmailValid(string Email)
        {
            string EMAIL_PATTERN = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@" + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            Regex regex = new Regex(EMAIL_PATTERN);
            Match match = regex.Match(Email);
            return match.Success ? true : false;
        }

        public static bool isPhoneValid(string Phone)
        {
        	if(Phone.Lenght == 10)
        	{
        		return true;
        	}
        	int value;
        	if(int.TryParse(Phone, out value) == false)
        	{
        		return false;
        	}

            return false;
        }

        public static bool isFullnameValid(string Fullname)
        {
        	if(Fullname.Lenght < 5)
        	{
        		return false;
        	}

            return true;
        }

        public static bool isCheckbBoxTermConditionsValid(CheckBox agree)
        {
        	if(agree.Checked == false)
        	{
        		return false;
        	}

            return true;
        }

        public static bool isGenderValid(RadioGroup Gender)
        {
        	bool re = false;
        	for (int i = 0 ; i < Gender.ChildCount, ++i)
        	{
        		RadioButton child = Gender.GetChildAt(i);
        		if(child.Checked == true)
        		{
        			re = true;
        		}
        	}

        	return re;
        }

        public static bool isProfessionValid(string Profession)
        {
        	if(Profession.Lenght == 0)
        	{
        		return false;
        	}

            return true;
        }

        public static bool isICValid(string IC)
        {
        	if(IC.Lenght == 0)
        	{
        		return false;
        	}

            return true;
        }

        public static bool isICValid(string IC)
        {
        	if(IC.Lenght == 0)
        	{
        		return false;
        	}
        	int value;
        	if(int.TryParse(IC, out value) == false)
        	{
        		return false;
        	}

            return true;
        }

        public static bool isWeightValid(string Weight)
        {
        	if(Weight.Lenght == 0)
        	{
        		return false;
        	}
        	int value;
        	if(int.TryParse(Weight, out value) == false)
        	{
        		return false;
        	}

            return true;
        }

        public static bool isWeightValid(string Height)
        {
        	if(Height.Lenght == 0)
        	{
        		return false;
        	}
        	int value;
        	if(int.TryParse(Height, out value) == false)
        	{
        		return false;
        	}

            return true;
        }
    }
}
