using System;

namespace spa.View
{
    public interface ILoginView : IActionView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnLoginFailed(string errorMessage);
    }
}
