using System;
using spa.Navigation;

namespace spa.Main.DetailService
{
    public interface IDetailServiceView : IMainView, INavigationView
    {
        void updateServiceDetail(Data.Model.Service.Service service);
    }
}
