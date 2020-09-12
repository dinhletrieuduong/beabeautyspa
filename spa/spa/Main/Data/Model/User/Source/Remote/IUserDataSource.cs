using System;
using System.Collections.Generic;

namespace spa.Data.Model.User.Source.Remote
{
    public interface IUserDataSource : IDataSource
    {
        Dictionary<int, string> Login(User user, bool isLoginBySocial);
        Dictionary<int, string> Register(User user, bool isSignupBySocial);
        Dictionary<int, string> Verify(User user);
        HealthInfor GetHealthInformation(string token);
        Dictionary<int, string> UpdateHealthInformation(HealthInfor user, string token);

        //void GetProfile(IDataSource.LoadDataCallback<User> callback);
    }
}
