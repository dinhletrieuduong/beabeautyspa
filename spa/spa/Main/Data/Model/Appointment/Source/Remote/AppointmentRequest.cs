using System;
using System.Collections.Generic;
using Refit;

namespace spa.Data.Model.Appointment.Source.Remote
{
    public class AppointmentRequest
    {
        [AliasAs("date")]
        public string date { get; set; }

        [AliasAs("startTime")]
        public string startTime { get; set; }

        [AliasAs("details")]
        public List<Data.Model.PreOrder.PreOrder> details { get; set; }
    }
}
