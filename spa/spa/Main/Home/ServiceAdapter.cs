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
        public List<Service> serviceList;

        public ServiceAdapter(List<Service> serviceList)
        {
            this.serviceList = serviceList;
        }
        public override int ItemCount => serviceList.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ServiceViewHolder vh = holder as ServiceViewHolder;
            Picasso.Get()
                .Load(serviceList[position].image_url)
                //.Placeholder(Resource.Drawable.body_service)
                .Error(Resource.Drawable.body_service)
                .Into(vh);
            vh.serviceNameTxtView.Text = serviceList[position].serviceName;
            vh.durationTxtView.Text = serviceList[position].duration.ToString();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.custom_service_item, parent, false);
            // Create a ViewHolder to hold view references inside the CardView:
            ServiceViewHolder vh = new ServiceViewHolder(itemView);
            return vh;
        }

        class ServiceViewHolder : RecyclerView.ViewHolder, ITarget
        {
            public LinearLayout imageBackground { get; private set; }
            public TextView serviceNameTxtView { get; private set; }
            public TextView durationTxtView { get; private set; }

            public ServiceViewHolder(View itemView) : base(itemView)
            {
                // Locate and cache view references:
                imageBackground = itemView.FindViewById<LinearLayout>(Resource.Id.imageBackground);
                serviceNameTxtView = itemView.FindViewById<TextView>(Resource.Id.serviceNameTxtView);
                durationTxtView = itemView.FindViewById<TextView>(Resource.Id.durationTxtView);
            }

            public void OnBitmapFailed(Java.Lang.Exception errorDrawable, Drawable p1)
            {
            }

            public void OnBitmapLoaded(Bitmap bitmap, Picasso.LoadedFrom loadedFrom)
            {
                imageBackground.SetBackgroundDrawable(new BitmapDrawable(bitmap));
            }

            public void OnPrepareLoad(Drawable placeHolderDrawable)
            {
            }
        }
    }

}
