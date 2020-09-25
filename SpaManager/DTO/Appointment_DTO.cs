using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Appointment_DTO
    {
        public int appt_id { get; set; }
        public int cust_id { get; set; }
        public int outlet_id { get; set; }
        public string start_time { get; set; }
        public string end_time { get; set; }
        public float total_price { get; set; }
        public int status_id { get; set; }
        public string status_name { get; set; }
        public bool appt_check { get; set; }
    }
}
