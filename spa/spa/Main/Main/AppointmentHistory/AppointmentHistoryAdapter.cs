﻿using System;
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
using spa.Data.Model.Appointment;

namespace spa.Main.AppointmentHistory
{
    class AppointmentHistoryAdapter : RecyclerView.Adapter
    {
        List<Appointment> mList;
        Context mContext;
        AppointmentPresenter presenter;

        public AppointmentHistoryAdapter(List<Appointment> list, Context con, AppointmentPresenter presenter)
        {
            mList = list;
            mContext = con;
            this.presenter = presenter;
        }

        public override int ItemCount
        {
            get { return mList.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Myview mHolder = holder as Myview;
            mHolder.date.Text = mList[position].mDate;
            mHolder.total.Text = mList[position].mTotal;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Context context = parent.Context;
            LayoutInflater layoutInflater = LayoutInflater.From(context);

            View AppointmentsView = layoutInflater.Inflate(Resource.Layout.custom_appointment_item, parent, false);
            Myview mHolder = new Myview(AppointmentsView, presenter);
            return mHolder;
        }

        public class Myview : RecyclerView.ViewHolder
        {
            private View itemView;
            public TextView date, total;
            public ImageView detail;
            AppointmentPresenter presenter;

            public Myview(View _itemView, AppointmentPresenter presenter) : base(_itemView)
            {
                date = _itemView.FindViewById<TextView>(Resource.Id.txtDate);
                total = _itemView.FindViewById<TextView>(Resource.Id.txtTotal);
                detail = _itemView.FindViewById<ImageView>(Resource.Id.btnDetail);

                this.presenter = presenter;
                detail.Click += delegate { DetailButtonClick(_itemView); };
            }

            public void DetailButtonClick(View view)
            {
                string test = "Detail button click";
                Toast.MakeText(view.Context, test, ToastLength.Short).Show();
                presenter.GoToAppointmentDetail();
            }
        }
    }
}
