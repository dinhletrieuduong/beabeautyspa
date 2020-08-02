using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Service_DTO
    {
        public string service_name { get; set; }
        public string service_cost { get; set; }
        public string service_start_date { get; set; }
        public string service_end_date { get; set; }

        public string service_status { get; set; }
        public bool service_check { get; set; }
    }
}
