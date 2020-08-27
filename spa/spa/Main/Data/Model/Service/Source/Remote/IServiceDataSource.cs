using System;
using System.Collections.Generic;

namespace spa.Data.Model.Service
{
    public interface IServiceDataSource
    {
        List<Service> GetAllServices(string token);
        List<Service> GetServicesByOutlet(string token, int outletID);
    }
}
