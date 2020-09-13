using System;
using spa.Navigation;
using spa.Base;

namespace spa.Main
{
    public class MainPresenter : BasePresenter
    {
        private IMainView m_view;

        public MainPresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IMainView view)
        {
            m_view = view;
        }

    }
}
