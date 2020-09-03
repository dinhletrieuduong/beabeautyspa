using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using spa.Data.Model.Outlet;
using spa.Main.Main.Home;
using spa.Navigation;
using spa.Fragments;
using Android.Locations;
using spa.Data;

namespace spa.Main.Home
{
    [Obsolete]
    public class HomeFragment : Fragment, IHomeView, Spinner.IOnItemSelectedListener
    {
        ViewPager viewPager;
        ImageAdapter imageAdapter;
        RecyclerView recyclerView;
        RecyclerView.Adapter adapter;
        RecyclerView.LayoutManager layoutManager;

        Spinner spinnerLocation;
        HomePresenter presenter;

        DataManager dataManager;

        List<spa.Data.Model.Service.Service> services = new List<Data.Model.Service.Service>();
        List<Outlet> outlets = new List<Outlet>();

        public static HomeFragment NewInstance(String param1, String param2)
        {
            HomeFragment fragment = new HomeFragment();
            Bundle args = new Bundle();
            //        args.putString(ARG_PARAM1, param1);
            fragment.Arguments = args;
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            dataManager = DataManager.GetInstance();
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_home, container, false);
            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            imageAdapter = new ImageAdapter(Context);
            viewPager.Adapter = imageAdapter;

            presenter = new HomePresenter(new NavigationService(Activity.Application));
            presenter.SetView(this);
            presenter.GetAllOutles();

            spinnerLocation = view.FindViewById<Spinner>(Resource.Id.spinnerLocation);
            spinnerLocation.OnItemSelectedListener = this;

            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewService);
            adapter = new ServiceAdapter(services, presenter);
            layoutManager = new LinearLayoutManager(Context);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);

            OpenGpsSettings();
            return view;
        }

        private void OpenGpsSettings()
        {
            LocationManager LM = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);
            if (LM.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                DialogGpsLocation frag = DialogGpsLocation.NewInstance();
                frag.Show(FragmentManager, DialogGpsLocation.TAG);
            }
        }

        public bool IsPerformingAction { get; private set; }

        public void OnActionStarted() { IsPerformingAction = true; }

        public void OnActionFinished() { IsPerformingAction = false; }

        public bool IsNavigating { get; private set; }

        public void OnNavigationStarted() { IsNavigating = true; }

        public void updateListService(List<Data.Model.Service.Service> services)
        {
            adapter = new ServiceAdapter(services, presenter);
            recyclerView.SetAdapter(adapter);
        }

        public void updateListOutlet(List<Outlet> outlets)
        {
            this.outlets = outlets;
            CustomSpinnerAdapter customAdapter = new CustomSpinnerAdapter(Context, outlets);
            spinnerLocation.Adapter = customAdapter;
        }
        public void OnItemSelected(AdapterView arg0, View arg1, int arg2, long arg3)
        {
            dataManager.SetOutletAddress(outlets[arg2].address);
            dataManager.SetOutletID(outlets[arg2].id);

            presenter.GetServiceByOutlet(outlets[arg2].id);
        }

        public void OnNothingSelected(AdapterView arg0)
        {
            presenter.GetServiceByOutlet(outlets[0].id);
        }
    }
}
