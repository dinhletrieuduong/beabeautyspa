using System;
using System.Collections.Generic;

namespace spa.Data.Model.PreOrder.Source.Remote
{
    public interface IPreOrderDataSource
    {
        List<PreOrder> GetPreOrderList(string token, int outletID);
        void AddPreOrderItem(string token, int outletID, int serviceID);
        void DeletePreOrderItem(string token, int outletID, int serviceID);
    }
}
