using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Android.App;
using Android.Content;
using Android.Media;
using Android.Net.Wifi.Aware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace PersonalCart
{
    class CartsList : BaseAdapter<string>
    {
        public List<string> Carts;
        private Context mContext;

        public CartsList(Context con, List<string> carts)
        {
            mContext = con;
            Carts = carts;
        }
        public override string this[int position]
        {
            get { return Carts[position]; }
        }

        public override int Count
        {
            get { return Carts.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContext).Inflate(Resource.Layout.ListView_row, null, false);
            }
            TextView name = row.FindViewById<TextView>(Resource.Id.txtName);
            name.Text = Carts[position];
            return row;
        }
    }
}