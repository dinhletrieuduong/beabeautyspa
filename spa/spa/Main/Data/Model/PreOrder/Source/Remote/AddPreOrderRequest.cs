using System;
using Refit;

namespace spa.Data.Model.PreOrder.Source.Remote
{
    public class AddPreOrderRequest
    {
        [AliasAs("outletId")]
        public int outletId { get; set; }

        [AliasAs("serviceId")]
        public int serviceId { get; set; }
    }
}
