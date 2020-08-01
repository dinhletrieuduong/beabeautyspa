using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace spa.Main.Home
{

    public class ServiceViewHolder : RecyclerView.ViewHolder
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

    }
}
