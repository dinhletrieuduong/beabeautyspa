
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

using spa.Views;
using spa.Presenter;
using static Android.Views.View;
using AlertDialog = Android.App.AlertDialog;
using Android.Text;

namespace spa.Droid
{
    [Activity(Label = "SignUpManualActivity")]
    public class SignUpManualActivity : Activity, ISignUpView
    {
        private SignUpPresenter m_presenter;
        private EditText m_edtEmail;
        private EditText m_edtName;
        private EditText m_edtAddress;
        private EditText m_edtPassword;
        private EditText m_edtConfirmPassword;
        private Button m_btnSignUp;

        private bool m_dialogVisible;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_signup_manual);

            m_edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            m_edtEmail.TextChanged += m_edtEmail_TextChanged;

            m_edtName = FindViewById<EditText>(Resource.Id.edtEmail);
            m_edtName.TextChanged += m_edtName_TextChanged;

            m_edtAddress = FindViewById<EditText>(Resource.Id.edtEmail);
            m_edtAddress.TextChanged += m_edtAddress_TextChanged;

            m_edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            m_edtPassword.TextChanged += m_edtPassword_TextChanged;

            m_edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtConfirmPassword);
            m_edtConfirmPassword.TextChanged += m_edtConfirmPassword_TextChanged;

            m_btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            m_btnSignUp.Touch += m_btnSignUp_Touch;

            var app = MainApplication.GetApplication(this);
            m_presenter = app.Presenter as SignUpPresenter;
            m_presenter.SetView(this);

            app.CurrentActivity = this;
        }

        public override void OnBackPressed()
        {
            m_presenter.GoToLogin();
        }

        protected override void OnStop()
        {
            base.OnStop();

            // We remove ourself from the navigation stack, so that the back
            // button doesn't bring the user back to the sign-up screen.
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
            m_btnSignUp.Enabled = isValid;
        }

        public void OnSignUpFailed(string errorMessage)
        {
            if (!m_dialogVisible)
            {
                m_dialogVisible = true;

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("AliveDrive")
                    .SetMessage(errorMessage)
                    .SetNeutralButton("OK", (s, e) => { m_dialogVisible = false; })
                    .Show();
            }
        }

        private void m_edtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateEmail(e.Text.ToString());
        }

        private void m_edtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateName(e.Text.ToString());
        }

        private void m_edtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateAddress(e.Text.ToString());
        }

        private void m_edtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdatePassword(e.Text.ToString());
        }

        private void m_edtConfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateConfirmPassword(e.Text.ToString());
        }

        private void m_btnSignUp_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            m_presenter.SignUp();
        }

    }
}
