using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using spa.Data.Model.Therapist;
using Service = spa.Data.Model.Service.Service;
namespace spa.Main.MakeAppointment
{
    class ServiceAdapter : RecyclerView.Adapter
    {
        //List<Service> services;
        List<Data.Model.PreOrder.PreOrder> preOrders;
        List<Therapist> therapists;
        MakeAppointmentPresenter presenter;

        public ServiceAdapter(List<Data.Model.PreOrder.PreOrder> preOrders, MakeAppointmentPresenter presenter, List<Therapist> therapists)
        {
            this.preOrders = preOrders;
            this.presenter = presenter;
            this.therapists = therapists;
        }

        public override int ItemCount
        {
            get { return preOrders.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView mHolder = holder as MyView;
            mHolder.preOrder = preOrders[position];
            mHolder.serviceName.Text = preOrders[position].serviceName;
            mHolder.timeTxtView.Text = preOrders[position].duration.ToString() + " Minutes";
            //mHolder.serviceID = preOrders[position].serviceID;
            mHolder.presenter = presenter;
            mHolder.therapists = therapists;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View ServiceView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.custom_make_appt_item, parent, false);
            MyView mholder = new MyView(ServiceView);
            return mholder;
        }

        public class MyView : RecyclerView.ViewHolder, Spinner.IOnItemSelectedListener
        {
            public TextView serviceName, timeTxtView, therapistName, breakTimeTxtView;
            public LinearLayout linearLayout;
            public MakeAppointmentPresenter presenter { get; set; }
            Spinner spinner;

            //public int serviceID { get; set; }
            public Data.Model.PreOrder.PreOrder preOrder { get; set; }
            public List<Therapist> therapists { get; set; }
            public List<string> strings;

            public MyView(View itemView) : base(itemView)
            {
                ItemView = itemView;

                linearLayout = itemView.FindViewById<LinearLayout>(Resource.Id.linearLayout);
                serviceName = itemView.FindViewById<TextView>(Resource.Id.serviceName);
                timeTxtView = itemView.FindViewById<TextView>(Resource.Id.timeTxtView);
                therapistName = itemView.FindViewById<TextView>(Resource.Id.therapistName);
                breakTimeTxtView = itemView.FindViewById<TextView>(Resource.Id.breakTimeTxtView);
                linearLayout.Click += delegate { SelectTherapist(itemView); };
            }

            public void SelectTherapist(View view)
            {
                LayoutInflater layoutInflater = LayoutInflater.From(ItemView.Context);
                View customView = layoutInflater.Inflate(Resource.Layout.custom_therapist_choose_dialog, null);
                Dialog dialog = new Dialog(ItemView.Context);
                dialog.SetContentView(customView);
                dialog.FindViewById<Button>(Resource.Id.closeBtn).Click += delegate { dialog.Cancel(); };

                spinner = dialog.FindViewById<Spinner>(Resource.Id.spinnerView);
                therapists.Clear();
                therapists.Add(new Therapist(1, "Therapist 1", "1"));
                therapists.Add(new Therapist(2, "Therapist 2", "1"));
                therapists.Add(new Therapist(3, "Therapist 3", "1"));
                therapists.Add(new Therapist(4, "Therapist 4", "1"));
                CustomSpinnerAdapter customAdapter = new CustomSpinnerAdapter(dialog.Context, therapists);
                spinner.Adapter = customAdapter;
                spinner.OnItemSelectedListener = this;
                dialog.Show();
            }

            public void OnItemSelected(AdapterView arg0, View arg1, int arg2, long arg3)
            {
                preOrder.therapistID = therapists[arg2].id;
                therapistName.Text = therapists[arg2].name;
            }

            public void OnNothingSelected(AdapterView arg0)
            {
                preOrder.therapistID = therapists[0].id;
                therapistName.Text = therapists[0].name;
            }
        }
    }
}