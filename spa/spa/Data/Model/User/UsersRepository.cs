using System;
namespace spa.Data.Model.User
{
    public class UsersRepository : UserDataSource
    {
        private UserDataSource userRemote;
        private UserDataSource userCache;

        private static UsersRepository instance;

        private UsersRepository(UserRemoteDataSource movieRemote,
                                 UserRemoteDataSource movieCache)
        {

            this.userRemote = movieRemote;
            this.userCache = movieCache;
        }

        public static UsersRepository getInstance(UserRemoteDataSource movieRemote,
                                                   UserRemoteDataSource movieCache)
        {
            if (instance == null)
            {
                instance = new UsersRepository(movieRemote, movieCache);
            }
            return instance;
        }

        public void getMovies(UserDataSource.LoadUserCallBack callback)
        {
            if (callback == null) return;

            //    movieCache.getMovies(new UserDataSource.LoadUserCallBack()
            //    {
            //    public void onMoviesLoaded(List<Movie> movies)
            //    {
            //        callback.onMoviesLoaded(movies);
            //    }

            //    public void onDataNotAvailable()
            //    {
            //        getMoviesFromLocalDataSource(callback);
            //    }
            //    public void onError()
            //    {
            //        //not implemented in cache data source
            //    }
            //});

        }

        //public void saveMovies(List<User> users)
        //{
        //    movieLocal.saveMovies(movies);
        //}

        private void getMoviesFromLocalDataSource(UserDataSource.LoadUserCallBack callback)
        {
            //    movieLocal.getMovies(new UserDataSource.LoadUserCallBack()
            //    {
            //    public void onMoviesLoaded(List<Movie> movies)
            //    {
            //        callback.onMoviesLoaded(movies);
            //        refreshCache(movies);
            //    }

            //    public void onDataNotAvailable()
            //    {
            //        getMoviesFromRemoteDataSource(callback);
            //    }

            //    public void onError()
            //    {
            //        //not implemented in local data source
            //    }
            //});
        }

        private void getMoviesFromRemoteDataSource(UserDataSource.LoadUserCallBack callback)
        {
            //    movieRemote.getMovies(new UserDataSource.LoadUserCallBack()
            //    {
            //    public void onMoviesLoaded(List<Movie> movies)
            //    {
            //        callback.onMoviesLoaded(movies);
            //        saveMovies(movies);
            //        refreshCache(movies);
            //    }

            //    public void onDataNotAvailable()
            //    {
            //        callback.onDataNotAvailable();
            //    }

            //    public void onError()
            //    {
            //        callback.onError();
            //    }
            //});
        }

        //private void refreshCache(List<Movie> movies)
        //{
        //    movieCache.saveMovies(movies);
        //}

        public void destroyInstance()
        {
            instance = null;
        }

        public void Login(UserDataSource.LoadUserCallBack callback)
        {
            throw new NotImplementedException();
        }
    }
}
