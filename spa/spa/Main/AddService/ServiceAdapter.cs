using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Service = spa.Data.Model.Service.Service;
namespace spa.AddService
{
    class ServiceAdapter : RecyclerView.Adapter
    {
        List<Service> services;
        AddServicePresenter presenter;

        public ServiceAdapter(List<Service> listServices, AddServicePresenter presenter)
        {
            services = listServices;
            this.presenter = presenter;
        }

        public override int ItemCount
        {
            get { return services.Count(); }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView mHolder = holder as MyView;
            mHolder.Name.Text = services[position].serviceName;
            mHolder.Duration.Text = services[position].duration.ToString() + " Minutes";
            mHolder.serviceID = services[position].id;
            mHolder.presenter = presenter;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View ServiceView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.custom_services_cart_item, parent, false);
            MyView mholder = new MyView(ServiceView);
            return mholder;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public TextView Name, Duration;
            public ImageView mAdd;
            public int serviceID { get; set; }
            public AddServicePresenter presenter { get; set; }

            public MyView(View itemView) : base(itemView)
            {
                Name = itemView.FindViewById<TextView>(Resource.Id.txtServiceName);
                Duration = itemView.FindViewById<TextView>(Resource.Id.txtServiceDuration);
                mAdd = itemView.FindViewById<ImageView>(Resource.Id.btnAdd);

                mAdd.Click += delegate { AddButtonClick(itemView); };
            }

            public void AddButtonClick(View view)
            {
                presenter.AddPreOrderItem(serviceID);
                Toast.MakeText(view.Context, "Added Service", ToastLength.Short).Show();
            }
        }
    }
}