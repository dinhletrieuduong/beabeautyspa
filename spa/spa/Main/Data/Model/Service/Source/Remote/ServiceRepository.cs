using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace spa.Data.Model.Service.Source.Remote
{
    public class ServiceRepository : IServiceDataSource
    {
        private ServiceRepository serviceRemote;

        private static ServiceRepository instance;
        private ServiceService serviceService;

        private ServiceRepository(ServiceService serviceService)
        {
            this.serviceService = serviceService;
        }
        private ServiceRepository(ServiceRepository userRemote)
        {
            this.serviceRemote = userRemote;
        }
        public static ServiceRepository GetInstance(ServiceService serviceService)
        {
            if (instance == null)
            {
                instance = new ServiceRepository(serviceService);
            }
            return instance;
        }

        public List<Service> GetAllService()
        {
            var response = serviceService.GetAllService();
            List<Service> resp = new List<Service>();
            string message = "";
            try
            {
                response.Wait();

                //resp.Add(statusCode, message);
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                return resp;
            }
        }
    }
}
