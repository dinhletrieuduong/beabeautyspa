using System;
namespace spa.Data.Model.User
{
    public interface UserDataSource
    {

        interface LoadUserCallBack
        {
            //void onMoviesLoaded(List<Movie> movies);
            void onDataNotAvailable();
            void onError();
        }

        void Login(LoadUserCallBack callback);
        //void Register(List<Movie> movies);
    }
}
