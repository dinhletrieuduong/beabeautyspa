using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Service = spa.Data.Model.Service.Service;
namespace spa.Main.AppointmentHistory
{
    class appointment_detail_adapter : RecyclerView.Adapter
    {
        List<Service> mServiceList;
        Context context;

        public appointment_detail_adapter(List<Service> list, Context con)
        {
            mServiceList = list;
            context = con;
        }

        public override int ItemCount
        {
            get { return mServiceList.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            appointment_detail_service mHolder = holder as appointment_detail_service;
            mHolder.name.Text = mServiceList[position].serviceName;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Context con = parent.Context;
            LayoutInflater layoutInflater = LayoutInflater.From(con);

            View serviceView = layoutInflater.Inflate(Resource.Layout.service_appointment_detail_item, parent, false);
            appointment_detail_service mHolder = new appointment_detail_service(serviceView);
            return mHolder;
        }
    }

    public class appointment_detail_service : RecyclerView.ViewHolder
    {
        private View itemView;
        public TextView name;
        public ImageView btnDetail;

        public appointment_detail_service(View _item) : base(_item)
        {
            itemView = _item;
            name = itemView.FindViewById<TextView>(Resource.Id.txtServiceName);
            btnDetail = itemView.FindViewById<ImageView>(Resource.Id.btnDetail);

            btnDetail.Click += delegate { DetailButtonClick(_item); };
        }

        public void DetailButtonClick(View view)
        {
            Toast.MakeText(view.Context, "Testing Recycler view", ToastLength.Short).Show();
        }
    }
}