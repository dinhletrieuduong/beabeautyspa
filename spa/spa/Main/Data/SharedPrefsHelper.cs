using System;
using Android.Content;
namespace spa.Data
{
    public class SharedPrefsHelper
    {
        public static String MY_PREFS = "MY_PREFS";

        public static String EMAIL = "EMAIL";

        ISharedPreferences mSharedPreferences;

        public SharedPrefsHelper(Context context)
        {
            mSharedPreferences = context.GetSharedPreferences(MY_PREFS, FileCreationMode.Private);
        }

        public void clear()
        {
            mSharedPreferences.Edit().Clear().Apply();
        }

        public void putEmail(String email)
        {
            mSharedPreferences.Edit().PutString(EMAIL, email).Apply();
        }

        public String getEmail()
        {
            return mSharedPreferences.GetString(EMAIL, null);
        }

        public bool getLoggedInMode()
        {
            return mSharedPreferences.GetBoolean("IS_LOGGED_IN", false);
        }

        public void setLoggedInMode(bool loggedIn)
        {
            mSharedPreferences.Edit().PutBoolean("IS_LOGGED_IN", loggedIn).Apply();
        }
    }
}
