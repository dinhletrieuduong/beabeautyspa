
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
using spa.Main;
using spa.Main.PreOrder;
using spa.Navigation;
using Service = spa.Data.Model.Service.Service;

namespace spa.AddService
{
    [Activity(Label = "AddServiceActivity")]
    public class AddServiceActivity : Activity, IAddServiceView
    {
        RecyclerView recyclerView;
        List<Service> services;
        ServiceAdapter adapter;
        AddServicePresenter presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_add_services);

            presenter = new AddServicePresenter(new NavigationService(Application));
            presenter.SetView(this);
            presenter.GetServicesByOutlet();

            var backBtn = FindViewById<ImageView>(Resource.Id.backBtn);
            backBtn.Click += delegate { backButtonClick(); };

            recyclerView = FindViewById<RecyclerView>(Resource.Id.ServicesList);
            services = new List<Service>();

            adapter = new ServiceAdapter(services, presenter);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);

            recyclerView.SetLayoutManager(linearLayoutManager);
            recyclerView.SetAdapter(adapter);
        }

        public void updateListService(List<Data.Model.Service.Service> services)
        {
            adapter = new ServiceAdapter(services, presenter);
            recyclerView.SetAdapter(adapter);
        }

        public void backButtonClick()
        {
            OnBackPressed();
        }

        public bool IsPerformingAction { get; private set; }

        public void OnActionStarted() { IsPerformingAction = true; }

        public void OnActionFinished() { IsPerformingAction = false; }

        public bool IsNavigating { get; private set; }

        public void OnNavigationStarted() { IsNavigating = true; }
    }
}
