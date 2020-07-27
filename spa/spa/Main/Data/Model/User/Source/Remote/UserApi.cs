using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace spa.Data.Model.User.Source.Remote
{
    //[Headers ("Accept: application/json")]
    public interface UserApi
    {
        [Post("/auth/login/manually")]
        Task<HttpResponseMessage> LoginManual(User user);

        [Post("/auth/login/social")]
        Task<HttpResponseMessage> LoginSocial(User user);

        [Post("/auth/register/manual")]
        Task<HttpResponseMessage> RegisterManual(User user);

        [Post("/auth/register/social")]
        Task<HttpResponseMessage> RegisterSocial(User user);

        [Post("/update")]
        Task<HttpResponseMessage> Update(User user);

        [Get("/profile")]
        Task<HttpResponseMessage> Profile(User user);


    }
}
