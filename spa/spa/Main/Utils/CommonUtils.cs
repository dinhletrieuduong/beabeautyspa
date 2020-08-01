using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using spa.Data.Model.User;
using Xamarin.Auth;

namespace spa.Utils
{
    public class CommonUtils
    {
        public static readonly string URL = "https://beabeautyspa.azurewebsites.net";

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
