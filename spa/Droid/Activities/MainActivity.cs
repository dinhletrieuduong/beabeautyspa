using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using spa.Views;
using spa.Presenter;
using spa.Droid.Fragments;

namespace spa.Droid
{
    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity, IMainView
    {
        private MainPresenter presenter;
        BottomNavigationView bottomNavigationView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);

            var app = MainApplication.GetApplication(this);
            presenter = (MainPresenter)app.Presenter;
            presenter.SetView(this);

            app.CurrentActivity = this;

            bottomNavigationView = (BottomNavigationView)FindViewById(Resource.Id.bottom_navigation);
            bottomNavigationView.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            LoadFragment(Resource.Id.homeIcon);
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }
        void LoadFragment(int id)
        {
            Android.App.Fragment fragment = null;
            switch (id)
            {
                case Resource.Id.homeIcon:
                    fragment = HomeFragment.NewInstance("", "");
                    break;
                //case Resource.Id.appointmentIcon:
                //    fragment = Fragment2.NewInstance();
                //    break;
                case Resource.Id.accountIcon:
                    fragment = AccountFragment.NewInstance("", "");
                    break;
            }

            if (fragment == null)
                return;

            Android.App.FragmentTransaction transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.frame_container, fragment);
            transaction.AddToBackStack(null);
            transaction.Commit();

            //FragmentManager.BeginTransaction().Replace(Resource.Id.frame_container, fragment).Commit();
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

        //public bool IsNavigating { get; private set; }

        //public void OnNavigationStarted()
        //{
        //    IsNavigating = true;
        //}
    }
}
