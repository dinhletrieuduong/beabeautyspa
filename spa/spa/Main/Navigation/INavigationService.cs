using System;
using spa.Base;

namespace spa.Navigation
{
    public interface INavigationService
    {
        void PushPresenter(BasePresenter presenter);
    }
}
