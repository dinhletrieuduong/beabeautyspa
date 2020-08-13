using System;
using System.Collections.Generic;
using spa.Navigation;

namespace spa.Main.Home
{
    public interface IHomeView : IMainView, INavigationView
    {
        void updateListService(List<Data.Model.Service.Service> services);
    }
}
