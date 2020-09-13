
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using spa.Navigation;

namespace spa.Main.Account
{
    [Obsolete]
    public class AccountFragment : Fragment, IAccountView
    {
        private LinearLayout logOutBtn;
        private AccountPresenter presenter;
        public static AccountFragment NewInstance(String param1, String param2)
        {
            AccountFragment fragment = new AccountFragment();
            Bundle args = new Bundle();
            //        args.putString(ARG_PARAM1, param1);
            fragment.Arguments = args;
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_account, container, false);

            logOutBtn = (LinearLayout)view.FindViewById(Resource.Id.logOutBtn);
            logOutBtn.Click += delegate { LogOut(); };

            presenter = new AccountPresenter(new NavigationService(this.Activity.Application));
            presenter.SetView(this);

            return view;
        }

        //public override void OnResume()
        //{
        //    base.OnResume();
        //}
        //public override void OnPause()
        //{
        //    base.OnPause();
        //}

        private void LogOut()
        {
            presenter.LogOut();
        }


        public bool IsPerformingAction { get; private set; }

        public void OnActionStarted()
        {
            IsPerformingAction = true;
        }

        public void OnActionFinished()
        {
            IsPerformingAction = false;
        }

        public bool IsNavigating { get; private set; }

        public void OnNavigationStarted()
        {
            IsNavigating = true;
        }
    }
}
