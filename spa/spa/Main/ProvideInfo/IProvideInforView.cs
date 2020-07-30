using System;
using spa.Base;

namespace spa.ProvideInfo
{
    public interface IProvideInforView : IBaseView
    {
        void OnInputValidated(bool isValid);
        void OnProvideFailed(int statusCode, string errorMessage);
    }
}
