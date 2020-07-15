using System;
namespace spa.Data.Model
{
    public class User
    {
        private string username;
        private string password;
        private string phone;
        private string email;

        public User(string uname, string psswd)
        {
            this.username = uname;
            this.password = psswd;
        }

        public bool checkPassword()
        {
            return username.Equals("mvpexample") && password.Equals("1234");
        }

        public void signUp()
        {

        }

    }
}
