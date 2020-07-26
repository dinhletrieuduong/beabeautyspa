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

        public Tuple<string, string, bool> Login(User user)
        {
            var response = userApi.Login(user);
            response.Wait();
            Debug.WriteLine(response.Result.ToString());
            string statusCode = response.Result.ToString().Split(",")[0];
            string reasonPhase = response.Result.ToString().Split(",")[1];
            if (response.Result.IsSuccessStatusCode)
            {
                return Tuple.Create(statusCode, reasonPhase, true);
            }
            else
                return Tuple.Create(statusCode, reasonPhase, false);

        }

        public Tuple<string, string, bool> Register(User user)
        {
            var response = userApi.Register(user);
            response.Wait();
            Debug.WriteLine(response.Result.ToString());
            string statusCode = response.Result.ToString().Split(",")[0];
            string reasonPhase = response.Result.ToString().Split(",")[1];
            if (response.Result.IsSuccessStatusCode)
            {
                return Tuple.Create(statusCode, reasonPhase, true);
            }
            else
                return Tuple.Create(statusCode, reasonPhase, false);

        }

        public void GetProfile(IDataSource.LoadDataCallback<User> callback)
        {
            throw new NotImplementedException();
        }
    }
}
