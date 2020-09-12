using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Json;
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

        public List<Service> GetAllServices(string token)
        {
            var response = serviceService.GetAllServices(token);
            List<Service> resp = new List<Service>();
            string message = "";
            try
            {
                response.Wait();
                for (int i = 0; i < response.Result.Count; i++)
                {
                    Service s = new Service(response.Result[i]);
                    resp.Add(s);
                }
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                return resp;
            }
        }

        public List<Service> GetServicesByOutlet(string token, int outletID)
        {
            var response = serviceService.GetServicesByOutlet(token, outletID);
            List<Service> resp = new List<Service>();
            string message = "";
            try
            {
                response.Wait();
                for (int i = 0; i < response.Result.Count; i++)
                {
                    Service s = new Service(response.Result[i]);
                    resp.Add(s);
                }
                return resp;
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
                return resp;
            }
        }

        public List<Service> GetServiceDetail(string token, int serviceID)
        {
            var response = serviceService.GetServiceDetail(token, serviceID);
            List<Service> resp = new List<Service>();
            string message = "";
            try
            {
                response.Wait();
                Service s = new Service(response.Result);
                resp.Add(s);
                return resp;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return resp;
            }
        }

        public List<Service> GetTherapistService(string token, int serviceID)
        {
            var response = serviceService.GetServiceDetail(token, serviceID);
            List<Service> resp = new List<Service>();
            string message = "";
            try
            {
                response.Wait();
                Service s = new Service(response.Result);
                resp.Add(s);
                return resp;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
                return resp;
            }
        }
    }
}
