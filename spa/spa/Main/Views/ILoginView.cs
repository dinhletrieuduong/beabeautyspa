using System;

namespace spa.Views
{
    public interface ILoginView : IActionView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnLoginFailed(int statusCode, string errorMessage);
    }
}
