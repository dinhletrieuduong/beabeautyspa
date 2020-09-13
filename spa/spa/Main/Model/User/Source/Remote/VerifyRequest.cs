using System;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class VerifyRequest
    {
        //[AliasAs("token")]
        //public string token { get; set; }

        [AliasAs("code_verify")]
        public string code_verify { get; set; }
    }
}
