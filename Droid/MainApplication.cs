using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Content;

using Plugin.CurrentActivity;
using spa.Droid.Services;
using spa.Presenter;
using spa.Services;

namespace spa.Droid
{
    //You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application
    , Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer)
        : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Presenter = new LoginPresenter(new NavigationService(this));
            RegisterActivityLifecycleCallbacks(this);
            App.Initialize();
        }
        public BasePresenter Presenter { get; set; }

        public Activity CurrentActivity { get; set; }

        public static MainApplication GetApplication(Context context)
        {
            return (MainApplication)context.ApplicationContext;
        }
        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityDestroyed(Activity activity)
        {

        }

        public void OnActivityPaused(Activity activity)
        {

        }

        public void OnActivityResumed(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState)
        {

        }

        public void OnActivityStarted(Activity activity)
        {
            CrossCurrentActivity.Current.Activity = activity;
        }

        public void OnActivityStopped(Activity activity)
        {

        }
    }
}
