using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace spa.Data.Model.User.Source.Remote
{
    public class UserService
    {
        private static string URL = "https://demo6483760.mockable.io/";

        private UserApi userApi;

        private static UserService singleton;


        private UserService()
        {
            //Retrofit mRetrofit = new Retrofit.Builder().addConverterFactory(GsonConverterFactory.create()).baseUrl(URL).build();
            //mMovieApi = mRetrofit.create(UserApi.class);
            userApi = RestService.For<UserApi>(URL);
        }

        public static UserService getInstance()
        {
            if (singleton == null)
            {
                singleton = new UserService();
            }
            return singleton;
        }

        public UserApi getUserApi()
        {
            return userApi;
        }

        public async Task<User> Login()
        {
            return await userApi.Login().ConfigureAwait(false);
        }
    }
}
