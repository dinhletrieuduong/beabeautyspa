using System;
using System.Collections.Generic;

namespace spa.Data.Model
{
    public interface IDataSource
    {
        interface LoadDataCallback<T>
        {
            void onDataLoaded(List<T> list);
            void onDataNotAvailable();
            void onError();
        }
    }
}
