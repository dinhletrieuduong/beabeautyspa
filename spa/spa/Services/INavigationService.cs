using System;
using spa.Presenter;

namespace spa.Services
{
    public interface INavigationService
    {
        void PushPresenter(BasePresenter presenter);
    }
}
