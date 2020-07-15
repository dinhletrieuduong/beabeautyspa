using System;
namespace spa.View
{
    public interface INavigationView
    {
        bool IsNavigating { get; }

        void OnNavigationStarted();
    }
}
