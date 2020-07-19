
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using spa.View;
using spa.Presenter;
using Android.Text;

using Xamarin.Facebook;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook.Login;
using Org.Json;
using Xamarin.Auth;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace spa.Droid
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity, IFacebookCallback, ILoginView, GraphRequest.IGraphJSONObjectCallback
    {
        private LoginPresenter m_presenter;
        private EditText m_edtUsername;
        private EditText m_edtPassword;
        private Button m_btnLogin;
        private TextView m_btnRegister;

        private bool m_dialogVisible;

        private ICallbackManager callbackManager;
        private FBProfileTracker profileTracker;
        private LoginButton loginButton;

        private Button twitterButton, fbButton, linkedinButton;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            //FacebookSdk.ApplicationId = "2626391220909606";
            //FacebookSdk.SdkInitialize(this.ApplicationContext);

            //profileTracker = new FBProfileTracker();
            //profileTracker.mOnProfileChanged += mProfileTracker_mOnProfileChanged;
            //profileTracker.StartTracking();
            SetContentView(Resource.Layout.activity_login);

            initViewAndListener();

            //loginButton = (LoginButton)FindViewById(Resource.Id.fblogin);
            //loginButton.SetReadPermissions(new List<string> { "public_profile", "user_friends", "email" });
            //callbackManager = CallbackManagerFactory.Create();
            //loginButton.RegisterCallback(callbackManager, this);

            var app = MainApplication.GetApplication(this);
            initPresenter(app);

            app.CurrentActivity = this;

        }

        private void initViewAndListener()
        {
            m_edtUsername = FindViewById<EditText>(Resource.Id.edtEmail);
            m_edtUsername.TextChanged += m_edtUsername_TextChanged;

            m_edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            m_edtPassword.TextChanged += m_edtPassword_TextChanged;

            m_btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            m_btnLogin.Touch += m_btnLogin_Touch;

            m_btnRegister = FindViewById<TextView>(Resource.Id.btnRegister);
            m_btnRegister.Touch += m_btnRegister_Touch;

            twitterButton = FindViewById<Button>(Resource.Id.TwitterButton);
            linkedinButton = FindViewById<Button>(Resource.Id.LinkedInButton);
            fbButton = FindViewById<Button>(Resource.Id.FacebookButton);

            twitterButton.Click += delegate { LoginTwitter(); };
            linkedinButton.Click += delegate { LoginLinkedIn(); };
            fbButton.Click += delegate { LoginFacebook(); };
        }

        private void initPresenter(MainApplication app)
        {
            m_presenter = (LoginPresenter)app.Presenter;
            m_presenter.SetView(this);
        }
        private void LoginTwitter()
        {
            var auth = new OAuth1Authenticator(
            consumerKey: "YOUR_KEY",
            consumerSecret: "YOUR_SECRET",
            requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
            authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
            accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
            callbackUrl: new Uri("http://mobile.twitter.com")
            );
            auth.AllowCancel = true;
            auth.Completed += twitter_auth_CompletedAsync;
            StartActivity(auth.GetUI(this));
        }
        private void LoginLinkedIn()
        {
            var auth = new OAuth2Authenticator(
            clientId: "86y5vemgr5cslf",
            clientSecret: "e9N2DPJh6SZ5Sdpk",
            scope: "r_emailaddress",
            authorizeUrl: new Uri("https://www.linkedin.com/oauth/v2/authorization"),
            redirectUrl: new Uri("http://www.devenvexe.com"),
            accessTokenUrl: new Uri("https://www.linkedin.com/oauth/v2/accessToken")
            );

            // If authorization succeeds or is canceled, .Completed will be fired.
            auth.AllowCancel = true;
            auth.Completed += linkedin_auth_CompletedAsync;
            StartActivity(auth.GetUI(this));
        }

        private void LoginFacebook()
        {
            var auth = new OAuth2Authenticator(
                clientId: "2626391220909606",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
                );
            auth.Completed += facebook_auth_CompletedAsync;
            StartActivity(auth.GetUI(this));
        }
        private async void twitter_auth_CompletedAsync(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            if (eventArgs.IsAuthenticated)
            {
                Toast.MakeText(this, "Authenticated!", ToastLength.Long).Show();
                var request = new OAuth1Request("GET",
                               new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"),
                               null,
                               eventArgs.Account);

                var response = await request.GetResponseAsync();

                var json = response.GetResponseText();
            }
        }
        private async void linkedin_auth_CompletedAsync(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            if (eventArgs.IsAuthenticated)
            {
                //string dd = eventArgs.Account.Username;
                //var values = eventArgs.Account.Properties;
                //var access_token = values["access_token"];
                //try
                //{
                //    var request = HttpWebRequest.Create(
                //        string.Format(@"https://api.linkedin.com/v1/people/~:(id,firstName,lastName,headline,picture-url,summary,educations,three-current-positions,honors-awards,site-standard-profile-request,location,api-standard-profile-request,phone-numbers)?oauth2_access_token=" + access_token + "&format=json", ""));
                //    request.ContentType = "application/json";
                //    request.Method = "GET";

                //    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                //    {
                //        Console.WriteLine("Stautus Code is: {0}", response.StatusCode);
                //        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                //        {
                //            var content = reader.ReadToEnd();
                //            if (!string.IsNullOrWhiteSpace(content))
                //            {
                //                Console.WriteLine(content);
                //            }
                //            var result = JsonConvert.DeserializeObject<dynamic>(content);
                //        }
                //    }
                //}
                //catch (System.Exception exx)
                //{
                //    //exx.PrintStackTrace();
                //    Console.WriteLine(exx.ToString());
                //}
                //var request = new OAuth2Request(
                //    "GET",
                //    new Uri("https://api.linkedin.com/v1/people/~:(id,firstName,lastName,headline,email,phone-numbers)?"
                //          + "format=json"
                //          + "&oauth2_access_token="
                //          + eventArgs.Account.Properties["access_token"]),
                //    null,
                //    eventArgs.Account);
                var request = new OAuth2Request(
                    "GET",
                    new Uri("https://api.linkedin.com/v2/me?"
                                    + "oauth2_access_token="
                          + eventArgs.Account.Properties["access_token"]),
                    null,
                    eventArgs.Account);
                //request.
                request.AccessTokenParameterName = "oauth2_access_token";
                var linkedInResponse = await request.GetResponseAsync();
                var json = linkedInResponse.GetResponseText();

                var fbUser = JsonConvert.DeserializeObject(json);
                Console.WriteLine(fbUser.ToString());
            }
        }
        private async void facebook_auth_CompletedAsync(object sender, AuthenticatorCompletedEventArgs eventArgs)
        {
            if (eventArgs.IsAuthenticated)
            {
                Toast.MakeText(this, "Authenticated!", ToastLength.Long).Show();
                var request = new OAuth2Request(
                    "GET",
                    new Uri("https://graph.facebook.com/me?fields=name,email"),
                    null,
                    eventArgs.Account);

                var fbResponse = await request.GetResponseAsync();
                var json = fbResponse.GetResponseText();

                var fbUser = JsonConvert.DeserializeObject(json);
                Console.WriteLine(fbUser.ToString());
                //var name = fbUser["name"];
                //var id = fbUser["id"];
                //var picture = fbUser["picture"]["data"]["url"];
                //var cover = fbUser["cover"]["source"];

            }

        }
        void mProfileTracker_mOnProfileChanged(object sender, OnProfileChangedEventArgs e)
        {
            if (e.mProfile != null)
            {
                try
                {
                    GraphRequest request = GraphRequest.NewMeRequest(AccessToken.CurrentAccessToken, this);
                    Bundle parameters = new Bundle();
                    parameters.PutString("fields", "id,name,email");
                    request.Parameters = parameters;
                    request.ExecuteAsync();
                }
                catch (Java.Lang.Exception ex)
                {
                    ex.PrintStackTrace();
                }
            }
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            callbackManager.OnActivityResult(requestCode, (int)resultCode, data);
            //LinkedInClientManager.OnActivityResult(requestCode, resultCode, data);
        }

        protected override void OnStop()
        {
            base.OnStop();
            // We remove ourself from the navigation stack, so that the back
            // button doesn't bring the user back to the login screen. Where
            // navigation to the login screen is required, an explicit call
            // to push a new LoginPresenter should be made.
            //Finish();
        }
        protected override void OnDestroy()
        {
            profileTracker.StopTracking();
            base.OnDestroy();
        }
        public bool IsPerformingAction { get; private set; }

        public void OnActionStarted()
        {
            IsPerformingAction = true;
        }

        public void OnActionFinished()
        {
            IsPerformingAction = false;
        }

        public bool IsNavigating { get; private set; }

        public void OnNavigationStarted()
        {
            IsNavigating = true;
        }

        public void OnInputValidated(bool isValid)
        {
            m_btnLogin.Enabled = isValid;
        }

        public void OnLoginFailed(string errorMessage)
        {
            if (!m_dialogVisible)
            {
                m_dialogVisible = true;

                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                builder.SetTitle("AliveDrive")
                    .SetMessage(errorMessage)
                    .SetNeutralButton("OK", (s, e) =>
                    {
                        m_dialogVisible = false;
                    })
                    .Show();
            }
        }

        private void m_edtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateUsername(e.Text.ToString());
        }

        private void m_edtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdatePassword(e.Text.ToString());
        }

        private void m_btnLogin_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            m_presenter.Login();
        }

        private void m_btnRegister_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            m_presenter.Register();
        }

        public void OnCancel()
        {
            throw new NotImplementedException();
        }

        public void OnError(FacebookException error)
        {
            throw new NotImplementedException();
        }

        public void OnSuccess(Java.Lang.Object result)
        {
            LoginResult loginResult = result as LoginResult;
            Console.WriteLine(AccessToken.CurrentAccessToken.UserId);
        }


        public void OnCompleted(JSONObject json, GraphResponse response)
        {
            string data = json.ToString();
            Console.WriteLine(data);
        }

    }

    public class FBProfileTracker : ProfileTracker
    {
        public event EventHandler<OnProfileChangedEventArgs> mOnProfileChanged;

        protected override void OnCurrentProfileChanged(Profile oldProfile, Profile newProfile)
        {
            if (mOnProfileChanged != null)
            {
                mOnProfileChanged.Invoke(this, new OnProfileChangedEventArgs(newProfile));
            }
        }
    }

    public class OnProfileChangedEventArgs : EventArgs
    {
        public Profile mProfile;

        public OnProfileChangedEventArgs(Profile profile) { mProfile = profile; }
    }
}