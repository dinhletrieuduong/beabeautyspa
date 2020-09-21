using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace spa.Data.Model.Therapist.Source.Remote
{
    public class TherpistRepository : ITherapistDataSource
    {
        private static TherpistRepository instance;
        private TherapistService service;

        private TherpistRepository(TherapistService service)
        {
            this.service = service;
        }
        public static TherpistRepository GetInstance(TherapistService service)
        {
            if (instance == null)
            {
                instance = new TherpistRepository(service);
            }
            return instance;
        }


        public List<Therapist> GetTherapistOutlet(string token, int outletID)
        {
            var response = service.GetTherapistOutlet(token, outletID);
            List<Therapist> resp = new List<Therapist>();
            string message = "";
            try
            {
                response.Wait();
                foreach (TherapistResponse r in response.Result)
                {
                    Therapist t = new Therapist(r);
                    resp.Add(t);
                }
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
