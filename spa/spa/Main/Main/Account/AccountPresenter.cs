using System;
using spa.Navigation;
using spa.Base;
using spa.Login;

namespace spa.Main.Account
{
    public class AccountPresenter : BasePresenter
    {
        private IAccountView m_view;

        public AccountPresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IAccountView view)
        {
            m_view = view;
        }

        public void LogOut()
        {
            if (!m_view.IsNavigating)
            {
                m_view.OnNavigationStarted();
                NavigationService.PushPresenter(new LoginPresenter(NavigationService));
            }
        }
    }
}
