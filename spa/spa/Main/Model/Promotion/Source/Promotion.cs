using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Sql;

namespace spa.Data.Promotion
{
    class Promotion
    {
        public string mTittle;
        public int percentage;

        public Promotion(string tit, int per)
        {
            mTittle = tit;
            percentage = per;
        }
    }
}