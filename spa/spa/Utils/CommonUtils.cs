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
        public static readonly string URL = "https://beabeauty.azurewebsites.net";

        public static Tuple<OAuth2Authenticator, bool> LoginFacebook()
        {
            var auth = new OAuth2Authenticator(
                clientId: "2626391220909606",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
                );
            auth.Completed += async (object sender, AuthenticatorCompletedEventArgs eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    var request = new OAuth2Request(
                        "GET",
                        new Uri("https://graph.facebook.com/me?fields=name,email"),
                        null,
                        eventArgs.Account);

                    var fbResponse = await request.GetResponseAsync();
                    var json = fbResponse.GetResponseText();

                    var fbUser = JsonConvert.DeserializeObject<User>(json);
                    string token = eventArgs.Account.Properties["access_token"];
                }
            };
            auth.Error += (sender, eventArgs) =>
            {
                OAuth2Authenticator auth2 = (OAuth2Authenticator)sender;
                auth2.ShowErrors = false;
                auth2.OnCancelled();
            };
            return Tuple.Create(auth, true);
        }

    }
}
