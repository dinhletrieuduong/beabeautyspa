using System;
using spa.Data.Model.User;
using spa.Navigation;

namespace spa.Main.Account
{
    public interface IAccountView : IMainView, INavigationView
    {
        void updateProfile(User user);
    }
}
