using System;

namespace spa.Data.Model.User.Source.Remote
{
    public class UserRepository : IUserDataSource
    {

        private UserRepository userRemote;
        //private UserRepository userCache;

        private static UserRepository instance;
        private UserApi userApi;

        private UserRepository(UserApi userApi)
        {
            this.userApi = userApi;
        }
        private UserRepository(UserRepository userRemote
            //MovieCacheDataSource movieCache
            )
        {
            this.userRemote = userRemote;
        }
        public static UserRepository getInstance(UserApi userApi)
        {
            if (instance == null)
            {
                instance = new UserRepository(userApi);
            }
            return instance;
        }

        public void Login(IUserDataSource.LoadDataCallback<User> callback)
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
