
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using spa.Fragments;
using spa.Navigation;

namespace spa.SignUp
{
    [Activity(Label = "SignupSocialActivity")]
    public class SignupSocialActivity : Activity, ISignUpView
    {
        private SignUpPresenter presenter;
        private EditText edtPhone;
        private TextView edtDOB;
        private EditText edtFullName;
        private RadioButton btnMale, btnFemale;
        private Button btnSignUp;

        private TextView invalidTxtView;

        private bool dialogVisible;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_signup_social);

            edtFullName = FindViewById<EditText>(Resource.Id.edtFullName);
            edtFullName.TextChanged += edtFullName_TextChanged;

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

        public override void OnBackPressed()
        {
            presenter.GoToLogin();
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
            if (statusCode == 400)
            {
                if (errorMessage.Length == 1)
                {
                    if (errorMessage.Equals("1"))
                        invalidTxtView = FindViewById<TextView>(Resource.Id.invalidTxtView1);
                    else if (errorMessage.Equals("2"))
                        invalidTxtView = FindViewById<TextView>(Resource.Id.invalidTxtView2);
                    else if (errorMessage.Equals("3"))
                        invalidTxtView = FindViewById<TextView>(Resource.Id.invalidTxtView3);
                    else
                        invalidTxtView = FindViewById<TextView>(Resource.Id.invalidTxtView4);

                    invalidTxtView.Visibility = ViewStates.Visible;

                }
                else
                {
                    invalidTxtView.Visibility = ViewStates.Visible;

                }
            }
            else
            {
                if (!dialogVisible)
                {
                    dialogVisible = true;

                    AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.SetTitle("Error")
                        .SetMessage(errorMessage)
                        .SetNeutralButton("OK", (s, e) => { dialogVisible = false; })
                        .Show();
                }
            }
        }

        private void btnSignUp_Click()
        {
            if (btnMale.Checked) presenter.UpdateGender(btnMale.Text);
            else if (btnFemale.Checked) presenter.UpdateGender(btnFemale.Text);
            else presenter.UpdateGender("");

            CheckBox acceptTermChckBx = FindViewById<CheckBox>(Resource.Id.isAcceptTerm);
            invalidTxtView = FindViewById<TextView>(Resource.Id.invalidTxtView5);

            if (acceptTermChckBx.Checked)
            {
                invalidTxtView.Visibility = ViewStates.Gone;
                presenter.SignUp();

            }
            else
            {
                invalidTxtView.Visibility = ViewStates.Visible;
            }

        }

        private void edtFullName_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateFullName(e.Text.ToString());
            if (invalidTxtView != null) invalidTxtView.Visibility = ViewStates.Gone;
        }

        private void edtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdatePhone(e.Text.ToString());
            if (invalidTxtView != null) invalidTxtView.Visibility = ViewStates.Gone;
        }

        private void edtDoB_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateDoB(e.Text.ToString());
            if (invalidTxtView != null) invalidTxtView.Visibility = ViewStates.Gone;
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
    }


}
