using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;
using spa.Login;
using spa.Main;
using spa.MakeAppointment;
using spa.Verification;

namespace spa.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/SplashTheme", MainLauncher = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            if (IsTaskRoot)
                Log.Debug("Tag Debug", "Is  task root");
            //var newIntent = new Intent(this, typeof(MainActivity));
            var newIntent = new Intent(this, typeof(LoginActivity));
            //var newIntent = new Intent(this, typeof(VerificationActivity));

            //newIntent.AddFlags(ActivityFlags.ClearTop);
            //newIntent.AddFlags(ActivityFlags.SingleTop);

            StartActivity(newIntent);
            Finish();
        }
    }
}
