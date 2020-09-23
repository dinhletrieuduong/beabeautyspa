using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using spa.Utils;
using spa.Services;
using System.Net.Http.Headers;

using System.Collections.Generic;

namespace spa.Data.Model.Appointment.Source.Remote
{
    public class AppointmentService
    {
        private static Uri URL_Service = CommonUtils.URL;
        private static AppointmentService singleton;

        private AppointmentService()
        {
            //var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            //userApi = RestService.For<UserApi>(httpClient);
        }

        public static AppointmentService GetInstance()
        {
            if (singleton == null)
                singleton = new AppointmentService();
            return singleton;
        }

        public async Task<List<AppointmentResponse>> GetAppointmentHistory(string token)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var appointmentApi = RestService.For<AppointmentApi>(httpClient);
            return await appointmentApi.GetAppointmentHistory().ConfigureAwait(false);
        }
        public async Task<List<AppointmentResponse>> CreateAppointment(string token, Appointment appointment)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_Service };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var appointmentApi = RestService.For<AppointmentApi>(httpClient);
            var request = new AppointmentRequest()
            {
                details = appointment.details,
                startTime = appointment.mStartTime,
                outletID = appointment.outletID
            };
            return await appointmentApi.CreateAppointment(request).ConfigureAwait(false);
        }
    }
}