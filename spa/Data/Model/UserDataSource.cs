using System;
namespace spa.Data.Model
{
    public interface UserDataSource
    {

        interface LoadUserCallBack
        {
            //void onMoviesLoaded(List<Movie> movies);
            void onDataNotAvailable();
            void onError();
        }

        void getMovies(UserDataSource callback);
        //void saveMovies(List<Movie> movies);
    }
}
