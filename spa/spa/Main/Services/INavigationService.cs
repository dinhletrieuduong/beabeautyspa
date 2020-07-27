using System;
using spa.Presenters;

namespace spa.Services
{
    public interface INavigationService
    {
        void PushPresenter(BasePresenter presenter);
    }
}
