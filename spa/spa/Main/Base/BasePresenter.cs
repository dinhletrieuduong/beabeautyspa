using System;
using spa.Data;
using spa.Navigation;

namespace spa.Base
{
    public abstract class BasePresenter
    {
        protected INavigationService navigationService;
        private DataManager mDataManager;

        protected BasePresenter(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public BasePresenter(INavigationService navigationService, DataManager dataManager)
        {
            this.navigationService = navigationService;
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
