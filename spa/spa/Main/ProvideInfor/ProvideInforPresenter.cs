using System;
using spa.Base;
using spa.Navigation;

namespace spa.ProvideInfor
{
    public class ProvideInforPresenter : BasePresenter
    {
        private IProvideInforView view;
        private string weight;
        private string height;
        private string IC;
        private string professional;

        public ProvideInforPresenter(INavigationService navigationService) : base(navigationService)
        {
        }

        public void SetVIew(IProvideInforView v)
        {
            view = v;
        }
    }
}
