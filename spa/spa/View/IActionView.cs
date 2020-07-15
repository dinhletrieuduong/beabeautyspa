using System;
namespace spa.View
{
    public interface IActionView
    {
        bool IsPerformingAction { get; }

        void OnActionFinished();
        void OnActionStarted();
    }
}
