﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Carousel;

namespace spa.Fragments
{
    [Obsolete]
    public class HomeFragment : Fragment
    {
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
            SfCarousel carousel = view.FindViewById<SfCarousel>(Resource.Id.carousel);

            List<SfCarouselItem> tempCollection = new List<SfCarouselItem>();

            for (int i = 1; i <= 6; i++)
            {
                SfCarouselItem sfCarouselItem = new SfCarouselItem(view.Context);
                sfCarouselItem.ImageName = "image" + i.ToString();
                tempCollection.Add(sfCarouselItem);
            }

            carousel.SelectedIndex = 2;
            carousel.DataSource = tempCollection;
            //return base.OnCreateView(inflater, container, savedInstanceState);
            return view;
        }
    }
}
