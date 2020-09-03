using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace spa.Data.Model.PreOrder.Source.Remote
{
    public class PreOrderRepository : IPreOrderDataSource
    {
        private PreOrderRepository serviceRemote;

        private static PreOrderRepository instance;
        private PreOrderService service;

        private PreOrderRepository(PreOrderService service)
        {
            this.service = service;
        }
        private PreOrderRepository(PreOrderRepository userRemote)
        {
            this.serviceRemote = userRemote;
        }
        public static PreOrderRepository GetInstance(PreOrderService service)
        {
            if (instance == null)
            {
                instance = new PreOrderRepository(service);
            }
            return instance;
        }

        public List<PreOrder> GetPreOrderList(string token, int outletID)
        {
            var response = service.GetPreOrderList(token, outletID);
            List<PreOrder> resp = new List<PreOrder>();
            string message = "";
            try
            {
                response.Wait();
                for (int i = 0; i < response.Result.Count; i++)
                {
                    PreOrder p = new PreOrder(response.Result[i]);
                    resp.Add(p);
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

        public void DeletePreOrderItem(string token, int outletID, int serviceID)
        {
            var response = service.DeletePreOrderItem(token, outletID, serviceID);
            string message = "";
            try
            {
                response.Wait();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.StackTrace);
            }

        }

        public void AddPreOrderItem(string token, int outletID, int serviceID)
        {
            var response = service.AddPreOrderItem(token, outletID, serviceID);
            List<PreOrder> resp = new List<PreOrder>();
            string message = "";
            try
            {
                response.Wait();
                PreOrder s = new PreOrder(response.Result);
            }
            catch (Exception e)
            {
                //Debug.WriteLine("Request Timeout");
                Debug.WriteLine(e.StackTrace);
            }

        }
    }
}
