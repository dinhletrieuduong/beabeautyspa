﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Sql;
using spa.Data.Model.Appointment.Source.Remote;

namespace spa.Data.Model.Appointment
{
    public class Appointment
    {
        public string mDate;
        public string mStartTime;
        public string mTotal;
        public List<Data.Model.PreOrder.PreOrder> details;
        public Appointment(string date, string time, List<Data.Model.PreOrder.PreOrder> preOrders)
        {
            mDate = date;
            mStartTime = time;
            details = preOrders;
        }
        public Appointment(string date, string total)
        {
            mDate = date;
            mTotal = total;
        }
        public Appointment(AppointmentResponse response)
        {
            //mTotal = response.serviceID;
        }
    }
}