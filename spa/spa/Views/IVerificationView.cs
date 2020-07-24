using System;
namespace spa.Views
{
    public interface IVerificationView : IActionView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnVerificationFailed(string errorMessage);
    }
}
