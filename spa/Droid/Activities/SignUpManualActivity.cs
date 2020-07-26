
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
        private EditText edtUsername;
        private EditText edtPassword;
        private EditText edtConfirmPassword;

        private EditText edtEmail;
        private EditText edtPhone;
        private DatePicker edtDOB;
        private RadioGroup rdgGender;
        private EditText edtFullName;

        private Button btnSignUp;

        private bool m_dialogVisible;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_signup_manual);

            edtUsername = FindViewById<EditText>(Resource.Id.edtUsername);
            edtUsername.TextChanged += m_edtUserName_TextChanged;

            edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            edtPassword.TextChanged += m_edtPassword_TextChanged;

            edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtConfirmPassword);
            edtConfirmPassword.TextChanged += m_edtConfirmPassword_TextChanged;

            edtFullName = FindViewById<EditText>(Resource.Id.edtFullName);
            edtFullName.TextChanged += m_edtFullName_TextChanged;

            edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            edtEmail.TextChanged += m_edtEmail_TextChanged;

            rdgGender = FindViewById<RadioGroup>(Resource.Id.rdgGender);
            rdgGender.CheckedChange += m_edtGender_CheckedChanged;

            edtDOB = FindViewById<DatePicker>(Resource.Id.edtDOB);
            edtDOB.DateChanged += m_edtDoB_DateChanged;
            edtPhone = FindViewById<EditText>(Resource.Id.edtPhone);
            edtPhone.TextChanged += m_edtPhone_TextChanged;

            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignUp.Touch += m_btnSignUp_Touch;

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
            //btnSignUp.Enabled = isValid;
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

        private void m_edtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateUserName(e.Text.ToString());
        }

        private void m_edtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdatePassword(e.Text.ToString());
        }

        private void m_edtConfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateConfirmPassword(e.Text.ToString());
        }

        private void m_edtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateFullName(e.Text.ToString());
        }

        private void m_edtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdatePhone(e.Text.ToString());
        }

        private void m_edtDoB_DateChanged(object sender, DatePicker.DateChangedEventArgs e)
        {
            m_presenter.UpdateDoB(e.DayOfMonth + "/" + e.MonthOfYear + "/" + e.Year);
        }

        private void m_edtGender_CheckedChanged(object sender, RadioGroup.CheckedChangeEventArgs e)
        {
            //rdgGender.get
            RadioButton gender = FindViewById<RadioButton>(e.CheckedId);
            m_presenter.UpdateGender(gender.Text.ToString());
        }

        private void m_btnSignUp_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            m_presenter.SignUp();
        }

    }
}
