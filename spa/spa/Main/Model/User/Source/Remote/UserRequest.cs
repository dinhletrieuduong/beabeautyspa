using System;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class UserRequest
    {
        [AliasAs("username")]
        public string username { get; set; }

        [AliasAs("password")]
        public string password { get; set; }

        [AliasAs("email")]
        public string email { get; set; }

        [AliasAs("dob")]
        public string dob { get; set; }

        [AliasAs("phone")]
        public string phone { get; set; }

        [AliasAs("fullname")]
        public string fullname { get; set; }

        [AliasAs("gender")]
        public int gender { get; set; }

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
