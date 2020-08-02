using System;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class ProvideInforRequest
    {
        [AliasAs("profession")]
        public string profession { get; set; }

        [AliasAs("ic")]
        public string ic { get; set; }

        [AliasAs("weight")]
        public string weight { get; set; }

        [AliasAs("height")]
        public string height { get; set; }

        [AliasAs("lifestyle")]
        public string lifestyle { get; set; }

        [AliasAs("habit")]
        public string habit { get; set; }

        [AliasAs("bodymass")]
        public string bodymass { get; set; }

        [AliasAs("bmi")]
        public int bmi { get; set; }

        [AliasAs("fat")]
        public int fat { get; set; }

        [AliasAs("muscle")]
        public int muscle { get; set; }

        [AliasAs("stomachfat")]
        public int stomachfat { get; set; }
    }
}
