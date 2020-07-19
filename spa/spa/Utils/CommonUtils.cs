using System;
namespace spa.Utils
{
    public class CommonUtils
    {

        public static bool isEmailValid(string email)
        {
            //Pattern pattern;
            //PatternMatcher patternMatcher;

            string EMAIL_PATTERN =
                    "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@"
                            + "[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
            //pattern = PatternMatcher(EMAIL_PATTERN);
            //matcher = pattern.matcher(email);
            //if (Regex.Match(email, EMAIL_PATTERN)..Equals());
            return false;
        }
    }
}
