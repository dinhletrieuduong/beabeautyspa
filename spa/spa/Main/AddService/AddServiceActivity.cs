
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using spa.Main.PreOrder;
using Service = spa.Data.Model.Service.Service;

namespace spa.Main.AddService
{
    [Activity(Label = "AddServiceActivity")]
    public class AddServiceActivity : Activity
    {
        RecyclerView recyclerView;
        List<Service> ServiceList;
        ServiceAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_services);

            var backBtn = FindViewById<ImageView>(Resource.Id.backBtn);
            backBtn.Click += delegate { backButtonClick(); };

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.ServicesList);
            ServiceList = new List<Service>();
            ServiceList.Add(new Service("Massage in long time", 30));
            ServiceList.Add(new Service("Spa Bath", 30));
            ServiceList.Add(new Service("Loose weight", 30));
            ServiceList.Add(new Service("Mediation", 30));

            adapter = new ServiceAdapter(ServiceList, this);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);

            recyclerView.SetAdapter(adapter);
            recyclerView.SetLayoutManager(linearLayoutManager);

        }

        public void backButtonClick()
        {
            OnBackPressed();
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
    }
}
