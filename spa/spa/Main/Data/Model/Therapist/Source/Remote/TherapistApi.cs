using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;
namespace spa.Data.Model.Therapist.Source.Remote
{
    [Headers("User-Agent: Xamarin")]
    public interface TherapistApi
    {
        [Get("/api/therapist?outletId={id}")]
        Task<List<TherapistResponse>> GetTherapistOutlet([AliasAs("id")] int outletID);

    }
}
