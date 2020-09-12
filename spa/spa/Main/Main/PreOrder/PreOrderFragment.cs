
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
using spa.Data;
using spa.Navigation;
using Service = spa.Data.Model.Service.Service;

namespace spa.Main.PreOrder
{
    [Obsolete]
    public class PreOrderFragment : Fragment, IPersonalCartView
    {
        RecyclerView recyclerView;
        List<spa.Data.Model.PreOrder.PreOrder> preOrders;
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
        public override void OnResume()
        {
            base.OnResume();

            presenter.GetPreOrderList();
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
            //presenter.GetPreOrderList();


            addBtn = view.FindViewById<ImageView>(Resource.Id.addBtn);
            bookBtn = view.FindViewById<Button>(Resource.Id.bookBtn);

            addBtn.Click += delegate { AddService(); };
            bookBtn.Click += delegate { BookNow(); };

            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.cartsList);
            preOrders = new List<spa.Data.Model.PreOrder.PreOrder>();
            //services.Add(new Service("Foot Massage", 60));
            //services.Add(new Service("Facial Massage", 60));
            //services.Add(new Service("Body Massage", 60));
            //services.Add(new Service("Massage in long time", 30));
            //services.Add(new Service("Spa Bath", 30));
            //services.Add(new Service("Loose weight", 30));
            //services.Add(new Service("Mediation", 30));

            adapter = new PersonalCartAdapter(preOrders, presenter);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(Context);

            recyclerView.SetAdapter(adapter);
            recyclerView.SetLayoutManager(linearLayoutManager);

            return view;
        }


        public void updateListService(List<spa.Data.Model.PreOrder.PreOrder> preOrders)
        {
            this.preOrders = preOrders;
            adapter = new PersonalCartAdapter(preOrders, presenter);
            recyclerView.SetAdapter(adapter);
        }

        public void updateListService(int serviceID)
        {
            for (int i = 0; i < preOrders.Count; i++)
            {
                if (preOrders[i].serviceID == serviceID)
                    preOrders.Remove(preOrders[i]);
            }
            adapter = new PersonalCartAdapter(preOrders, presenter);
            recyclerView.SetAdapter(adapter);
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

        public void OnActionStarted() { IsPerformingAction = true; }

        public void OnActionFinished() { IsPerformingAction = false; }

        public bool IsNavigating { get; private set; }

        public void OnNavigationStarted() { IsNavigating = true; }

    }
}
