using System;
using System.Collections.Generic;

namespace spa.Data.Model.Outlet
{
    public interface IOutletDataSource
    {
        List<Outlet> GetAllOutlets(string token);
    }
}
