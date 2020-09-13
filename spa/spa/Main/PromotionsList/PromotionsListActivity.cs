
using System;

using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using spa.Fragments;
using spa.Navigation;
using spa.Data.Model;
using System.Collections.Generic;
using spa.Data.Promotion;

namespace spa.Main.PromotionsList
{
    
    public class PromotionsListActivity : Activity
    {
        public RecyclerView recyclerView;
        List<Promotion> appointmentsList;
        PromotionsListAdapter adapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_promos_list);
            // Create your application here

            ImageView backBtn = FindViewById<ImageView>(Resource.Id.backBtn);
            backBtn.Click += delegate { OnBackPressed(); };


        }
    }
}