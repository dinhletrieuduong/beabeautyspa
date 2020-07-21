
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

using spa.View;
using spa.Presenter;
using static Android.Views.View;
using AlertDialog = Android.App.AlertDialog;
using Android.Text;
using System.Text.RegularExpressions;

namespace spa.Droid
{
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : Activity, ISignUpView
    {
        private SignUpPresenter presenter;
        private EditText edtEmail;
        private EditText edtName;
        private EditText edtAddress;
        private EditText edtPassword;
        private EditText edtConfirmPassword;
        private Button btnSignUp;

        private bool dialogVisible;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_signup);

            edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            edtEmail.TextChanged += edtEmail_TextChanged;

            edtName = FindViewById<EditText>(Resource.Id.edtEmail);
            edtName.TextChanged += edtName_TextChanged;

            edtAddress = FindViewById<EditText>(Resource.Id.edtEmail);
            edtAddress.TextChanged += edtAddress_TextChanged;

            edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            edtPassword.TextChanged += edtPassword_TextChanged;

            edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtConfirmPassword);
            edtConfirmPassword.TextChanged += edtConfirmPassword_TextChanged;

            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignUp.Touch += btnSignUp_Touch;

            var app = MainApplication.GetApplication(this);
            presenter = app.Presenter as SignUpPresenter;
            presenter.SetView(this);

            app.CurrentActivity = this;
        }

        public override void OnBackPressed()
        {
            presenter.GoToLogin();
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
            btnSignUp.Enabled = isValid;
        }

        public void OnSignUpFailed(string errorMessage)
        {
            if (!dialogVisible)
            {
                dialogVisible = true;

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("AliveDrive")
                    .SetMessage(errorMessage)
                    .SetNeutralButton("OK", (s, e) => { dialogVisible = false; })
                    .Show();
            }
        }

        private void edtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateEmail(e.Text.ToString());
        }

        private void edtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateName(e.Text.ToString());
        }

        private void edtAddress_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateAddress(e.Text.ToString());
        }

        private void edtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdatePassword(e.Text.ToString());
        }

        private void edtConfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateConfirmPassword(e.Text.ToString());
        }

        private void btnSignUp_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            presenter.SignUp();
        }

    }
}
