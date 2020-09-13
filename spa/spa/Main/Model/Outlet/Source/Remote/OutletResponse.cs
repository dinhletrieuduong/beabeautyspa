using System;
using Refit;

namespace spa.Data.Model.Outlet.Source.Remote
{
    public class OutletResponse
    {
        [AliasAs("outlet_ID")]
        public int outlet_ID { get; set; }

        [AliasAs("outlet_Name")]
        public string outlet_Name { get; set; }

        [AliasAs("outlet_address")]
        public string outlet_address { get; set; }

        [AliasAs("statusID")]
        public int statusID { get; set; }

        [AliasAs("statusName")]
        public string statusName { get; set; }

        [AliasAs("image")]
        public string image { get; set; }
    }
}
