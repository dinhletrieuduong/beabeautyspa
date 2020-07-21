using System;
namespace spa.Data.Network
{
    public class UserService
    {
        private static String URL = "https://demo6483760.mockable.io/";

        private UserApi userApi;

        private static UserService singleton;

        private UserService()
        {
            //Retrofit mRetrofit = new Retrofit.Builder().addConverterFactory(GsonConverterFactory.create()).baseUrl(URL).build();
            //mMovieApi = mRetrofit.create(UserApi.class);
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
    }
}
