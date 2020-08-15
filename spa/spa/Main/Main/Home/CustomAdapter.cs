using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using spa.Data.Model.Outlet;

namespace spa.Main.Main.Home
{
    public class CustomAdapter : BaseAdapter
    {
        Context context;
        int[] flags;
        List<Outlet> outlets;
        LayoutInflater inflter;

        public CustomAdapter(Context applicationContext, List<Outlet> outlets)
        {
            this.context = applicationContext;
            //this.flags = flags;
            this.outlets = outlets;
            inflter = (LayoutInflater.From(applicationContext));
        }

        public override int Count => outlets.Count;

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
            view = inflter.Inflate(Resource.Layout.custom_spinner_item, null);
            TextView names = (TextView)view.FindViewById(Resource.Id.textView);
            names.Text = outlets[position].address;
            return view;
        }
    }
}
