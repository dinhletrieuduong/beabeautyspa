using System;
using Android.Preferences;

namespace spa.Data
{
    public class DataManager
    {
        private static DataManager sInstance;

        private DataManager()
        {
        }
        public static DataManager getInstance()
        {
            if (sInstance == null)
            {
                sInstance = new DataManager();
            }
            return sInstance;
        }
        //public Preference GetDefaultPreference()
        //{
        //    return PowerPreference.getDefaultFile();
        //}

        //public Preference getUserPreference() { return PowerPreference.getFileByName("UserPreference"); }

        //public MoviesRepository getMovieRepository()
        //{

        //    MovieApi movieApi = MovieService.getInstance().getMovieApi();
        //    MovieRemoteDataSource movieRemote = MovieRemoteDataSource.getInstance(movieApi);

        //    MovieDao movieDao = MovieDatabase.getInstance().movieDao();
        //    MovieLocalDataSource movieLocal = MovieLocalDataSource.getInstance(movieDao);

        //    MovieCacheDataSource movieCache = MovieCacheDataSource.getsInstance();

        //    return MoviesRepository.getInstance(movieRemote, movieLocal, movieCache);
        //}
    }
}
