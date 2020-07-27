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
using spa.Activities;
using spa.Presenters;

namespace spa.Services
{
    public class NavigationService : INavigationService
    {
        private Application application;
        private BasePresenter presenter;

        public NavigationService(Application application, BasePresenter presenter)
        {
            this.application = application;
            this.presenter = presenter;
        }

        public NavigationService(Application application)
        {
            this.application = application;
        }

        public void PushPresenter(BasePresenter presenter)
        {
            var oldPresenter = this.presenter;

            if (presenter != oldPresenter)
            {
                this.presenter = presenter;
                Intent intent = null;

                if (presenter is LoginPresenter)
                {
                    intent = new Intent(application, typeof(LoginActivity));
                }
                else if (presenter is SignUpPresenter)
                {
                    intent = new Intent(application, typeof(SignUpManualActivity));
                }
                else if (presenter is VerificationPresenter)
                {
                    intent = new Intent(application, typeof(VerificationActivity));
                }
                else if (presenter is MainPresenter)
                {
                    intent = new Intent(application, typeof(MainActivity));
                }

                if (intent != null)
                {
                    application.StartActivity(intent);
                }
            }
        }

    }
}
