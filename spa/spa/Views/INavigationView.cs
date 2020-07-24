using System;
namespace spa.Views
{
    public interface INavigationView
    {
        bool IsNavigating { get; }

        void OnNavigationStarted();
    }
}
