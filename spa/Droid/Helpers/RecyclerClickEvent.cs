﻿using System;
using Android.Views;

namespace spa.Droid
{
    public class RecyclerClickEventArgs : EventArgs
    {
        public Android.Views.View View { get; set; }
        public int Position { get; set; }
    }
}