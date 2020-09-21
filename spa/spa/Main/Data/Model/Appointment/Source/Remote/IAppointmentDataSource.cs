using System;
using System.Collections.Generic;

namespace spa.Data.Model.Appointment.Source.Remote
{
    public interface IAppointmentDataSource
    {
        List<Appointment> GetAppointmentHistory(string token);
        void CreateAppointment(string token, Appointment appointment);

    }
}
