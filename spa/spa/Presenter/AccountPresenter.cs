using System;
using spa.Services;
using spa.View;

namespace spa.Presenter
{
    public class AccountPresenter : BasePresenter
    {
        public AccountPresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IAccountView view)
        {
            m_view = view;
        }

        private IAccountView m_view;
    }
}
