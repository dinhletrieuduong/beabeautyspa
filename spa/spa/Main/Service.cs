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

namespace AppointmentDetail
{
    public class Service
    {
        public string mName { get; set; }
        public int mDuration { get; set; }

        public Service(string mName, int duration)
        {
            this.mName = mName;
            this.mDuration = duration;
        }
    }
}