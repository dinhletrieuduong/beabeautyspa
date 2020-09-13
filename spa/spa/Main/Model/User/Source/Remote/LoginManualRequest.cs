using System;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class LoginManualRequest
    {
        [AliasAs("username")]
        public string username { get; set; }

        [AliasAs("password")]
        public string password { get; set; }
    }
}
