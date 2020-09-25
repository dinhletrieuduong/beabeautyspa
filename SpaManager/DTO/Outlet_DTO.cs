using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Outlet_DTO
    {
        public int outlet_id { get; set; }
        public string outlet_name { get; set; }
        public string outlet_address { get; set; }
        public string outlet_image { get; set; }
        public int outlet_status_id { get; set; }
        public string outlet_status_name { get; set; }
        public int managerID { get; set; }
        public int rating_value { get; set; }
        public bool outlet_check { get; set; }
    }
}
