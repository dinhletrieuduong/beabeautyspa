using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using spa.Utils;
using spa.Services;


namespace spa.Data.Model.Service.Source.Remote
{
    public class ServiceService
    {
        private static Uri URL_Service = CommonUtils.URL;
        private static ServiceService singleton;

        private ServiceService()
        {
            //var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            //userApi = RestService.For<UserApi>(httpClient);
        }

        public static ServiceService GetInstance()
        {
            if (singleton == null)
                singleton = new ServiceService();
            return singleton;
        }

        public async Task<ServiceResponse> GetAllService()
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            var serviceApi = RestService.For<ServiceApi>(httpClient);
            //var request = new LoginManualRequest { username = user.username, password = user.password };
            return await serviceApi.GetAllServices().ConfigureAwait(false);
        }

    }
}