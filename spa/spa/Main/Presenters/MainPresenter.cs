using System;
using spa.Services;
using spa.Views;

namespace spa.Presenters
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
