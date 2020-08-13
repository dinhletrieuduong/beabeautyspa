using System;
using spa.Data.Model.Service.Source.Remote;

namespace spa.Data.Model.Service
{
    public class Service
    {
        public int image;
        public int id;
        public string serviceName;
        public string description;
        public int duration;
        public int transit;
        public float cost;
        public string image_url;
        public Service(string name, int dur, int img)
        {
            serviceName = name;
            duration = dur;
            image = img;
        }

        public Service(string name, int dur)
        {
            serviceName = name;
            duration = dur;
        }

        public Service(ServiceResponse serviceResponse)
        {
            id = serviceResponse.serviceID;
            image_url = serviceResponse.servicePhoto;
            serviceName = serviceResponse.serviceName;
            description = serviceResponse.serviceDescription;
            duration = serviceResponse.serviceDuration;
            transit = serviceResponse.serviceTransit;
            cost = serviceResponse.serviceCost;
        }
    }
}
