using System;
using spa.Data;
using spa.Services;

namespace spa.Presenter
{
    public abstract class BasePresenter
    {
        protected INavigationService NavigationService;
        private DataManager mDataManager;

        protected BasePresenter(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public BasePresenter(INavigationService navigationService, DataManager dataManager)
        {
            NavigationService = navigationService;
            mDataManager = dataManager;
        }

        public void SetDataManager(DataManager dataManager)
        {
            mDataManager = dataManager;
        }
        public DataManager GetDataManager()
        {
            return mDataManager;
        }
    }
}
