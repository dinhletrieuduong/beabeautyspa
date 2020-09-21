using System;
using spa.Navigation;
using spa.Base;
using spa.Login;
using spa.Data;

namespace spa.Main.Promotion
{
    public class PromotionPresenter : BasePresenter
    {
        private IPromotionView m_view;
        private DataManager dataManager;
        public PromotionPresenter(INavigationService navigationService) :
            base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IPromotionView view)
        {
            m_view = view;
        }

    }
}
