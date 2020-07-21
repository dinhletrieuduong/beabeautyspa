
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

using spa.Services;
using spa.Presenter;
//using spa.Droid;

namespace spa.Droid.Services
{
    public class NavigationService : INavigationService
    {
        private MainApplication m_application;

        public NavigationService(MainApplication application)
        {
            m_application = application;
        }

        public void PushPresenter(BasePresenter presenter)
        {
            var oldPresenter = m_application.Presenter as BasePresenter;

            if (presenter != oldPresenter)
            {
                m_application.Presenter = presenter;
                Intent intent = null;

                if (presenter is LoginPresenter)
                {
                    intent = new Intent(m_application.CurrentActivity, typeof(LoginActivity));
                }
                else if (presenter is SignUpPresenter)
                {
                    intent = new Intent(m_application.CurrentActivity, typeof(SignUpActivity));
                }
                else if (presenter is VerificationPresenter)
                {
                    intent = new Intent(m_application.CurrentActivity, typeof(VerificationActivity));
                }
                else if (presenter is MainPresenter)
                {
                    intent = new Intent(m_application.CurrentActivity, typeof(MainActivity));
                }

                if (intent != null)
                {
                    m_application.CurrentActivity.StartActivity(intent);
                }
            }
        }

    }
}
