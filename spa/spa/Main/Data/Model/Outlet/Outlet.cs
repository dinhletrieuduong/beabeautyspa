using System;
using spa.Data.Model.Outlet.Source.Remote;

namespace spa.Data.Model.Outlet
{
    public class Outlet
    {
        public int id;
        public string name;
        public string address;
        public int status_id;
        public string status_name;
        public string image;
        public Outlet(int id, string name, string addr, int sID, string sName, string img)
        {
            this.name = name;
            this.id = id;
            address = addr;
            status_id = sID;
            status_name = sName;
            image = img;
        }

        public Outlet(OutletResponse response)
        {
            id = response.outlet_ID;
            name = response.outlet_Name;
            address = response.outlet_address;
            status_id = response.statusID;
            status_name = response.statusName;
            image = response.image;
        }
    }
}
