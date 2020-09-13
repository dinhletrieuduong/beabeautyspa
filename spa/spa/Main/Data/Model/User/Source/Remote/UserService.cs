
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using spa.Utils;
using spa.Services;
using System.Net.Http.Headers;

namespace spa.Data.Model.User.Source.Remote
{
    public class UserService
    {
        private static Uri URL_LOGIN = CommonUtils.URL;
        private static UserService singleton;
        //private UserApi userApi;

        private UserService() { }

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
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_LOGIN };
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new LoginManualRequest { username = user.username, password = user.password };
            return await userApi.LoginManual(request).ConfigureAwait(false);
        }

        public async Task<UserResponse> LoginSocial(string fbToken)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_LOGIN };
            var userApi = RestService.For<UserApi>(httpClient);
            return await userApi.LoginSocial(fbToken).ConfigureAwait(false);
        }

        public async Task<UserResponse> RegisterManual(User user)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_LOGIN };
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new RegisterManualRequest
            {
                username = user.username,
                password = user.password,
                email = user.email,
                phone = user.phone,
                fullname = user.fullName,
                gender = user.gender,
                dob = user.dob
            };
            return await userApi.RegisterManual(request).ConfigureAwait(false);
        }

        public async Task<UserResponse> RegisterSocial(User user)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_LOGIN };
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new UserRequest
            {
                email = user.email,
                phone = user.phone,
                fullname = user.fullName,
                gender = user.gender,
                dob = user.dob
            };
            return await userApi.RegisterSocial(request).ConfigureAwait(false);
        }

        public async Task<UserResponse> Verify(User user)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_LOGIN };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.token);
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new VerifyRequest { code_verify = user.verifyCode };
            return await userApi.Verify(request).ConfigureAwait(false);
        }

        public async Task<UserResponse> UpdateHealthInfor(HealthInfor userInfo, string token)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_LOGIN };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var userApi = RestService.For<UserApi>(httpClient);
            var request = new ProvideInforRequest
            {
                health_height = userInfo.height,
                health_weight = userInfo.weight,
                ic = userInfo.ic,
                health_profession = userInfo.profession,
                body_mass = userInfo.bodyMass,
                habit = userInfo.habit,
                life_style = userInfo.basicLifeStyle,
                bmi = userInfo.bmi,
                fat_content = userInfo.fat,
                stomach_fat = userInfo.stomachFat,
                muscle_content = userInfo.muscle
            };
            return await userApi.UpdateHealthInformation(request).ConfigureAwait(false);
        }
        public async Task<ProvideInforRequest> GetHealthInfor(string token)
        {
            var httpClient = new HttpClient(new HttpLoggingHandler()) { BaseAddress = URL_LOGIN };
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var userApi = RestService.For<UserApi>(httpClient);
            return await userApi.GetHealthInformation().ConfigureAwait(false);
        }
    }
}
