﻿using System;
namespace spa.Data.Model.User
{
    public class User
    {
        private string username;
        private string password;
        //private string phone;
        public string email;

        public User(string uname, string psswd)
        {
            this.username = uname;
            this.password = psswd;
        }

        public string GetUsername()
        {
            return username;
        }

        public string GetPassword()
        {
            return password;
        }

        public string GetEmail()
        {
            return email;
        }

        public bool checkPassword()
        {
            return username.Equals("blue") && password.Equals("1234");
        }

        public void signUp()
        {

        }

    }
}
