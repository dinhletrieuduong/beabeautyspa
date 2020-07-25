using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace spa.Data.Model.User.Source.Remote
{
[Headers ("Accept: application/json")]
    public interface UserApi
    {
        [Post("/login")]
        Task<HttpResponseMessage> Login(User user);

        [Post("/register")]
        Task<User> Register(User user);

        [Post("/update")]
        Task<User> Update(User user);

        [Get("/profile")]
        Task<UserResponse> Profile(User user);


    }
}
