using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using spa.Data.Model.Service;

using Square.Picasso;

namespace spa.Main.Home
{
    public class ServiceAdapter : RecyclerView.Adapter
    {
        List<Service> serviceList;
        HomePresenter presenter;
        public ServiceAdapter(List<Service> serviceList, HomePresenter presenter)
        {
            this.serviceList = serviceList;
            this.presenter = presenter;
        }

        public override int ItemCount => serviceList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ServiceViewHolder vh = holder as ServiceViewHolder;
            if (!string.IsNullOrEmpty(serviceList[position].image_url))
                Picasso.Get().Load(serviceList[position].image_url)
                    //.Placeholder(R    esource.Drawable.body_service)
                    .Error(Resource.Drawable.body_service).Into(vh.imageBackground);

            vh.serviceNameTxtView.Text = serviceList[position].serviceName;
            vh.durationTxtView.Text = serviceList[position].duration.ToString();
            vh.serviceID = serviceList[position].id;
            vh.presenter = this.presenter;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.custom_service_item, parent, false);
            // Create a ViewHolder to hold view references inside the CardView:
            ServiceViewHolder vh = new ServiceViewHolder(itemView);
            return vh;
        }

        class ServiceViewHolder : RecyclerView.ViewHolder //, ITarget
        {
            //public LinearLayout imageBackground { get; private set; }
            public ImageView imageBackground { get; private set; }
            public TextView serviceNameTxtView { get; private set; }
            public TextView durationTxtView { get; private set; }
            public HomePresenter presenter { get; set; }
            public int serviceID { get; set; }

            public ServiceViewHolder(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                //imageBackground = itemView.FindViewById<LinearLayout>(Resource.Id.imageBackground);
                imageBackground = itemView.FindViewById<ImageView>(Resource.Id.imageBackground);
                serviceNameTxtView = itemView.FindViewById<TextView>(Resource.Id.serviceNameTxtView);
                durationTxtView = itemView.FindViewById<TextView>(Resource.Id.durationTxtView);
                itemView.Click += delegate { DetailButtonClick(itemView); };
            }

            public void DetailButtonClick(View view)
            {
                presenter.GoToServiceDetail();
            }
            //public void OnBitmapFailed(Java.Lang.Exception errorDrawable, Drawable p1)
            //{
            //}

            //public void OnBitmapLoaded(Bitmap bitmap, Picasso.LoadedFrom loadedFrom)
            //{
            //    imageBackground.SetBackgroundDrawable(new BitmapDrawable(bitmap));
            //}

            //public void OnPrepareLoad(Drawable placeHolderDrawable)
            //{
            //}
        }
    }

}
