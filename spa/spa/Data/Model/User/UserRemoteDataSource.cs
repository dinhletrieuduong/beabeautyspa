using System;
using spa.Data.Model.User.Service;

namespace spa.Data.Model.User
{
    public class UserRemoteDataSource : UserDataSource
    {
        private static UserRemoteDataSource instance;

        private UserApi userApi;
        public UserRemoteDataSource()
        {
        }

        private UserRemoteDataSource(UserApi userApi)
        {
            this.userApi = userApi;
        }

        public static UserRemoteDataSource getInstance(UserApi userApi)
        {
            if (instance == null)
            {
                instance = new UserRemoteDataSource(userApi);
            }
            return instance;
        }

        public void Login(UserDataSource.LoadUserCallBack callback)
        {
            //    userApi.Login().enqueue(new Callback<UserResponse>()
            //    {
            //    public void onResponse(Call<UserResponse> call, Response<UserResponse> response)
            //    {
            //        List<User> movies = response.body() != null ? response.body().getMovies() : null;
            //        if (movies != null && !movies.isEmpty())
            //        {
            //            callback.onMoviesLoaded(movies);
            //        }
            //        else
            //        {
            //            callback.onDataNotAvailable();
            //        }
            //    }

            //    public void onFailure(Call<UserResponse> call, Throwable t)
            //    {
            //        callback.onError();
            //    }
            //});
        }

        //public void saveMovies(List<User> movies)
        //{
        //    //doNothing
        //}
    }
}
