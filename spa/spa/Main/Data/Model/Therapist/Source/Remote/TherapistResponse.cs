using System;
using Refit;

namespace spa.Data.Model.Therapist.Source.Remote
{
    public class TherapistResponse
    {
        [AliasAs("therapist_id")]
        public int therapist_id { get; set; }

        [AliasAs("therapist_name")]
        public string therapist_name { get; set; }

        [AliasAs("therapist_phone")]
        public string therapist_phone { get; set; }
    }
}
