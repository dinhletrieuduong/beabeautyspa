using System;
namespace spa.Navigation
{
    public interface INavigationView
    {
        bool IsNavigating { get; }

        void OnNavigationStarted();
    }
}
