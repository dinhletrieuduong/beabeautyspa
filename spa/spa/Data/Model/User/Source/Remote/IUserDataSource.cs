using System;
using System.Collections.Generic;

namespace spa.Data.Model.User.Source.Remote
{
    public interface IUserDataSource : IDataSource
    {
        Tuple<string, string, bool> Login(User user);
        //bool Register(User user);
        void GetProfile(IDataSource.LoadDataCallback<User> callback);
    }
}
