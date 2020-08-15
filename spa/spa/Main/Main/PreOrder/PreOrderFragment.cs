
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
using Service = spa.Data.Model.Service.Service;


namespace spa.Main.PreOrder
{
    [Obsolete]
    public class PreOrderFragment : Fragment, IPersCartView
    {
        RecyclerView RecyclerView;
        List<Service> services;
        PersonalCartAdapter adapter;
        PersonalCartPresenter presenter;

        Button bookBtn;
        ImageView addBtn;

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

            addBtn = view.FindViewById<ImageView>(Resource.Id.addBtn);
            bookBtn = view.FindViewById<Button>(Resource.Id.bookBtn);

            addBtn.Click += delegate { AddService(); };
            bookBtn.Click += delegate { BookNow(); };

            RecyclerView = view.FindViewById<RecyclerView>(Resource.Id.cartsList);
            services = new List<Service>();
            services.Add(new Service("Foot Massage", 60));
            services.Add(new Service("Facial Massage", 60));
            services.Add(new Service("Body Massage", 60));
            services.Add(new Service("Massage in long time", 30));
            services.Add(new Service("Spa Bath", 30));
            services.Add(new Service("Loose weight", 30));
            services.Add(new Service("Mediation", 30));

            adapter = new PersonalCartAdapter(services, this.Context);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this.Context);

            RecyclerView.SetAdapter(adapter);
            RecyclerView.SetLayoutManager(linearLayoutManager);
            return view;
        }

        void BookNow()
        {
            presenter.GoToMakeAppointment();
        }

        void AddService()
        {
            presenter.GoToAddService();
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
