
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using spa.Navigation;
using spa.PersonalCart;

namespace spa.Main.PreOrder
{
    [Obsolete]
    public class PreOrderFragment : Fragment, IPersCartView
    {
        RecyclerView RecyclerView;
        List<Data.Model.Service.Service> services;
        PersonalCartAdapter adapter;
        PersonalCartPresenter presenter;

        public static PreOrderFragment NewInstance(String param1, String param2)
        {
            PreOrderFragment fragment = new PreOrderFragment();
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
            View view = inflater.Inflate(Resource.Layout.fragment_personal_cart, container, false);
            presenter = new PersonalCartPresenter(new NavigationService(this.Activity.Application));
            presenter.SetView(this);
            RecyclerView = view.FindViewById<RecyclerView>(Resource.Id.cartsList);
            services = new List<Data.Model.Service.Service>();
            services.Add(new Data.Model.Service.Service("Foot Massage", 60));
            services.Add(new Data.Model.Service.Service("Facial Massage", 60));
            services.Add(new Data.Model.Service.Service("Body Massage", 60));

            adapter = new PersonalCartAdapter(services, this.Context);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this.Context);

            RecyclerView.SetAdapter(adapter);
            RecyclerView.SetLayoutManager(linearLayoutManager);
            return view;
        }

        public void BackButtonClick()
        {
            Android.Widget.Toast.MakeText(this.Context, "Back button clicked", Android.Widget.ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
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
