using System;
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

namespace PersonalCart
{
    class PersonalCartAdapter : RecyclerView.Adapter
    {
        public List<Cart> Carts;
        private Context Context;

        public PersonalCartAdapter(List<Cart> carts, Context con)
        {
            Carts = carts;
            Context = con;
        }
        public override int ItemCount
        {
            get { return Carts.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView mHolder = holder as MyView;
            mHolder.Name.Text = Carts[position].mName;
            mHolder.Duration.Text = Carts[position].mDuration.ToString() + " minutes";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Context context = parent.Context;
            LayoutInflater inflater = LayoutInflater.From(context);

            View cartView = inflater.Inflate(Resource.Layout.Cart_item, parent, false);
            MyView viewholder = new MyView(cartView);
            return viewholder;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            private View itemView;
            public TextView Name, Duration;
            public ImageButton mDelete;

            public MyView(View _itemView) : base(_itemView)
            {
                itemView = _itemView;
                Name = _itemView.FindViewById<TextView>(Resource.Id.txtNameService);
                Duration = _itemView.FindViewById<TextView>(Resource.Id.txtDurationService);
                mDelete = _itemView.FindViewById<ImageButton>(Resource.Id.btnDelete);

                mDelete.Click += delegate { DeleteButtonClick(_itemView); };
            }

            public void DeleteButtonClick(View view)
            {
                Toast.MakeText(view.Context, "Testing Recycler view", ToastLength.Short).Show();
            }
        }
    }
}