using System;
namespace spa.Views
{
    public interface ISignUpView : IActionView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnSignUpFailed(string errorMessage);
    }
}
