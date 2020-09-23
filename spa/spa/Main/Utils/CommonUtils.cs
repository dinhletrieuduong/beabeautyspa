using System;
using Xamarin.Auth;

namespace spa.Utils
{
    public class CommonUtils
    {
        public static readonly Uri URL = new Uri("https://beabeautyspazzz.azurewebsites.net");

        public static OAuth2Authenticator LoginFacebook()
        {
            return new OAuth2Authenticator(
                clientId: "2626391220909606",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
                );
        }

    }
}
