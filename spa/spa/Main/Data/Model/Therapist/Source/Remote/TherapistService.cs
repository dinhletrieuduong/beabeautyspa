using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using spa.Utils;
using spa.Services;
using System.Net.Http.Headers;

using System.Collections.Generic;

namespace spa.Data.Model.Therapist.Source.Remote
{
    public class TherapistService
    {
        private static Uri URL_Service = CommonUtils.URL;
        private static TherapistService singleton;

        private TherapistService()
        {
            //var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            //userApi = RestService.For<UserApi>(httpClient);
        }

        public static TherapistService GetInstance()
        {
            if (singleton == null)
                singleton = new TherapistService();
            return singleton;
        }

        public async Task<List<TherapistResponse>> GetTherapistOutlet(string token, int outletID)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var api = RestService.For<TherapistApi>(httpClient);
            return await api.GetTherapistOutlet(outletID).ConfigureAwait(false);
        }

    }
}