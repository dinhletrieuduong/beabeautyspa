using System;
namespace spa.Data.Model
{
    public interface Repository
    {
        void updateUserInfo(User.User user, IDataSource.LoadDataCallback<User.User> callback);

    }
}
