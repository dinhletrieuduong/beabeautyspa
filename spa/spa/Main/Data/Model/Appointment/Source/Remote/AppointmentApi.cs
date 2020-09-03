using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace spa.Data.Model.Appointment.Source.Remote
{
    //[Headers ("Accept: application/json")]
    [Headers("User-Agent: Xamarin")]
    public interface AppointmentApi
    {
        [Get("/api/appt/history")]
        Task<List<AppointmentResponse>> GetAppointmentHistory();
        [Get("/api/appt/{id}")]
        Task<List<AppointmentResponse>> GetAppointmentDetail([AliasAs("id")] int apptID);

    }
}
