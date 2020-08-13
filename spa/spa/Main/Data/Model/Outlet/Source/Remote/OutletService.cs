using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using spa.Utils;
using spa.Services;
using System.Net.Http.Headers;

using System.Collections.Generic;

namespace spa.Data.Model.Outlet.Source.Remote
{
    public class OutletService
    {
        private static Uri URL_Service = CommonUtils.URL;
        private static OutletService singleton;

        private OutletService()
        {
            //var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            //userApi = RestService.For<UserApi>(httpClient);
        }

        public static OutletService GetInstance()
        {
            if (singleton == null)
                singleton = new OutletService();
            return singleton;
        }

        public async Task<List<OutletResponse>> GetAllOutlets(string token)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var serviceApi = RestService.For<OutletApi>(httpClient);
            return await serviceApi.GetAllOutlets().ConfigureAwait(false);
        }

    }
}