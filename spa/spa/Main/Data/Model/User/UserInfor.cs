using System;
namespace spa.Data.Model.User
{
    public class UserInfor
    {
        public UserInfor(string profession, string ic, string weight, string height)
        {
            this.profession = profession;
            this.ic = ic;
            this.weight = weight;
            this.height = height;
        }

        public string weight { get; set; }
        public string height { get; set; }
        public string ic { get; set; }
        public string profession { get; set; }
        public string basicLifeStyle { get; set; }
        public string habit { get; set; }
        public string bodyMass { get; set; }
        public string bmi { get; set; }
        public string fat { get; set; }
        public string muscle { get; set; }
        public string stomachFat { get; set; }
    }
}
