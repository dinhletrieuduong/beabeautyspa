using System;
namespace spa.Base
{
    public interface IBaseView
    {
        bool IsPerformingAction { get; }

        void OnActionFinished();
        void OnActionStarted();
        //bool isNetworkConnected();
    }
}
