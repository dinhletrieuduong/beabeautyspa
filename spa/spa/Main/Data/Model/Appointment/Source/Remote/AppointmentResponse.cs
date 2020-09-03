using System;
using Refit;

namespace spa.Data.Model.Appointment.Source.Remote
{
    public class AppointmentResponse
    {
        [AliasAs("appointmentID")]
        public int appointmentID { get; set; }

        //[AliasAs("serviceName")]
        //public string serviceName { get; set; }

        //[AliasAs("serviceDescription")]
        //public string serviceDescription { get; set; }

        //[AliasAs("serviceDuration")]
        //public int serviceDuration { get; set; }

        //[AliasAs("serviceTransit")]
        //public int serviceTransit { get; set; }

        //[AliasAs("serviceCost")]
        //public float serviceCost { get; set; }

        //// URL Image
        //[AliasAs("servicePhoto")]
        //public string servicePhoto { get; set; }
    }
}
