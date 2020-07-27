using System;
using spa.Base;
using spa.Navigation;

namespace spa.Verification
{
    public interface IVerificationView : IBaseView, INavigationView
    {
        void OnInputValidated(bool isValid);
        void OnVerificationFailed(string errorMessage);
    }
}
