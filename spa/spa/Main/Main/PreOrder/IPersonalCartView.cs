using System;
using System.Collections.Generic;
using spa.Main;
using spa.Navigation;

namespace spa.Main.PreOrder
{
    public interface IPersonalCartView : IMainView, INavigationView
    {
        void updateListService(List<Data.Model.PreOrder.PreOrder> preOrders);
        void updateListService(int serviceID);

    }
}
