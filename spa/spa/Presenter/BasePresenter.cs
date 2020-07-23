using System;
using spa.Data;
using spa.Services;

namespace spa.Presenter
{
    public abstract class BasePresenter
    {
        protected BasePresenter(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public BasePresenter(DataManager dataManager)
        {
            mDataManager = dataManager;
        }

        protected INavigationService NavigationService;
        DataManager mDataManager;

        public DataManager getDataManager()
        {
            return mDataManager;
        }
    }
}
