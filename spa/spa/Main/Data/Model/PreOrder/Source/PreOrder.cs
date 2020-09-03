using System;
using spa.Data.Model.PreOrder.Source.Remote;

namespace spa.Data.Model.PreOrder
{
    public class PreOrder
    {
        public int preOrderID;
        public int serviceID;
        public string serviceName;
        public string duration;
        public string image_url;
        public PreOrder(string name, string dur, string img)
        {
            serviceName = name;
            duration = dur;
            image_url = img;
        }

        public PreOrder(string name, string dur)
        {
            serviceName = name;
            duration = dur;
        }

        public PreOrder(PreOrderResponse response)
        {
            preOrderID = response.preOrderId;
            serviceID = response.serviceId;
            image_url = response.servicePhoto;
            serviceName = response.serviceName;
            duration = response.serviceDuration;
        }
    }
}
