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

        [Post("/api/auth/login/manually")]
        Task<UserResponse> LoginManual(LoginManualRequest user);

        [Post("/api/auth/login/social")]
        Task<UserResponse> LoginSocial(UserRequest user);

        [Post("/api/auth/register/manually")]
        Task<UserResponse> RegisterManual(RegisterManualRequest user);

        [Post("/api/auth/register/social")]
        Task<UserResponse> RegisterSocial(UserRequest user);

        [Post("/api/auth/register/social")]
        Task<UserResponse> ProvideInfor(ProvideInforRequest user);

        [Post("/api/auth/register/verify")]
        Task<UserResponse> Verify(VerifyRequest user);

        [Get("/api/healthinformation")]
        Task<UserResponse> Profile(UserRequest user);


    }
}
