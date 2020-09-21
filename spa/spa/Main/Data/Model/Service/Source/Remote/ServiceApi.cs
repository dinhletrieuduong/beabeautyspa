using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
namespace spa.Data.Model.Service.Source.Remote
{
    //[Headers ("Accept: application/json")]
    [Headers("User-Agent: Xamarin")]
    public interface ServiceApi
    {
        [Get("/api/service/all/")]
        Task<List<ServiceResponse>> GetAllServices();

        [Get("/api/outlet/{id}/service")]
        Task<List<ServiceResponse>> GetServicesByOutlet([AliasAs("id")] int outletID);

        [Get("/api/service/{id}")]
        Task<ServiceResponse> GetServiceDetail([AliasAs("id")] int serviceID);
    }
}
