using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using System.Net.Http;
using System;

namespace spa.Data.Model.User.Source.Remote
{
    public class UserResponse
    {
        [AliasAs("fullname")]
        public string fullname { get; set; }

        [AliasAs("email")]
        public string email { get; set; }

        [AliasAs("token")]
        public string token { get; set; }

        [AliasAs("first_login")]
        public bool isFirstLogin { get; set; }

        [AliasAs("message")]
        public string message { get; set; }

        //[AliasAs("expires_in")]
        //public string ExpiresIn { get; set; }

        //[AliasAs("refresh_token")]
        //public string RefreshToken { get; set; }

        //[AliasAs("created_at")]
        //public string CreatedAt { get; set; }
    }
}
