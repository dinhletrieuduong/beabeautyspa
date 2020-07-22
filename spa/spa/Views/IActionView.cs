using System;
namespace spa.Views
{
    public interface IActionView
    {
        bool IsPerformingAction { get; }

        void OnActionFinished();
        void OnActionStarted();
    }
}
