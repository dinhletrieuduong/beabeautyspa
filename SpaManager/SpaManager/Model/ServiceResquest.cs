using Microsoft.AspNetCore.Http.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaManager.Model
{
    class ServiceResquest
    {
       public string service_name { get; set; }
       public string service_description { get; set; }
       public string service_duration { get; set; }
       public string service_transit { get; set; }
       public string service_cost { get; set; }
       public byte[] filePhoto { get; set; }
       public string pathPhoto { get; set; }
    }
}
