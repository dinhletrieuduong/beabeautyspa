using System;
using spa.Data.Model.Outlet.Source.Remote;
using spa.Data.Model.Therapist.Source.Remote;

namespace spa.Data.Model.Therapist
{
    public class Therapist
    {
        public int id;
        public string name;
        public string phone;
        public Therapist(int id, string name, string phone)
        {
            this.name = name;
            this.id = id;
            this.phone = phone;
        }

        public Therapist(TherapistResponse response)
        {
            id = response.therapist_id;
            name = response.therapist_name;
            phone = response.therapist_phone;
        }
    }
}
