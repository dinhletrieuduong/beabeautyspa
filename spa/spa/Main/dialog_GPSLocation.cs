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

namespace GPSDialog.Properties
{
    class dialog_GPSLocation : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);

            //var view = inflater.Inflate(Resource.Layout.dialog_GPSLocation, container, false);
            //return view;
        }
    }

}