﻿using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using ServiceCart;

namespace AddService
{

    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView recyclerView;
        List<Cart> ServiceList;
        ServiceAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarServices);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = " ";
            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);
            toolbar.NavigationClick += delegate { backButtonClick(); };

            RecyclerView recyclerView = FindViewById<RecyclerView>(Resource.Id.ServicesList);
            ServiceList = new List<Cart>();
            ServiceList.Add(new Cart("Massage in long time", 30));
            ServiceList.Add(new Cart("Spa Bath", 30));
            ServiceList.Add(new Cart("Loose weight", 30));
            ServiceList.Add(new Cart("Mediation", 30));

            adapter = new ServiceAdapter(ServiceList, this);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);

            recyclerView.SetAdapter(adapter);
            recyclerView.SetLayoutManager(linearLayoutManager);


        }

        public void backButtonClick()
        {
            Toast.MakeText(this, "Back button clicked", ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}