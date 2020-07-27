using System;
namespace spa.Data.Model.User
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string token { get; set; }

        public User()
        {
        }

        public User(string uname, string psswd)
        {
            this.username = uname;
            this.password = psswd;
        }

        public User(string uname, string psswd, string email, string dob, string phone, string fullName, string gender)
        {
            this.username = uname;
            this.password = psswd;
            this.dob = dob;
            this.phone = phone;
            this.fullName = fullName;
            this.gender = gender;
            this.email = email;
        }
    }
}
