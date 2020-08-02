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

namespace spa.PersonalCart
{
    class PersonalCartAdapter : RecyclerView.Adapter
    {
        public List<spa.Data.Model.Service.Service> services;
        private Context Context;

        public PersonalCartAdapter(List<spa.Data.Model.Service.Service> services, Context con)
        {
            this.services = services;
            Context = con;
        }
        public override int ItemCount
        {
            get { return services.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView mHolder = holder as MyView;
            mHolder.Name.Text = services[position].serviceName;
            mHolder.Duration.Text = services[position].duration.ToString() + " minutes";
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Context context = parent.Context;
            LayoutInflater inflater = LayoutInflater.From(context);

            View cartView = inflater.Inflate(Resource.Layout.personal_cart_item, parent, false);
            MyView viewholder = new MyView(cartView);
            return viewholder;
        }

        public class MyView : RecyclerView.ViewHolder
        {
            //private View itemView;
            public TextView Name, Duration;
            public ImageView mDelete;

            public MyView(View _itemView) : base(_itemView)
            {
                //itemView = _itemView;
                Name = _itemView.FindViewById<TextView>(Resource.Id.txtNameService);
                Duration = _itemView.FindViewById<TextView>(Resource.Id.txtDurationService);
                mDelete = _itemView.FindViewById<ImageView>(Resource.Id.btnDelete);

                mDelete.Click += delegate { DeleteButtonClick(_itemView); };
            }

            public void DeleteButtonClick(View view)
            {
                Toast.MakeText(view.Context, "Testing Recycler view", ToastLength.Short).Show();
            }
        }
    }
}