using System;
using System.Collections.Generic;
using spa.Main;
using spa.Navigation;

namespace spa.AddService
{
    public interface IAddServiceView : IMainView, INavigationView
    {
        void updateListService(List<Data.Model.Service.Service> services);
    }
}
