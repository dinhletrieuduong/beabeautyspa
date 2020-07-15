
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

namespace spa.Droid
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity, ILoginView
    {
        private LoginPresenter m_presenter;
        private EditText m_edtUsername;
        private EditText m_edtPassword;
        private Button m_btnLogin;
        private TextView m_btnRegister;

        private bool m_dialogVisible;

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
            m_edtUsername = FindViewById<EditText>(Resource.Id.edtEmail);
            m_edtUsername.TextChanged += m_edtUsername_TextChanged;

            m_edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            m_edtPassword.TextChanged += m_edtPassword_TextChanged;

            m_btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            m_btnLogin.Touch += m_btnLogin_Touch;

            m_btnRegister = FindViewById<TextView>(Resource.Id.btnRegister);
            m_btnRegister.Touch += m_btnRegister_Touch;
        }

        private void initPresenter(MainApplication app)
        {
            m_presenter = (LoginPresenter)app.Presenter;
            m_presenter.SetView(this);
        }

        protected override void OnStop()
        {
            base.OnStop();
            // We remove ourself from the navigation stack, so that the back
            // button doesn't bring the user back to the login screen. Where
            // navigation to the login screen is required, an explicit call
            // to push a new LoginPresenter should be made.
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

    }
}