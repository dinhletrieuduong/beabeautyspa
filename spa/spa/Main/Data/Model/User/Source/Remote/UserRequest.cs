using System;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class UserRequest
    {
        [AliasAs("email")]
        public string Email { get; set; }

        [AliasAs("username")]
        public string Username { get; set; }

        [AliasAs("password")]
        public string Password { get; set; }

        [AliasAs("dob")]
        public string DoB { get; set; }

        [AliasAs("phone")]
        public string Phone { get; set; }

        [AliasAs("fullname")]
        public string FullName { get; set; }

        [AliasAs("password")]
        public int Gender { get; set; }

        [AliasAs("token")]
        public string Token { get; set; }

        [AliasAs("verify_code")]
        public string VerifyCode { get; set; }

        [AliasAs("clientId")]
        public string ClientId => "cientId";

        [AliasAs("grant_type")]
        public string GrantType => "password";
    }
}
