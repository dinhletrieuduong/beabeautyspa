using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using spa.Data.Model.Service;

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
            vh.imageBackground.SetBackgroundResource(serviceList[position].image);
            vh.serviceNameTxtView.Text = serviceList[position].serviceName;
            vh.durationTxtView.Text = serviceList[position].duration;
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
    }
}
