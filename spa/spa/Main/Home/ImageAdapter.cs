using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Graphics;
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Java.Net;

namespace spa.Main.Home
{
    public class ImageAdapter : PagerAdapter
    {
        private Context context;
        LayoutInflater layoutInflater;
        private int[] imageList =
        {
            Resource.Drawable.promotion_home,
            Resource.Drawable.promotion_home,
            Resource.Drawable.promotion_home
        };
        public ImageAdapter(Context context)
        {
            this.context = context;
            layoutInflater = LayoutInflater.From(context);
        }

        public override int Count
        {
            get
            {
                return imageList.Length;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
        {
            return view.Equals(objectValue);
            //return view == ((ImageView)objectValue);
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            View view = container;
            var inflater = context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;
            view = inflater.Inflate(Resource.Layout.carousel_item, null);
            var child = view.FindViewById<ImageView>(Resource.Id.imageview);
            //child.Click += (o, e) =>
            //{
            //    //your code here
            //};
            child.SetScaleType(ImageView.ScaleType.Center);
            child.SetImageResource(imageList[position]);
            container.AddView(view);
            return view;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object objectValue)
        {

            container.RemoveView((View)objectValue);
            //((ViewPager)container).RemoveView((ImageView)objectValue);
        }
    }
}
