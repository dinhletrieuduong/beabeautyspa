using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Room_DTO
    {
        public int roomID { get; set; }
        public string roomName { get; set; }
        public int maxBeds { get; set; }
        public string rTypeName { get; set; }
        public bool room_check { get; set; }
    }
}
