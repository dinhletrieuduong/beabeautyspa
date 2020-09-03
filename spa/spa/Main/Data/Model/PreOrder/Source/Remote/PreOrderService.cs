using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using spa.Utils;
using spa.Services;
using System.Net.Http.Headers;

using System.Collections.Generic;

namespace spa.Data.Model.PreOrder.Source.Remote
{
    public class PreOrderService
    {
        private static Uri URL_Service = CommonUtils.URL;
        private static PreOrderService singleton;

        private PreOrderService()
        {
            //var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            //userApi = RestService.For<UserApi>(httpClient);
        }

        public static PreOrderService GetInstance()
        {
            if (singleton == null)
                singleton = new PreOrderService();
            return singleton;
        }

        public async Task<List<PreOrderResponse>> GetPreOrderList(string token, int outletID)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var api = RestService.For<PreOrderApi>(httpClient);
            return await api.GetPreOrderList(outletID).ConfigureAwait(false);
        }

        public async Task<PreOrderResponse> AddPreOrderItem(string token, int outletID, int serviceID)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var api = RestService.For<PreOrderApi>(httpClient);
            AddPreOrderRequest request = new AddPreOrderRequest() { outletId = outletID, serviceId = serviceID };
            return await api.AddPreOrderItem(request).ConfigureAwait(false);
        }

        public async Task<PreOrderResponse> DeletePreOrderItem(string token, int outletID, int serviceID)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var api = RestService.For<PreOrderApi>(httpClient);
            return await api.DeletePreOrderItem(outletID, serviceID).ConfigureAwait(false);
        }
    }
}