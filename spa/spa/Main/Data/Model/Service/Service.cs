using System;
namespace spa.Data.Model.Service
{
    public class Service
    {
        public int image;
        public string serviceName;
        public string duration;

        public Service(string name, string dur, int img)
        {
            serviceName = name;
            duration = dur;
            image = img;
        }
    }
}
