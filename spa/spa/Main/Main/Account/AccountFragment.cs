
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
using spa.Data.Model.User;
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
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_account, container, false);

            logOutBtn = (LinearLayout)view.FindViewById(Resource.Id.logOutBtn);
            logOutBtn.Click += delegate { LogOut(); };

            presenter = new AccountPresenter(new NavigationService(this.Activity.Application));
            presenter.SetView(this);
            //HealthInfor health = new HealthInfor("DDD", 1, 1, 1, "a", "a", 1, 1, 1, 1, 1);
            //presenter.UpdateHealthInfor(health);
            //presenter.GetHealthInformation();

            return view;
        }

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
