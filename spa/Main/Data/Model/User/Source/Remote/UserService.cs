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
        private UserApi userApi;

        private UserService()
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = new Uri(URL_LOGIN) };
            userApi = RestService.For<UserApi>(httpClient);
        }

        public static UserService GetInstance()
        {
            if (singleton == null)
            {
                singleton = new UserService();
            }
            return singleton;
        }

        public UserApi GetUserApi()
        {
            return userApi;
        }

        public async Task<HttpResponseMessage> LoginManual(User user)
        {
            return await userApi.LoginManual(user);
        }

        public async Task<HttpResponseMessage> LoginSocial(User user)
        {
            return await userApi.LoginSocial(user);
        }

        public async Task<HttpResponseMessage> RegisterManual(User user)
        {
            return await userApi.RegisterManual(user);
        }

        public async Task<HttpResponseMessage> RegisterSocial(User user)
        {
            return await userApi.RegisterSocial(user);
        }
    }
}
