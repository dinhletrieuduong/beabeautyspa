using System;
using Refit;

namespace spa.Data.Model.Service.Source.Remote
{
    public class ServiceResponse
    {
        [AliasAs("service_id")]
        public int service_id { get; set; }

        [AliasAs("service_name")]
        public string service_name { get; set; }

        [AliasAs("service_description")]
        public string service_description { get; set; }

        [AliasAs("service_duration")]
        public int service_duration { get; set; }

        [AliasAs("service_transit")]
        public int service_transit { get; set; }

        [AliasAs("service_cost")]
        public float service_cost { get; set; }

        // URL Image
        [AliasAs("service_photo")]
        public string service_photo { get; set; }
    }
}
