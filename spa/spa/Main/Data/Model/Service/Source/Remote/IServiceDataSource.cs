using System;
using System.Collections.Generic;

namespace spa.Data.Model.Service.Source.Remote
{
    public interface IServiceDataSource
    {
        List<Service> GetAllServices(string token);
        List<Service> GetServicesByOutlet(string token, int outletID);
        List<Service> GetServiceDetail(string token, int serviceID);
    }
}
