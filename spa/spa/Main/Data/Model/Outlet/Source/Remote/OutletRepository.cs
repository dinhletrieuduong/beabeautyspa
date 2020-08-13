using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace spa.Data.Model.Outlet.Source.Remote
{
    public class OutletRepository : IOutletDataSource
    {
        private static OutletRepository instance;
        private OutletService serviceService;

        private OutletRepository(OutletService serviceService)
        {
            this.serviceService = serviceService;
        }
        public static OutletRepository GetInstance(OutletService serviceService)
        {
            if (instance == null)
            {
                instance = new OutletRepository(serviceService);
            }
            return instance;
        }

        public List<Outlet> GetAllService(string token)
        {
            var response = serviceService.GetAllOutlets(token);
            List<Outlet> resp = new List<Outlet>();
            string message = "";
            try
            {
                response.Wait();
                for (int i = 0; i < response.Result.Count; i++)
                {
                    Outlet outlet = new Outlet(response.Result[i]);
                    resp.Add(outlet);
                }
                //resp response.Result;
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

        public List<Outlet> GetAllOutlets(string token)
        {
            throw new NotImplementedException();
        }
    }
}
