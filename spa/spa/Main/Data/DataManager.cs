using System;
using System.Runtime.CompilerServices;
using Android.Preferences;
using spa.Data.Model.Outlet.Source.Remote;
using spa.Data.Model.Service.Source.Remote;
using spa.Data.Model.User;
using spa.Data.Model.User.Source.Remote;

namespace spa.Data
{
    public class DataManager
    {
        private static DataManager sInstance;

        private SharedPrefsHelper mSharedPrefsHelper;

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
            UserService userService = UserService.GetInstance();
            //    UserRemoteDataSource userRemote = UserRemoteDataSource.getInstance(movieApi);
            //    UsersRepository userCache = MovieCacheDataSource.getsInstance();
            return UserRepository.GetInstance(userService);
        }
        public ServiceRepository GetServiceRepository()
        {
            ServiceService serviceService = ServiceService.GetInstance();
            return ServiceRepository.GetInstance(serviceService);
        }
        public OutletRepository GetOutletRepository()
        {
            OutletService service = OutletService.GetInstance();
            return OutletRepository.GetInstance(service);
        }

        public string GetToken()
        {
            return mSharedPrefsHelper.getToken();
        }

        public void SetToken(string token)
        {
            mSharedPrefsHelper.putToken(token);
        }
        public void ClearToken()
        {
            if (!string.IsNullOrEmpty(mSharedPrefsHelper.getToken()))
                mSharedPrefsHelper.clearToken();
        }
    }
}
