using System;

using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Content;

using Plugin.CurrentActivity;
using spa.Droid.Services;
using spa.Presenter;
using spa.Services;
using spa.Data;

namespace spa.Droid
{
    //You can specify additional application information in this attribute
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public BasePresenter Presenter { get; set; }

        public Activity CurrentActivity { get; set; }

        public Fragment CurrentFragment { get; set; }

        private DataManager dataManager;

        public MainApplication(IntPtr handle, JniHandleOwnership transer)
        : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            Presenter = new LoginPresenter(new NavigationService(this));

            //SharedPrefsHelper sharedPrefsHelper = new SharedPrefsHelper(getApplicationContext());
            SharedPrefsHelper sharedPrefsHelper = new SharedPrefsHelper(Context);
            dataManager = DataManager.GetInstance();
            dataManager.SetSharedPrefsHelper(sharedPrefsHelper);

            RegisterActivityLifecycleCallbacks(this);
            App.Initialize();
        }

        public DataManager GetDataManager()
        {
            return dataManager;
        }

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
