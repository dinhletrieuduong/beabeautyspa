using System;
using Refit;

namespace spa.Data.Model.Service.Source.Remote
{
    public class ServiceResponse
    {
        [AliasAs("serviceID")]
        public int serviceID { get; set; }

        [AliasAs("serviceName")]
        public string serviceName { get; set; }

        [AliasAs("serviceDescription")]
        public string serviceDescription { get; set; }

        [AliasAs("serviceDuration")]
        public int serviceDuration { get; set; }

        [AliasAs("serviceTransit")]
        public int serviceTransit { get; set; }

        [AliasAs("serviceCost")]
        public float serviceCost { get; set; }

        // URL Image
        [AliasAs("servicePhoto")]
        public string servicePhoto { get; set; }
    }
}
