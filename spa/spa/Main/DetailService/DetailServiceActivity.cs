
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using spa.Data;
using spa.Navigation;
using Square.Picasso;

namespace spa.Main.DetailService
{
    [Activity(Label = "DetailServiceActivity")]
    public class DetailServiceActivity : Activity, IDetailServiceView
    {
        DetailServicePresenter presenter;
        ImageView backBtn;
        TextView txtNameService, txtPriceService, txtDurationService, txtDescriptionService, txtAddressAd;
        ImageView imgAdvertise;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            presenter = new DetailServicePresenter(new NavigationService(Application));
            presenter.SetView(this);
            presenter.GetServiceDetail();
        }


        public void backButtonClick()
        {
            OnBackPressed();
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

        public void updateServiceDetail(Data.Model.Service.Service service)
        {
            SetContentView(Resource.Layout.activity_detail_service);

            backBtn = FindViewById<ImageView>(Resource.Id.backBtn);
            backBtn.Click += delegate { OnBackPressed(); };

            txtNameService = FindViewById<TextView>(Resource.Id.txtNameService);
            txtPriceService = FindViewById<TextView>(Resource.Id.txtPriceService);
            txtDurationService = FindViewById<TextView>(Resource.Id.txtDurationService);
            txtDescriptionService = FindViewById<TextView>(Resource.Id.txtDescriptionService);
            txtAddressAd = FindViewById<TextView>(Resource.Id.txtAddressAd);
            imgAdvertise = FindViewById<ImageView>(Resource.Id.imgAdvertise);

            txtNameService.Text = service.serviceName;
            txtPriceService.Text = service.cost.ToString();
            txtDurationService.Text = "Duration: " + service.duration + " minutes";
            txtDescriptionService.Text = service.description;
            txtAddressAd.Text = DataManager.GetInstance().GetOutletAddress();

            if (!string.IsNullOrEmpty(service.image_url))
                Picasso.Get()
                    .Load(service.image_url)
                    //.Placeholder(R    esource.Drawable.body_service)
                    .Error(Resource.Drawable.body_service)
                    .Into(imgAdvertise);
        }
    }
}
