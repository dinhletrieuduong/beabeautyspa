using System;
using spa.Base;
using spa.Navigation;

namespace spa.SignUp
{
    public interface ISignUpView : IBaseView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnSignUpFailed(string errorMessage);
    }
}
