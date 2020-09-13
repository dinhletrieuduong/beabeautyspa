using System;
using System.Collections.Generic;

namespace spa.Data.Model.User.Source.Remote
{
    public interface IUserDataSource : IDataSource
    {
        Dictionary<int, string> Login(User user, bool isLoginBySocial);
        Dictionary<int, string> Register(User user, bool isSignupBySocial);
        Dictionary<int, string> Verify(User user);

        //void GetProfile(IDataSource.LoadDataCallback<User> callback);
    }
}
