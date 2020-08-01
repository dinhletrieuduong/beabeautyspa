using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Room_DTO
    {
        public string room_name { get; set; }
        public string room_description { get; set; }
        public string room_service { get; set; }
        public string room_type { get; set; }
        public string number_of_bed { get; set; }
        public bool room_check { get; set; }
    }
}
