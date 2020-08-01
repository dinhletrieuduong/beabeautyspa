
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

namespace spa.Main.Home
{
    [Obsolete]
    public class HomeFragment : Fragment
    {
        ViewPager viewPager;
        ImageAdapter imageAdapter;
        RecyclerView recyclerView;
        RecyclerView.Adapter adapter;
        RecyclerView.LayoutManager layoutManager;

        List<spa.Data.Model.Service.Service> services;

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
            initData();
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_home, container, false);
            viewPager = view.FindViewById<ViewPager>(Resource.Id.viewPager);
            imageAdapter = new ImageAdapter(this.Context);
            viewPager.Adapter = imageAdapter;

            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.recyclerViewService);
            adapter = new ServiceAdapter(services);
            layoutManager = new LinearLayoutManager(this.Context);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);
            return view;
        }

        private void initData()
        {
            services = new List<Data.Model.Service.Service>();
            services.Add(new spa.Data.Model.Service.Service("abc", "30", Resource.Drawable.body_service));
            services.Add(new spa.Data.Model.Service.Service("def", "40", Resource.Drawable.body_service));
            services.Add(new spa.Data.Model.Service.Service("ghi", "20", Resource.Drawable.body_service));
            services.Add(new spa.Data.Model.Service.Service("qwe", "10", Resource.Drawable.body_service));
            services.Add(new spa.Data.Model.Service.Service("rqwr", "70", Resource.Drawable.body_service));
        }
    }
}
