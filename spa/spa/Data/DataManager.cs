using System;
using System.Runtime.CompilerServices;
using Android.Preferences;
using spa.Data.Model.User;
using spa.Data.Model.User.Service;

namespace spa.Data
{
    public class DataManager
    {
        private static DataManager sInstance;

        SharedPrefsHelper mSharedPrefsHelper;

        public DataManager(SharedPrefsHelper sharedPrefsHelper)
        {
            mSharedPrefsHelper = sharedPrefsHelper;
        }

        public DataManager() { }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static DataManager getInstance()
        {
            if (sInstance == null)
            {
                sInstance = new DataManager();
            }
            return sInstance;
        }

        //public UsersRepository getMovieRepository()
        //{

        //    UserApi movieApi = UserService.getInstance().getUserApi();
        //    UserRemoteDataSource movieRemote = UserRemoteDataSource.getInstance(movieApi);


        //    UsersRepository movieCache = MovieCacheDataSource.getsInstance();

        //    return MoviesRepository.getInstance(movieRemote, movieLocal, movieCache);
        //}
    }
}
