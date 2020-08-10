using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace spa.Data.Model.Service.Source.Remote
{
    //[Headers ("Accept: application/json")]
    [Headers("User-Agent: Xamarin")]
    public interface ServiceApi
    {
        [Get("/api/service/all/")]
        Task<ServiceResponse> GetAllServices();

    }
}
