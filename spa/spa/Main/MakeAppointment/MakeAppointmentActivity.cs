
using System;

using Android.App;
using Android.OS;
using Android.Widget;
using spa.Data;
using spa.Fragments;
using spa.Navigation;

namespace spa.Main.MakeAppointment
{
    [Activity(Label = "MakeAppointmentActivity")]
    public class MakeAppointmentActivity : Activity
    {
        TextView locationTxtView;
        TextView dobTxtView;
        TextView startingTimeTxtView;
        LinearLayout selectDateBtn;
        LinearLayout timeSelectButton;
        LinearLayout serviceChangeBtn;
        ImageButton backBtn;
        MakeAppointmentPresenter presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_make_appointment);

            presenter = new MakeAppointmentPresenter(new NavigationService(this.Application));

            backBtn = FindViewById<ImageButton>(Resource.Id.backBtn);
            backBtn.Click += delegate { OnBackPressed(); Finish(); };

            locationTxtView = FindViewById<TextView>(Resource.Id.locationTxtView);
            dobTxtView = FindViewById<TextView>(Resource.Id.dobTxtView);
            selectDateBtn = FindViewById<LinearLayout>(Resource.Id.selectDateBtn);

            startingTimeTxtView = FindViewById<TextView>(Resource.Id.startingTimeTxtView);
            timeSelectButton = FindViewById<LinearLayout>(Resource.Id.selectStartingTimeBtn);
            serviceChangeBtn = FindViewById<LinearLayout>(Resource.Id.serviceChangeBtn);

            locationTxtView.Text = DataManager.GetInstance().GetOutletAddress();
            selectDateBtn.Click += DateSelect_OnClick;
            timeSelectButton.Click += TimeSelectOnClick;

            serviceChangeBtn.Click += delegate { presenter.GoToAddService(); };
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

        [Obsolete]
        void DateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                dobTxtView.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}