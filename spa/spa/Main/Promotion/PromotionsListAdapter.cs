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
using Java.Util.Zip;
using spa.Data.Promotion;
using static Android.Support.V7.Widget.RecyclerView;

namespace spa.Main.PromotionsList
{
    class PromotionsListAdapter : RecyclerView.Adapter
    {
        List<Promotion> mList;
        Context mContext;
        PromotionPresenter mPresenter;

        public PromotionsListAdapter(List<Promotion> list, Context con, PromotionPresenter pre)
        {
            mList = list;
            mContext = con;
            mPresenter = pre;
        }



        public override int ItemCount
        {
            get { return mList.Count; }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {}

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            Context context = parent.Context;
            LayoutInflater layoutInflater = LayoutInflater.From(context);

            View PromotionsView = layoutInflater.Inflate(Resource.Layout.promos_item, parent, false);
            Myview mView = new Myview(PromotionsView, mPresenter);
            return mView;
        }

        public class Myview : RecyclerView.ViewHolder
        {
            private View itemView;
            PromotionPresenter pre;

            public Myview(View _itemView, PromotionPresenter presenter) : base(_itemView)
            {
                this.pre = presenter;
            }

        }
    }
}
