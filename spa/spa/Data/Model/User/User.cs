using System;
namespace spa.Data.Model.User
{
    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        //public string phone{ get; set; }
        public string email { get; set; }

        public User(string uname, string psswd)
        {
            this.username = uname;
            this.password = psswd;
        }


    }
}
