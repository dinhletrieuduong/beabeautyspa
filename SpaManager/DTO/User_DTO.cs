using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class User_DTO
    {
        public int account_id { get; set; }
        public string username { get; set; }
        public bool is_block { get; set; }
        public string block { get; set; }
    }
}
