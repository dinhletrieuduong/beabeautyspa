using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
namespace spa.Data.Model.Outlet.Source.Remote
{
    //[Headers ("Accept: application/json")]
    [Headers("User-Agent: Xamarin")]
    public interface OutletApi
    {
        [Get("/api/outlet/")]
        Task<List<OutletResponse>> GetAllOutlets();

    }
}
