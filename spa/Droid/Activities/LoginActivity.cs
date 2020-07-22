
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
using spa.Views;
using spa.Presenter;
using Android.Text;

using Org.Json;
using Xamarin.Auth;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using spa.Data.Model;

namespace spa.Droid
{
    [Activity(Label = "LoginActivity", WindowSoftInputMode = SoftInput.StateHidden)]
    public class LoginActivity : Activity, ILoginView
    {
        private LoginPresenter presenter;
        private EditText edtUsername;
        private EditText edtPassword;
        private Button btnLogin;
        private ImageView btnLoginFB;
        private TextView btnRegister;
        private bool dialogVisible, isSigninSocial = false;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            initViewAndListener();

            var app = MainApplication.GetApplication(this);
            initPresenter(app);
            app.CurrentActivity = this;
        }

        private void initViewAndListener()
        {
            edtUsername = FindViewById<EditText>(Resource.Id.edtEmail);
            edtUsername.TextChanged += edtUsername_TextChanged;

            edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            edtPassword.TextChanged += edtPassword_TextChanged;

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Touch += btnLogin_Touch;

            btnRegister = FindViewById<TextView>(Resource.Id.btnRegister);
            btnRegister.Touch += btnRegister_Touch;

            btnLoginFB = FindViewById<ImageView>(Resource.Id.FacebookButton);
            btnLoginFB.Click += delegate { LoginFacebook(); };
        }

        private void initPresenter(MainApplication app)
        {
            presenter = (LoginPresenter)app.Presenter;
            presenter.SetView(this);
        }

        private void LoginFacebook()
        {
            var auth = new OAuth2Authenticator(
                clientId: "2626391220909606",
                scope: "",
                authorizeUrl: new Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new Uri("https://www.facebook.com/connect/login_success.html")
                );
            isSigninSocial = true;
            auth.Completed += facebook_Auth_CompletedAsync;
            auth.Error += (sender, eventArgs) =>
            {
                OAuth2Authenticator auth2 = (OAuth2Authenticator)sender;
                auth2.ShowErrors = false;
                auth2.OnCancelled();
            };
            StartActivity(auth.GetUI(this));
        }
        private async void facebook_Auth_CompletedAsync(object sender, AuthenticatorCompletedEventArgs eventArgs)
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

                var fbUser = JsonConvert.DeserializeObject<User>(json);
                //Console.WriteLine(fbUser.ToString());
                Console.WriteLine(fbUser.email.ToString());
            }
        }


        protected override void OnStop()
        {
            base.OnStop();
            // We remove ourself from the navigation stack, so that the back
            // button doesn't bring the user back to the login screen. Where
            // navigation to the login screen is required, an explicit call
            // to push a new LoginPresenter should be made.
            if (!isSigninSocial)
                Finish();
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
            btnLogin.Enabled = isValid;
        }

        public void OnLoginFailed(string errorMessage)
        {
            if (!dialogVisible)
            {
                dialogVisible = true;

                Android.App.AlertDialog.Builder builder = new Android.App.AlertDialog.Builder(this);
                builder.SetTitle("Error")
                    .SetMessage(errorMessage)
                    .SetNeutralButton("OK", (s, e) =>
                    {
                        dialogVisible = false;
                    })
                    .Show();
            }
        }

        private void edtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateUsername(e.Text.ToString());
        }

        private void edtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdatePassword(e.Text.ToString());
        }

        private void btnLogin_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            presenter.Login();
        }

        private void btnRegister_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            presenter.Register();
        }

        //public void OnCancel()
        //{
        //    throw new NotImplementedException();
        //}

    }

}