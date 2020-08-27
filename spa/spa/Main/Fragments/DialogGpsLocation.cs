using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Locations;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace spa.Fragments
{
    public class DialogGpsLocation : DialogFragment
    {
        // TAG can be any string of your choice.
        public static readonly string TAG = "X:" + typeof(DialogGpsLocation).Name.ToUpper();


        public static DialogGpsLocation NewInstance()
        {
            DialogGpsLocation frag = new DialogGpsLocation();
            //frag._dateSelectedHandler = onDateSelected;
            return frag;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            //return base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.custom_dialog_GPSLocation, container, false);
            Button okBtn = view.FindViewById<Button>(Resource.Id.okBtn);
            Button noBtn = view.FindViewById<Button>(Resource.Id.noBtn);
            noBtn.Click += delegate { DismissAllowingStateLoss(); };
            okBtn.Click += delegate { OpenGpsSystem(); };

            return view;
        }

        private void OpenGpsSystem()
        {
            LocationManager LM = (LocationManager)Android.App.Application.Context.GetSystemService(Context.LocationService);

            Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
            intent.AddFlags(ActivityFlags.NewTask);
            intent.AddFlags(ActivityFlags.MultipleTask);
            Android.App.Application.Context.StartActivity(intent);

            //if (LM.IsProviderEnabled(LocationManager.GpsProvider) == false)
            //{
            //}
            //else
            //{
            //    //this is handled in the PCL
            //}
            //Android.App.Application.Context.StartActivity(new Android.Content.Intent(Android.Provider.Settings.ActionLocat‌​ionSourceSettings));
        }
    }

}