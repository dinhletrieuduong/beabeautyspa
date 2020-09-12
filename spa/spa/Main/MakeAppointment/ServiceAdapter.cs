using System;
using System.Collections.Generic;
using System.Linq;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Service = spa.Data.Model.Service.Service;
namespace spa.Main.MakeAppointment
{
    class ServiceAdapter : RecyclerView.Adapter
    {
        List<Service> services;
        MakeAppointmentPresenter presenter;

        public ServiceAdapter(List<Service> listServices, MakeAppointmentPresenter presenter)
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
            mHolder.serviceName.Text = services[position].serviceName;
            mHolder.timeTxtView.Text = services[position].duration.ToString() + " Minutes";
            mHolder.serviceID = services[position].id;
            mHolder.presenter = presenter;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View ServiceView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.custom_make_appt_item, parent, false);
            MyView mholder = new MyView(ServiceView);
            return mholder;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            public TextView serviceName, timeTxtView, therapistName, breakTimeTxtView;
            public LinearLayout linearLayout;
            public int serviceID { get; set; }
            public MakeAppointmentPresenter presenter { get; set; }

            public MyView(View itemView) : base(itemView)
            {
                linearLayout = itemView.FindViewById<LinearLayout>(Resource.Id.linearLayout);
                serviceName = itemView.FindViewById<TextView>(Resource.Id.serviceName);
                timeTxtView = itemView.FindViewById<TextView>(Resource.Id.timeTxtView);
                therapistName = itemView.FindViewById<TextView>(Resource.Id.therapistName);
                breakTimeTxtView = itemView.FindViewById<TextView>(Resource.Id.breakTimeTxtView);
                linearLayout.Click += delegate { SelectTherapist(itemView); };
            }

            public void SelectTherapist(View view)
            {
                //presenter.AddPreOrderItem(serviceID);
                Toast.MakeText(view.Context, "Select Therapist", ToastLength.Short).Show();
            }
        }
    }
}