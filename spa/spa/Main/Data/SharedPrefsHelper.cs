using System;
using Android.Content;
namespace spa.Data
{
    public class SharedPrefsHelper
    {
        public static string BEABEAUTY_PREFS = "BEABEAUTY_PREFS";

        public static string EMAIL = "EMAIL";
        public static string USERNAME = "USERNAME";
        public static string TOKEN = "TOKEN";
        public static string OUTLET_ADDRESS = "OUTLET_ADDRESS";
        public static string OUTLET_ID = "OUTLET_ID";
        public static string SERVICE_ID = "SERVICE_ID";

        ISharedPreferences mSharedPreferences;

        public SharedPrefsHelper(Context context)
        {
            mSharedPreferences = context.GetSharedPreferences(BEABEAUTY_PREFS, FileCreationMode.Private);
        }

        public void clear()
        {
            mSharedPreferences.Edit().Clear().Apply();
        }

        public void clearToken()
        {
            mSharedPreferences.Edit().Remove(TOKEN).Apply();
        }

        public void putOutletAddress(string outlet)
        {
            mSharedPreferences.Edit().PutString(OUTLET_ADDRESS, outlet).Apply();
        }

        public string getOutletAddress()
        {
            return mSharedPreferences.GetString(OUTLET_ADDRESS, null);
        }

        public void putOutletID(int outletID)
        {
            mSharedPreferences.Edit().PutInt(OUTLET_ID, outletID).Apply();
        }
        public int getOutletID()
        {
            return mSharedPreferences.GetInt(OUTLET_ID, 1);
        }

        public void putServiceID(int id)
        {
            mSharedPreferences.Edit().PutInt(SERVICE_ID, id).Apply();
        }
        public int getServiceID()
        {
            return mSharedPreferences.GetInt(SERVICE_ID, 1);
        }

        public void putEmail(string email)
        {
            mSharedPreferences.Edit().PutString(EMAIL, email).Apply();
        }

        public string getEmail()
        {
            return mSharedPreferences.GetString(EMAIL, null);
        }

        public void putToken(string token)
        {
            mSharedPreferences.Edit().PutString(TOKEN, token).Apply();
        }

        public string getToken()
        {
            return mSharedPreferences.GetString(TOKEN, null);
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
