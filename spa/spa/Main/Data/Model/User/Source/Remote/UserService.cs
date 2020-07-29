using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using spa.Utils;
using spa.Services;


namespace spa.Data.Model.User.Source.Remote
{
    public class UserService
    {
        private static string URL_LOGIN = CommonUtils.URL;
        private static UserService singleton;
        //private UserApi userApi;

        private UserService()
        {
            //var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            //userApi = RestService.For<UserApi>(httpClient);
        }

        public static UserService GetInstance()
        {
            if (singleton == null)
                singleton = new UserService();
            return singleton;
        }

        //public UserApi GetUserApi()
        //{
        //    return userApi;
        //}

        public async Task<UserResponse> LoginManual(User user)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new UserRequest { Username = user.username, Password = user.password };
            return await userApi.LoginManual(request).ConfigureAwait(false);
        }

        public async Task<UserResponse> LoginSocial(User user)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new UserRequest { Email = user.email, Token = user.token };
            return await userApi.LoginSocial(request).ConfigureAwait(false);
        }

        public async Task<UserResponse> RegisterManual(User user)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new UserRequest
            {
                Username = user.username,
                Password = user.password,
                Email = user.email,
                Phone = user.phone,
                FullName = user.fullName,
                Gender = user.gender,
                DoB = user.dob
            };
            return await userApi.RegisterManual(request).ConfigureAwait(false);
        }

        public async Task<UserResponse> RegisterSocial(User user)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new UserRequest
            {
                Email = user.email,
                Phone = user.phone,
                FullName = user.fullName,
                Gender = user.gender,
                DoB = user.dob
            };
            return await userApi.RegisterSocial(request).ConfigureAwait(false);
        }

        public async Task<UserResponse> Verify(User user)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new UserRequest { VerifyCode = user.verifyCode };
            return await userApi.Verify(request).ConfigureAwait(false);
        }
    }
}
