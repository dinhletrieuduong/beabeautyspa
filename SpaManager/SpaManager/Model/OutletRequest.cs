using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpaManager.Model
{
    class OutletRequest
    {
        public string outletName { get; set; }
        public string outletAddress { get; set; }
        public byte[] filePhoto { get; set; }
        public string pathPhoto { get; set; }
    }
}
