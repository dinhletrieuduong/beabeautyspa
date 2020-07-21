using System;
namespace spa.View
{
    public interface IVerificationView : IActionView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnVerificationFailed(string errorMessage);
    }
}
