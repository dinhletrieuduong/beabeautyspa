using System;
using Refit;

namespace spa.Data.Model.PreOrder.Source.Remote
{
    public class PreOrderResponse
    {
        [AliasAs("preOrderId")]
        public int preOrderId { get; set; }

        [AliasAs("serviceId")]
        public int serviceId { get; set; }

        [AliasAs("customerId")]
        public int customerId { get; set; }

        [AliasAs("outletId")]
        public int outletId { get; set; }

        [AliasAs("serviceName")]
        public string serviceName { get; set; }

        [AliasAs("serviceDuration")]
        public string serviceDuration { get; set; }

        // URL Image
        [AliasAs("servicePhoto")]
        public string servicePhoto { get; set; }
    }
}
