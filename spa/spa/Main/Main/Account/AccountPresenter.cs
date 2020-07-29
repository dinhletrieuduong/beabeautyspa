using System;
using spa.Navigation;
using spa.Base;
using spa.Login;
using spa.Data;

namespace spa.Main.Account
{
    public class AccountPresenter : BasePresenter
    {
        private IAccountView m_view;
        private DataManager dataManager;
        public AccountPresenter(INavigationService navigationService) :
            base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IAccountView view)
        {
            m_view = view;
        }

        public void LogOut()
        {
            if (!m_view.IsNavigating)
            {
                dataManager.ClearToken();
                m_view.OnNavigationStarted();
                NavigationService.PushPresenter(new LoginPresenter(NavigationService));
            }
        }
    }
}
