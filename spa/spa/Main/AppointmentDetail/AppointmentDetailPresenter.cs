using System;
using spa.Base;
using spa.Main.AppointmentHistory;
using spa.Navigation;

namespace spa.Main.AppointmentDetail
{
    public class AppointmentDetailPresenter : BasePresenter
    {
        private IAppointmentDetailView m_view;

        public AppointmentDetailPresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IAppointmentDetailView view)
        {
            m_view = view;
        }

        public void GoBackToAppointmentHistory()
        {
            navigationService.PushPresenter(new AppointmentPresenter(navigationService));
        }

    }
}
