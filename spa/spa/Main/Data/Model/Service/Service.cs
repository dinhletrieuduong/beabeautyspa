using System;
namespace spa.Data.Model.Service
{
    public class Service
    {
        public int image;
        public string serviceName;
        public string description;
        public int duration;
        public int transit;
        public string photo;
        public int cost;

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
    }
}
