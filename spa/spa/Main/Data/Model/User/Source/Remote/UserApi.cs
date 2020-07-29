using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace spa.Data.Model.User.Source.Remote
{
    //[Headers ("Accept: application/json")]
    [Headers("User-Agent: Xamarin")]
    public interface UserApi
    {
        //    [Post("/auth/login/manually")]
        //    Task<HttpResponseMessage> LoginManual([Body(BodySerializationMethod.UrlEncoded)]  User user);

        [Post("/auth/login/manually")]
        Task<UserResponse> LoginManual(UserRequest user);

        [Post("/auth/login/social")]
        Task<UserResponse> LoginSocial(UserRequest user);

        [Post("/api/auth/register/manually")]
        Task<UserResponse> RegisterManual(UserRequest user);

        [Post("/auth/register/social")]
        Task<UserResponse> RegisterSocial(UserRequest user);

        [Post("/auth/register/verify")]
        Task<UserResponse> Verify(UserRequest user);

        [Post("/update")]
        Task<UserResponse> Update(UserRequest user);

        [Get("/profile")]
        Task<UserResponse> Profile(UserRequest user);


    }
}
