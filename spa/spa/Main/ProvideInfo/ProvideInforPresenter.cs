using System;
using spa.Base;
using spa.Navigation;

namespace spa.ProvideInfo
{
    public class ProvideInfoPresenter : BasePresenter
    {
        private IProvideInforView view;
        private string weight;
        private string height;
        private string IC;
        private string professional;

        public ProvideInfoPresenter(NavigationService navigationService) : base(navigationService)
        {
        }

        public void SetVIew(IProvideInforView v)
        {
            view = v;
        }
    }
}
