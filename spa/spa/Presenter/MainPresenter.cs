using System;
using spa.Services;
using spa.Views;

namespace spa.Presenter
{
    public class MainPresenter : BasePresenter
    {
        public MainPresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IMainView view)
        {
            m_view = view;
        }

        private IMainView m_view;
    }
}
