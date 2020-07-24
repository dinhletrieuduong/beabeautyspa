using System;
using spa.Data.Model.User;
using spa.Data.Model.User.Source.Remote;
namespace spa.Data.Model
{
    public class RepositoryDataSource : Repository
    {
        private UserRemoteDataSource userRemote;
        private UserRemoteDataSource userCache;

        private static RepositoryDataSource instance;

        private RepositoryDataSource(UserRemoteDataSource movieRemote,
                                 UserRemoteDataSource movieCache)
        {

            this.userRemote = movieRemote;
            this.userCache = movieCache;
        }

        public static RepositoryDataSource getInstance(UserRemoteDataSource movieRemote,
                                                   UserRemoteDataSource movieCache)
        {
            if (instance == null)
            {
                instance = new RepositoryDataSource(movieRemote, movieCache);
            }
            return instance;
        }

        //public void getMovies(IDataSource.LoadDataCallback<User.User> callback)
        //{
        //if (callback == null) return;

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

        //}

        //public void saveMovies(List<User> users)
        //{
        //    movieLocal.saveMovies(movies);
        //}

        //private void getMoviesFromRemoteDataSource(IDataSource.LoadDataCallback<User.User> callback)
        //{
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
        //}

        //private void refreshCache(List<Movie> movies)
        //{
        //    movieCache.saveMovies(movies);
        //}

        public void destroyInstance()
        {
            instance = null;
        }

        public void Login(IDataSource.LoadDataCallback<User.User> callback)
        {
            throw new NotImplementedException();
        }

        public void updateUserInfo(User.User user, IDataSource.LoadDataCallback<User.User> callback)
        {
            throw new NotImplementedException();
        }
    }
}
