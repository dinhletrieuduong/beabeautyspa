using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaManager.Model
{
    class RoomRequest
    {
        public int outlet_id { get; set; }
        public string room_name { get; set; }
        public int max_beds { get; set; }
        public int r_type { get; set; }

    }
}
