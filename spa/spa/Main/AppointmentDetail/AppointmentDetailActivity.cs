
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

namespace spa.Main.AppointmentDetail
{
    [Activity(Label = "AppointmentDetailActivity")]
    public class AppointmentDetailActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_appointment_detail);
            // Create your application here

            ImageView backBtn = FindViewById<ImageView>(Resource.Id.backBtn);
            backBtn.Click += delegate { OnBackPressed(); };
        }
    }
}
