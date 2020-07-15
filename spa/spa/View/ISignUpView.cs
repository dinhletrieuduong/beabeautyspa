using System;
namespace spa.View
{
    public interface ISignUpView : IActionView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnSignUpFailed(string errorMessage);
    }
}
