using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Java.Lang;
using Android.Text;

using Org.Json;
using Xamarin.Auth;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using spa.Data.Model.User;
using spa.Data;
using Debug = System.Diagnostics.Debug;
using spa.Utils;
using spa.Navigation;

namespace spa.Login
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
        private TextView invalidTxtView;
        private bool dialogVisible, isSigninSocial = false;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);

            initViewAndListener();

            presenter = new LoginPresenter(new NavigationService(this.Application));
            presenter.SetView(this);
            presenter.UpdateSharePreference(new SharedPrefsHelper(this.ApplicationContext));
        }

        private void initViewAndListener()
        {
            edtUsername = FindViewById<EditText>(Resource.Id.edtEmail);
            edtUsername.TextChanged += edtUsername_TextChanged;

            edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            edtPassword.TextChanged += edtPassword_TextChanged;

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += delegate { btnLogin_Click(); };

            btnRegister = FindViewById<TextView>(Resource.Id.btnRegister);
            btnRegister.Click += delegate { btnRegister_Click(); };

            btnLoginFB = FindViewById<ImageView>(Resource.Id.FacebookButton);
            btnLoginFB.Click += delegate { LoginFacebook(); };

            invalidTxtView = FindViewById<TextView>(Resource.Id.invalidTxtView);
        }

        private void LoginFacebook()
        {
            var auth = CommonUtils.LoginFacebook();
            isSigninSocial = true;

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

                    var fbUser = JsonConvert.DeserializeObject(json);
                    string token = eventArgs.Account.Properties["access_token"];
                    var email = fbUser.ToString().Split(",")[1].Split(":")[1].Trim().Split("\"")[1];
                    presenter.UpdateEmail(email);
                    presenter.UpdateToken(token);
                    presenter.Login();
                }
            };

            auth.Error += (sender, eventArgs) =>
            {
                isSigninSocial = false;
                OAuth2Authenticator auth2 = (OAuth2Authenticator)sender;
                auth2.ShowErrors = false;
                auth2.OnCancelled();
            };

            StartActivity(auth.GetUI(this));
        }

        protected override void OnStop()
        {
            base.OnStop();
            // We remove ourself from the navigation stack, so that the back
            // button doesn't bring the user back to the login screen. Where
            // navigation to the login screen is required, an explicit call
            // to push a new LoginPresenter should be made.
            //if (!isSigninSocial || IsNavigating)
            //{
            Finish();
            //}
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
            //btnLogin.Enabled = isValid;
        }

        public void OnLoginFailed(int statusCode, string errorMessage)
        {
            if (statusCode == 400)
                invalidTxtView.Visibility = ViewStates.Visible;
            else
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

        }

        private void edtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (invalidTxtView.Visibility == ViewStates.Visible)
                invalidTxtView.Visibility = ViewStates.Gone;
            presenter.UpdateUsername(e.Text.ToString());
        }

        private void edtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (invalidTxtView.Visibility == ViewStates.Visible)
                invalidTxtView.Visibility = ViewStates.Gone;
            presenter.UpdatePassword(e.Text.ToString());
        }

        private void btnLogin_Click()
        {
            presenter.Login();
        }

        private void btnRegister_Click()
        {
            presenter.Register();
        }

    }

}