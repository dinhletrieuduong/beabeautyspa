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
            id = serviceResponse.service_id;
            image_url = serviceResponse.service_photo;
            serviceName = serviceResponse.service_name;
            description = serviceResponse.service_description;
            duration = serviceResponse.service_duration;
            transit = serviceResponse.service_transit;
            cost = serviceResponse.service_cost;
        }
    }
}
