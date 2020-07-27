
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
using spa.Presenters;
using static Android.Views.View;
using AlertDialog = Android.App.AlertDialog;
using Android.Text;
using spa.Utils;
using spa.Fragments;
using spa.Services;

namespace spa.Activities
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
        private TextView edtDOB;
        private RadioButton btnMale, btnFemale;
        private EditText edtFullName;

        private Button btnSignUp;

        private bool m_dialogVisible, isSignUpSocial;

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

            btnMale = FindViewById<RadioButton>(Resource.Id.btnMale);
            btnFemale = FindViewById<RadioButton>(Resource.Id.btnFemale);

            edtDOB = FindViewById<TextView>(Resource.Id.edtDOB);
            edtDOB.Click += DateSelect_OnClick;
            edtDOB.TextChanged += m_edtDoB_TextChanged;

            edtPhone = FindViewById<EditText>(Resource.Id.edtPhone);
            edtPhone.TextChanged += m_edtPhone_TextChanged;

            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignUp.Touch += m_btnSignUp_Touch;

            m_presenter = new SignUpPresenter(new NavigationService(this.Application));
            m_presenter.SetView(this);

        }

        private void LoginFacebook()
        {
            var auth = CommonUtils.LoginFacebook();
            isSignUpSocial = true;
            StartActivity(auth.GetUI(this));
        }

        public override void OnBackPressed()
        {
            m_presenter.GoToLogin();
        }

        protected override void OnStop()
        {
            base.OnStop();
            if (!isSignUpSocial) Finish();
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

        private void m_edtDoB_TextChanged(object sender, TextChangedEventArgs e)
        {
            m_presenter.UpdateDoB(e.Text.ToString());
        }

        [Obsolete]
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                edtDOB.Text = time.ToLongDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void m_btnSignUp_Touch(object sender, Android.Views.View.TouchEventArgs e)
        {
            if (btnMale.Checked) m_presenter.UpdateGender(btnMale.Text);
            else m_presenter.UpdateGender(btnFemale.Text);
            m_presenter.SignUp(false);
        }

    }
}
