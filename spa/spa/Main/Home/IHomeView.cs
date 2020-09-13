using System;
using System.Collections.Generic;
using spa.Data.Model.Outlet;
using spa.Navigation;

namespace spa.Main.Home
{
    public interface IHomeView : IMainView, INavigationView
    {
        void updateListService(List<Data.Model.Service.Service> services);
        void updateListOutlet(List<Outlet> outlets);
    }
}
