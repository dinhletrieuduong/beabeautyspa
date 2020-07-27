using System;
using System.Collections.Generic;

namespace spa.Data.Model.User.Source.Remote
{
    public interface IUserDataSource : IDataSource
    {
        int Login(User user, bool isLoginBySocial);
        int Register(User user, bool isSignupBySocial);

        //void GetProfile(IDataSource.LoadDataCallback<User> callback);
    }
}
