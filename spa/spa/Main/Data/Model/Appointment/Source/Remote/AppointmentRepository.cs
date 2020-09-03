using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace spa.Data.Model.Appointment.Source.Remote
{
    public class AppointmentRepository : IAppointmentDataSource
    {
        private AppointmentRepository appointmentRemote;

        private static AppointmentRepository instance;
        private AppointmentService appointmentService;

        private AppointmentRepository(AppointmentService appointmentService)
        {
            this.appointmentService = appointmentService;
        }
        private AppointmentRepository(AppointmentRepository userRemote)
        {
            this.appointmentRemote = userRemote;
        }
        public static AppointmentRepository GetInstance(AppointmentService serviceService)
        {
            if (instance == null)
            {
                instance = new AppointmentRepository(serviceService);
            }
            return instance;
        }

        public List<Appointment> GetAppointmentHistory(string token)
        {
            var response = appointmentService.GetAppointmentHistory(token);
            List<Appointment> resp = new List<Appointment>();
            string message = "";
            try
            {
                response.Wait();
                for (int i = 0; i < response.Result.Count; i++)
                {
                    Appointment app = new Appointment(response.Result[i]);
                    resp.Add(app);
                }
                //resp response.Result;
                //resp.Add(statusCode, message);
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                return resp;
            }
        }
    }
}
