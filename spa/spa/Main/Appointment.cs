using System;
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

namespace AppointmentHustory
{
    class Appointment
    {
        public string mTotal;
        public string mDate;

        public Appointment(string date, string total)
        {
            mDate = date;
            mTotal = total;
        }
    }
}