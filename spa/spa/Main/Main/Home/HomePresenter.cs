﻿using System;
using Java.Lang.Ref;
using spa.Base;
using spa.Navigation;

namespace spa.Main.Home
{
    public class HomePresenter : BasePresenter
    {
        //This is to avoid retaining a reference to the Activity/Fragment.The presenter makes async requests to APIs.If you press back or finish the activity while the presenter is making the request and you don't use a WeakReference, the presenter will retain the Activity/Fragment memory (retaining all the views and members of that Activity/Fragment). Instead of using a WeakReference, it's also common to expose an attach and detach method in the presenter.After instantiating the presenter you should call the attach method and when Activity/Fragment's onDestroy is called, you should call detach
        //If you don't use a WeakReference nor the attach/dettach approach and your activity/fragment was destroyed before the presenter's request has finished, you could also run into problems when the request finishes, because it will try to update something on the destroyed activity/fragment
        private WeakReference<IHomeView> m_view;

        public HomePresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IHomeView view)
        {
            m_view = new WeakReference<IHomeView>(view);

            //m_view.TryGetTarget();
        }
    }
}