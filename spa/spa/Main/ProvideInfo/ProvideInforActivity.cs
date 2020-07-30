
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

namespace spa.ProvideInfo
{
    [Activity(Label = "ProvideInforActivity")]
    public class ProvideInforActivity : Activity, IProvideInforView
    {
        private ProvideInfoPresenter presenter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_provide_infor);
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

        public void OnInputValidated(bool isValid)
        {
            //throw new NotImplementedException();
        }

        public void OnProvideFailed(int statusCode, string errorMessage)
        {
            throw new NotImplementedException();
        }

    }
}
