using System;
using System.Runtime.CompilerServices;
using Android.Preferences;
using spa.Data.Model.Appointment.Source.Remote;
using spa.Data.Model.Outlet.Source.Remote;
using spa.Data.Model.PreOrder.Source.Remote;
using spa.Data.Model.Service.Source.Remote;
using spa.Data.Model.Therapist.Source.Remote;
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
            ServiceService service = ServiceService.GetInstance();
            return ServiceRepository.GetInstance(service);
        }
        public OutletRepository GetOutletRepository()
        {
            OutletService service = OutletService.GetInstance();
            return OutletRepository.GetInstance(service);
        }
        public AppointmentRepository GetAppointmentRepository()
        {
            AppointmentService service = AppointmentService.GetInstance();
            return AppointmentRepository.GetInstance(service);
        }
        public PreOrderRepository GetPreOrderRepository()
        {
            PreOrderService service = PreOrderService.GetInstance();
            return PreOrderRepository.GetInstance(service);
        }
        public TherpistRepository GetTherapistRepository()
        {
            TherapistService service = TherapistService.GetInstance();
            return TherpistRepository.GetInstance(service);
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

        public void SetOutletAddress(string outletAddress)
        {
            mSharedPrefsHelper.putOutletAddress(outletAddress);
        }

        public string GetOutletAddress()
        {
            return mSharedPrefsHelper.getOutletAddress();
        }

        public void SetOutletID(int id)
        {
            mSharedPrefsHelper.putOutletID(id);
        }

        public int GetOutletID()
        {
            return mSharedPrefsHelper.getOutletID();
        }

        public void SetServiceID(int id)
        {
            mSharedPrefsHelper.putServiceID(id);
        }

        public int GetServiceID()
        {
            return mSharedPrefsHelper.getServiceID();
        }

    }
}
