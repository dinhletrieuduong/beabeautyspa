
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

using static Android.Views.View;
using AlertDialog = Android.App.AlertDialog;
using Android.Text;
using spa.Utils;
using spa.Fragments;
using spa.Navigation;

namespace spa.SignUp
{
    [Activity(Label = "SignUpManualActivity")]
    public class SignUpManualActivity : Activity, ISignUpView
    {
        private SignUpPresenter presenter;
        private EditText edtUsername;
        private EditText edtPassword;
        private EditText edtConfirmPassword;

        private EditText edtEmail;
        private EditText edtPhone;
        private TextView edtDOB;
        private RadioButton btnMale, btnFemale;
        private EditText edtFullName;

        private Button btnSignUp;

        private bool dialogVisible, isSignUpSocial;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_signup_manual);

            edtUsername = FindViewById<EditText>(Resource.Id.edtUsername);
            edtUsername.TextChanged += edtUserName_TextChanged;

            edtPassword = FindViewById<EditText>(Resource.Id.edtPassword);
            edtPassword.TextChanged += edtPassword_TextChanged;

            edtConfirmPassword = FindViewById<EditText>(Resource.Id.edtConfirmPassword);
            edtConfirmPassword.TextChanged += edtConfirmPassword_TextChanged;

            edtFullName = FindViewById<EditText>(Resource.Id.edtFullName);
            edtFullName.TextChanged += edtFullName_TextChanged;

            edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            edtEmail.TextChanged += edtEmail_TextChanged;

            btnMale = FindViewById<RadioButton>(Resource.Id.btnMale);
            btnFemale = FindViewById<RadioButton>(Resource.Id.btnFemale);

            edtDOB = FindViewById<TextView>(Resource.Id.edtDOB);
            edtDOB.Click += DateSelect_OnClick;
            edtDOB.TextChanged += edtDoB_TextChanged;

            edtPhone = FindViewById<EditText>(Resource.Id.edtPhone);
            edtPhone.TextChanged += edtPhone_TextChanged;

            btnSignUp = FindViewById<Button>(Resource.Id.btnSignUp);
            btnSignUp.Click += delegate { btnSignUp_Click(); };

            presenter = new SignUpPresenter(new NavigationService(this.Application));
            presenter.SetView(this);

        }

        private void LoginFacebook()
        {
            var auth = CommonUtils.LoginFacebook();
            isSignUpSocial = true;
            StartActivity(auth.GetUI(this));
        }

        public override void OnBackPressed()
        {
            presenter.GoToLogin();
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

        public void OnSignUpFailed(int statusCode, string errorMessage)
        {
            //if (statusCode == 404)
            //invalidTxtView.Visibility = ViewStates.Visible;
            //else
            //{
            if (!dialogVisible)
            {
                dialogVisible = true;

                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("Error")
                    .SetMessage(errorMessage)
                    .SetNeutralButton("OK", (s, e) => { dialogVisible = false; })
                    .Show();
            }
            //}
        }

        private void edtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateEmail(e.Text.ToString());
        }

        private void edtUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateUserName(e.Text.ToString());
        }

        private void edtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdatePassword(e.Text.ToString());
        }

        private void edtConfirmPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateConfirmPassword(e.Text.ToString());
        }

        private void edtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateFullName(e.Text.ToString());
        }

        private void edtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdatePhone(e.Text.ToString());
        }

        private void edtDoB_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateDoB(e.Text.ToString());
        }

        [Obsolete]
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                edtDOB.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void btnSignUp_Click()
        {
            if (btnMale.Checked) presenter.UpdateGender(btnMale.Text);
            else if (btnFemale.Checked) presenter.UpdateGender(btnFemale.Text);
            else presenter.UpdateGender("");
            presenter.SignUp();
        }

    }
}
