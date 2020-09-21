using System;
using System.Collections.Generic;

namespace spa.Data.Model.Therapist
{
    public interface ITherapistDataSource
    {
        List<Therapist> GetTherapistOutlet(string token, int outletID);
    }
}
