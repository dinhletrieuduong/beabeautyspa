using System;
using spa.Base;
using spa.Main.AppointmentHistory;
using spa.Navigation;

namespace spa.Main.AddService
{
    public class AddServicePresenter : BasePresenter
    {
        private IAddServiceView m_view;

        public AddServicePresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IAddServiceView view)
        {
            m_view = view;
        }

        //public void GoBackToAppointmentHistory()
        //{
        //    navigationService.PushPresenter(new AppointmentPresenter(navigationService));
        //}

    }
}
