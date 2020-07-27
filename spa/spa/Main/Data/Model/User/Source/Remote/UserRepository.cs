using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace spa.Data.Model.User.Source.Remote
{
    public class UserRepository : IUserDataSource
    {
        private UserRepository userRemote;

        private static UserRepository instance;
        private UserApi userApi;

        private UserRepository(UserApi userApi)
        {
            this.userApi = userApi;
        }
        private UserRepository(UserRepository userRemote)
        {
            this.userRemote = userRemote;
        }
        public static UserRepository GetInstance(UserApi userApi)
        {
            if (instance == null)
            {
                instance = new UserRepository(userApi);
            }
            return instance;
        }

        public int Login(User user, bool isLoginBySocial)
        {
            var response = isLoginBySocial ? userApi.LoginSocial(user) : userApi.LoginManual(user);
            try
            {
                response.Wait();
                int statusCode = int.Parse(response.Result.ToString().Split(",")[0].Split(":")[1].Trim());
                Debug.WriteLine(response.Result.ToString());
                Debug.WriteLine(statusCode.ToString());
                //string reasonPhase = response.Result.ToString().Split(",")[1];
                //Dictionary<string, string> dict = new Dictionary<string, string>();
                //dict.Add("statusCode", statusCode);
                return statusCode;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Request Timeout");
                return 500;

            }

        }

        public int Register(User user, bool isSignupBySocial)
        {
            var response = isSignupBySocial ? userApi.RegisterSocial(user) : userApi.RegisterManual(user);
            try
            {
                response.Wait();
                int statusCode = int.Parse(response.Result.ToString().Split(",")[0].Split(":")[1].Trim());
                Debug.WriteLine(response.Result.ToString());
                Debug.WriteLine(statusCode.ToString());
                //string reasonPhase = response.Result.ToString().Split(",")[1];
                //Dictionary<string, string> dict = new Dictionary<string, string>();
                //dict.Add("statusCode", statusCode);

                return statusCode;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Request Timeout");
                return 500;

            }
        }

        //public void GetProfile(IDataSource.LoadDataCallback<User> callback)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
