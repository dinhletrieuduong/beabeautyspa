using System;
using spa.Base;
using spa.Navigation;

namespace spa.Login
{
    public interface ILoginView : IBaseView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnLoginFailed(int statusCode, string errorMessage);
    }
}
