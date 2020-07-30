using System;
using spa.Base;
using spa.Navigation;

namespace spa.ProvideInfor
{
    public interface IProvideInforView : IBaseView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnProvideFailed(int statusCode, string errorMessage);
    }
}
