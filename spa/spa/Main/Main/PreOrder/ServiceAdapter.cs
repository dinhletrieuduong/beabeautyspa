using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Java.Util.Zip;
using spa;
using spa.Data.Model.Service;
using Service = spa.Data.Model.Service.Service;

namespace AddService
{
    class ServiceAdapter : RecyclerView.Adapter
    {
        List<Service> mListService;
        Context context;

        public ServiceAdapter(List<Service> listServices, Context con)
        {
            mListService = listServices;
            context = con;
        }

        public override int ItemCount
        {
            get { return mListService.Count(); }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView mHolder = holder as MyView;
            mHolder.Name.Text = mListService[position].serviceName;
            mHolder.Duration.Text = mListService[position].duration.ToString() + " Minutes";

        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Context context = parent.Context;
            LayoutInflater layoutInflater = LayoutInflater.From(context);

            View ServiceView = layoutInflater.Inflate(Resource.Layout.custom_services_cart_item, parent, false);
            MyView mholder = new MyView(ServiceView);
            return mholder;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            private View itemView;
            public TextView Name, Duration;
            public ImageView mAdd;

            public MyView(View _itemView) : base(_itemView)
            {
                itemView = _itemView;
                Name = _itemView.FindViewById<TextView>(Resource.Id.txtServiceName);
                Duration = _itemView.FindViewById<TextView>(Resource.Id.txtServiceDuration);
                mAdd = _itemView.FindViewById<ImageView>(Resource.Id.btnAdd);

                mAdd.Click += delegate { AddButtonClick(_itemView); };
            }

            public void AddButtonClick(View view)
            {
                Toast.MakeText(view.Context, "Testing Recycler view", ToastLength.Short).Show();
            }
        }
    }
}