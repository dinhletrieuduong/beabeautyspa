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

namespace spa.Main.PreOrder
{
    class PersonalCartAdapter : RecyclerView.Adapter
    {
        public List<spa.Data.Model.PreOrder.PreOrder> preOrders;
        PersonalCartPresenter presenter;

        public PersonalCartAdapter(List<spa.Data.Model.PreOrder.PreOrder> preOrders, PersonalCartPresenter presenter)
        {
            this.preOrders = preOrders;
            this.presenter = presenter;
        }
        public override int ItemCount
        {
            get { return preOrders.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyView mHolder = holder as MyView;
            mHolder.Name.Text = preOrders[position].serviceName;
            mHolder.Duration.Text = preOrders[position].duration.ToString() + " minutes";
            mHolder.serviceID = preOrders[position].serviceID;
            mHolder.presenter = presenter;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Context context = parent.Context;
            LayoutInflater inflater = LayoutInflater.From(context);

            View cartView = inflater.Inflate(Resource.Layout.custom_personal_cart_item, parent, false);
            MyView viewholder = new MyView(cartView);
            return viewholder;
        }

        class MyView : RecyclerView.ViewHolder
        {
            //private View itemView;
            public TextView Name, Duration;
            public ImageView mDelete;
            public int serviceID { get; set; }
            public PersonalCartPresenter presenter { get; set; }
            public MyView(View _itemView) : base(_itemView)
            {
                //itemView = _itemView;
                Name = _itemView.FindViewById<TextView>(Resource.Id.txtNameService);
                Duration = _itemView.FindViewById<TextView>(Resource.Id.txtDurationService);
                mDelete = _itemView.FindViewById<ImageView>(Resource.Id.delBtn);

                mDelete.Click += delegate { DeleteButtonClick(_itemView); };
            }

            void DeleteButtonClick(View view)
            {
                Toast.MakeText(view.Context, "Testing Recycler view " + serviceID, ToastLength.Short).Show();
                presenter.DeletePreOrderItem(serviceID);
            }
        }
    }
}