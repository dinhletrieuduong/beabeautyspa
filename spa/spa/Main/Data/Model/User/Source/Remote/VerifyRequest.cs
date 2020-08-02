using System;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class VerifyRequest
    {
        [AliasAs("token")]
        public string token { get; set; }

        [AliasAs("verify_code")]
        public string VerifyCode { get; set; }

    }
}
