using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using spa.Data.Model.Outlet;
using spa.Data.Model.Therapist;

namespace spa.Main.MakeAppointment
{
    public class CustomSpinnerAdapter : BaseAdapter
    {
        Context context;
        int[] flags;
        List<Therapist> therapists;
        LayoutInflater inflter;

        public CustomSpinnerAdapter(Context applicationContext, List<Therapist> therapists)
        {
            this.context = applicationContext;
            //this.flags = flags;
            this.therapists = therapists;
            inflter = (LayoutInflater.From(applicationContext));
        }

        public override int Count => therapists.Count;

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View view, ViewGroup viewGroup)
        {
            view = inflter.Inflate(Resource.Layout.custom_therapist_item, null);
            TextView names = (TextView)view.FindViewById(Resource.Id.textView);
            names.Text = therapists[position].name;
            return view;
        }
    }
}
