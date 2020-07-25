using System;
using System.Runtime.CompilerServices;
using Android.Preferences;
using spa.Data.Model.User;
using spa.Data.Model.User.Source.Remote;

namespace spa.Data
{
    public class DataManager
    {
        private static DataManager sInstance;

        SharedPrefsHelper mSharedPrefsHelper;

        public DataManager() { }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static DataManager GetInstance()
        {
            if (sInstance == null)
            {
                sInstance = new DataManager();
            }
            return sInstance;
        }

        public void SetSharedPrefsHelper(SharedPrefsHelper sharedPrefsHelper)
        {
            mSharedPrefsHelper = sharedPrefsHelper;
        }

        public UserRepository GetUserRepository()
        {
            UserApi userApi = UserService.GetInstance().GetUserApi();
            //    UserRemoteDataSource movieRemote = UserRemoteDataSource.getInstance(movieApi);
            //    UsersRepository movieCache = MovieCacheDataSource.getsInstance();
            return UserRepository.GetInstance(userApi);
        }
    }
}
