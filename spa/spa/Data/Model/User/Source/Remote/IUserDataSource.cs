using System;
namespace spa.Data.Model.User.Source.Remote
{
    public interface IUserDataSource : IDataSource
    {

        void Login(LoadDataCallback<User> callback);
        //void Register(User user);
    }
}
