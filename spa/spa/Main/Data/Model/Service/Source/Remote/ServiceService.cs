using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using spa.Utils;
using spa.Services;
using System.Net.Http.Headers;

using System.Collections.Generic;

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

        public async Task<List<ServiceResponse>> GetAllServices(string token)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var serviceApi = RestService.For<ServiceApi>(httpClient);
            return await serviceApi.GetAllServices().ConfigureAwait(false);
        }

        public async Task<List<ServiceResponse>> GetServicesByOutlet(string token, int outletID)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var serviceApi = RestService.For<ServiceApi>(httpClient);
            return await serviceApi.GetServicesByOutlet(outletID).ConfigureAwait(false);
        }

        public async Task<ServiceResponse> GetServiceDetail(string token, int outletID)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var serviceApi = RestService.For<ServiceApi>(httpClient);
            return await serviceApi.GetServiceDetail(outletID).ConfigureAwait(false);
        }

    }
}