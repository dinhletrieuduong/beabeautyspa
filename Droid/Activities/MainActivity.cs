using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using spa.View;
using spa.Presenter;

namespace spa.Droid
{
    [Activity(Label = "MainActivity")]
    public class MainActivity : Activity, IMainView
    {
        private MainPresenter presenter;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);

            var app = MainApplication.GetApplication(this);
            presenter = (MainPresenter)app.Presenter;
            presenter.SetView(this);

            app.CurrentActivity = this;
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
    }
}
