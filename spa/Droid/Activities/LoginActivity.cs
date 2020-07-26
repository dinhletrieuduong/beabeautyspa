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
using spa.Views;
using spa.Presenter;
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
            //DataManager dataManager = app.GetDataManager();
            presenter = (LoginPresenter)app.Presenter;
            presenter.SetView(this);
            //presenter.SetDataManager(DataManager.GetInstance());
            app.CurrentActivity = this;
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
            btnRegister.Touch += btnRegister_Touch;

            btnLoginFB = FindViewById<ImageView>(Resource.Id.FacebookButton);
            btnLoginFB.Click += delegate { LoginFacebook(); };
        }

        private void LoginFacebook()
        {
            var tuple = CommonUtils.LoginFacebook();
            var auth = tuple.Item1;
            isSigninSocial = tuple.Item2;
            StartActivity(auth.GetUI(this));
        }

        protected override void OnStop()
        {
            base.OnStop();
            // We remove ourself from the navigation stack, so that the back
            // button doesn't bring the user back to the login screen. Where
            // navigation to the login screen is required, an explicit call
            // to push a new LoginPresenter should be made.
            if (!isSigninSocial)
            {
                Finish();
            }
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            presenter.RemoveView();
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

        private void btnLogin_Click()
        {
            presenter.Login();
        }

        private void btnRegister_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            presenter.Register();
        }

    }

}