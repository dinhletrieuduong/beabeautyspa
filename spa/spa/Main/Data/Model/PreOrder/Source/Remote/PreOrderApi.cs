using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
namespace spa.Data.Model.PreOrder.Source.Remote
{
    public interface PreOrderApi
    {
        [Get("/api/preorder?outletId={id}")]
        Task<List<PreOrderResponse>> GetPreOrderList([AliasAs("id")] int outletID);

        [Post("/api/preorder/")]
        Task<PreOrderResponse> AddPreOrderItem(AddPreOrderRequest request);

        [Delete("/api/preorder?outletId={outletID}&serviceId={serviceID}")]
        Task<PreOrderResponse> DeletePreOrderItem([AliasAs("outletID")] int outletID, [AliasAs("serviceID")] int serviceID);
    }
}
