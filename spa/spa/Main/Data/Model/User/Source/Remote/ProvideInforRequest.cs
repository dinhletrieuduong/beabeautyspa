using System;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class ProvideInforRequest
    {
        [AliasAs("healthId")]
        public int healthId { get; set; }

        [AliasAs("lifeStyle")]
        public string lifeStyle { get; set; }

        [AliasAs("bmi")]
        public float bmi { get; set; }

        [AliasAs("bodyMass")]
        public int bodyMass { get; set; }

        [AliasAs("fatContent")]
        public int fatContent { get; set; }

        [AliasAs("habit")]
        public string habit { get; set; }

        [AliasAs("healthWeight")]
        public int healthWeight { get; set; }

        [AliasAs("healthHeight")]
        public int healthHeight { get; set; }

        [AliasAs("healthProfession")]
        public string healthProfession { get; set; }

        [AliasAs("muscleContent")]
        public int muscleContent { get; set; }

        [AliasAs("stomachFat")]
        public int stomachFat { get; set; }

        [AliasAs("ic")]
        public int ic { get; set; }

        [AliasAs("customerId")]
        public int customerId { get; set; }

    }
}
