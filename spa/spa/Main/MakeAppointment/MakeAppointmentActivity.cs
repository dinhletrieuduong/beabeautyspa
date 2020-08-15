
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
using spa.Fragments;

namespace spa.Main.MakeAppointment
{
    [Activity(Label = "MakeAppointmentActivity")]
    public class MakeAppointmentActivity : Activity
    {
        TextView startingTimeTxtView;
        LinearLayout timeSelectButton;
        ImageButton backBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_make_appointment);

            backBtn = FindViewById<ImageButton>(Resource.Id.backBtn);
            startingTimeTxtView = FindViewById<TextView>(Resource.Id.startingTimeTxtView);
            timeSelectButton = FindViewById<LinearLayout>(Resource.Id.selectStartingTimeBtn);

            backBtn.Click += delegate { OnBackPressed(); Finish(); };
            timeSelectButton.Click += TimeSelectOnClick;
        }


        void BackToPreOrder()
        {
        }

        void TimeSelectOnClick(object sender, EventArgs eventArgs)
        {
            TimePickerFragment frag = TimePickerFragment.NewInstance(
                delegate (DateTime time)
                {
                    startingTimeTxtView.Text = time.ToShortTimeString();
                });

            frag.Show(FragmentManager, TimePickerFragment.TAG);
        }
    }
}
