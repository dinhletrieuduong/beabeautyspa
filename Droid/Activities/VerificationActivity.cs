
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using spa.View;
using spa.Presenter;

namespace spa.Droid
{
    [Activity(Label = "VerificationActivity")]
    public class VerificationActivity : Activity, IVerificationView
    {

        private VerificationPresenter presenter;
        private ImageView backBtn;
        private Button continueBtn;
        private TextView resendBtn;
        private bool dialogVisible;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_verification);

            initView();

            var app = MainApplication.GetApplication(this);
            presenter = (VerificationPresenter)app.Presenter;
            presenter.SetView(this);

            app.CurrentActivity = this;
        }

        private void initView()
        {
            backBtn = (ImageView)FindViewById(Resource.Id.backBtn);
            //resendBtn = (TextView)FindViewById(Resource.Id.resendBtn);
            //continueBtn = (Button)FindViewById(Resource.Id.continueBtn);
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
            continueBtn.Enabled = isValid;
        }

        public void OnVerificationFailed(string errorMessage)
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
    }
}
