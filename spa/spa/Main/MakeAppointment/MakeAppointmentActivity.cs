
using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using Java.Util;
using spa.Data;
using spa.Data.Model.Appointment;
using spa.Data.Model.Therapist;
using spa.Fragments;
using spa.Navigation;

using Service = spa.Data.Model.Service.Service;

namespace spa.Main.MakeAppointment
{
    [Activity(Label = "MakeAppointmentActivity")]
    public class MakeAppointmentActivity : Activity, IMakeAppointmentView
    {
        TextView locationTxtView;
        TextView dateTxtView;
        TextView startingTimeTxtView;
        LinearLayout selectDateBtn;
        LinearLayout timeSelectButton;
        LinearLayout serviceChangeBtn;
        ImageButton backBtn;
        Button createBtn;
        MakeAppointmentPresenter presenter;

        RecyclerView recyclerView;
        List<Data.Model.PreOrder.PreOrder> preOrders;
        List<Therapist> therapists = new List<Therapist>();
        ServiceAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_make_appointment);

            presenter = new MakeAppointmentPresenter(new NavigationService(this.Application));
            presenter.SetView(this);
            presenter.GetPreOrderList();

            recyclerView = FindViewById<RecyclerView>(Resource.Id.servicesList);
            preOrders = new List<Data.Model.PreOrder.PreOrder>() { new Data.Model.PreOrder.PreOrder("123", "11"), new Data.Model.PreOrder.PreOrder("456", "11") };
            adapter = new ServiceAdapter(preOrders, presenter, therapists);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);

            recyclerView.SetLayoutManager(linearLayoutManager);
            recyclerView.SetAdapter(adapter);

            backBtn = FindViewById<ImageButton>(Resource.Id.backBtn);
            backBtn.Click += delegate { OnBackPressed(); Finish(); };

            locationTxtView = FindViewById<TextView>(Resource.Id.locationTxtView);
            dateTxtView = FindViewById<TextView>(Resource.Id.dateTxtView);
            selectDateBtn = FindViewById<LinearLayout>(Resource.Id.selectDateBtn);

            startingTimeTxtView = FindViewById<TextView>(Resource.Id.startingTimeTxtView);
            timeSelectButton = FindViewById<LinearLayout>(Resource.Id.selectStartingTimeBtn);
            serviceChangeBtn = FindViewById<LinearLayout>(Resource.Id.serviceChangeBtn);
            createBtn = FindViewById<Button>(Resource.Id.createBtn);

            locationTxtView.Text = DataManager.GetInstance().GetOutletAddress();
            selectDateBtn.Click += DateSelect_OnClick;
            timeSelectButton.Click += TimeSelectOnClick;

            serviceChangeBtn.Click += delegate { presenter.GoToAddService(); };
            createBtn.Click += delegate { CreateAppointment(); };
        }
        void CreateAppointment()
        {
            var appt = new Appointment(DataManager.GetInstance().GetOutletID(), startingTimeTxtView.Text, preOrders);
            //dateTxtView.Text + startingTimeTxtView.Text;
            Toast.MakeText(ApplicationContext, dateTxtView.Text + startingTimeTxtView.Text, ToastLength.Short).Show();
            presenter.MakeAppointment(appt);

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
                dateTxtView.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
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

        public void updateListPreOrder(List<Data.Model.PreOrder.PreOrder> preOrders)
        {
            //adapter = new ServiceAdapter(preOrders, presenter, therapists);
            //recyclerView.SetAdapter(adapter);
        }

        public void updateListTherapist(List<Therapist> therapists)
        {
            this.therapists = therapists;
        }
    }
}