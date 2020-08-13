
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
using spa.Navigation;
namespace spa.Main.Home
{
    [Obsolete]
    public class HomeFragment : Fragment, IHomeView
    {
        ViewPager viewPager;
        ImageAdapter imageAdapter;
        RecyclerView recyclerView;
        RecyclerView.Adapter adapter;
        RecyclerView.LayoutManager layoutManager;

        HomePresenter presenter;

        List<spa.Data.Model.Service.Service> services = new List<Data.Model.Service.Service>();

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
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_home, container, false);
            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            imageAdapter = new ImageAdapter(Context);
            viewPager.Adapter = imageAdapter;

            presenter = new HomePresenter(new NavigationService(Activity.Application));
            presenter.SetView(this);
            //services = presenter.GetAllService();
            presenter.GetAllService();
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewService);
            adapter = new ServiceAdapter(services);
            layoutManager = new LinearLayoutManager(Context);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);
            return view;
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

        public void updateListService(List<Data.Model.Service.Service> services)
        {
            adapter = new ServiceAdapter(services);
            recyclerView.SetAdapter(adapter);
        }
    }
}
