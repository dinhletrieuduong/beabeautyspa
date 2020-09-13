using System;
namespace spa.Data.Model.User
{
    public class UserInfor
    {
        public UserInfor(string profession, int ic, int weight, int height)
        {
            this.profession = profession;
            this.ic = ic;
            this.weight = weight;
            this.height = height;
        }

        public UserInfor(string profession, int ic, int weight, int height, string basicLifeStyle, string habit, int bodyMass, float bmi, int fat, int muscle, int stomachFat) : this(profession, ic, weight, height)
        {
            this.basicLifeStyle = basicLifeStyle;
            this.habit = habit;
            this.bodyMass = bodyMass;
            this.bmi = bmi;
            this.fat = fat;
            this.muscle = muscle;
            this.stomachFat = stomachFat;
        }

        public int weight { get; set; }
        public int height { get; set; }
        public int ic { get; set; }
        public string profession { get; set; }
        public string basicLifeStyle { get; set; }
        public string habit { get; set; }
        public int bodyMass { get; set; }
        public float bmi { get; set; }
        public int fat { get; set; }
        public int muscle { get; set; }
        public int stomachFat { get; set; }
    }
}
