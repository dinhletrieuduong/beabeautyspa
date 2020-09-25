using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Service_DTO
    {
        public int service_id { get; set; }
        public string service_name { get; set; }
        public string service_description { get; set; }
        public string service_duration { get; set; }
        public string service_transit { get; set; }
        public string service_photo { get; set; }
        public string service_cost { get; set; }
        public string service_status { get; set; }
        public bool service_check { get; set; }
    }
}
