using System;
using spa.Data.Model.User;
using Refit;
using System.Threading.Tasks;

namespace spa.Data.Model.User.Source.Remote
{
    public interface UserApi
    {
        [Post("/login")]
        Task<User> Login();

        [Post("/register")]
        Task<User> Register();

        [Post("/update")]
        Task<User> Update();

        [Get("/profile")]
        Task<UserResponse> Profile();
    }
}
