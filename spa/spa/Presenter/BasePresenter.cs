using System;
using spa.Services;

namespace spa.Presenter
{
    public abstract class BasePresenter
    {
        protected BasePresenter(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        protected INavigationService NavigationService;
    }
}
