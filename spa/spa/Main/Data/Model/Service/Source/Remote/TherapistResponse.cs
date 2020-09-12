using System;
using Refit;

namespace spa.Data.Model.Service.Source.Remote
{
    public class TherapistResponse
    {
        [AliasAs("therapist_id")]
        public int therapist_id { get; set; }

        [AliasAs("therapist_name")]
        public string therapist_name { get; set; }

    }
}
