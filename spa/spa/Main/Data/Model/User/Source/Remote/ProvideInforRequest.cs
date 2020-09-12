using System;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class ProvideInforRequest
    {
        [AliasAs("health_id")]
        public int health_id { get; set; }

        [AliasAs("life_style")]
        public string life_style { get; set; }

        [AliasAs("bmi")]
        public float bmi { get; set; }

        [AliasAs("body_mass")]
        public int body_mass { get; set; }

        [AliasAs("fat_content")]
        public int fat_content { get; set; }

        [AliasAs("habit")]
        public string habit { get; set; }

        [AliasAs("health_weight")]
        public int health_weight { get; set; }

        [AliasAs("health_height")]
        public int health_height { get; set; }

        [AliasAs("health_profession")]
        public string health_profession { get; set; }

        [AliasAs("muscle_content")]
        public int muscle_content { get; set; }

        [AliasAs("stomach_fat")]
        public int stomach_fat { get; set; }

        [AliasAs("ic")]
        public int ic { get; set; }

        [AliasAs("customer_id")]
        public int customer_id { get; set; }

    }
}
