using System;
using System.Collections.Generic;

namespace spa.Data.Model.Service
{
    public interface IServiceDataSource
    {
        List<Service> GetAllService();
    }
}
