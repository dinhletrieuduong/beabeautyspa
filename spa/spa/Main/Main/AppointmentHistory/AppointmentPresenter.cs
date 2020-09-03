using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using spa.Base;
using spa.Data;
using spa.Data.Model.Appointment;
using spa.Main.AppointmentDetail;
using spa.Main.AppointmentHistory;
using spa.Navigation;

namespace spa.Main.AppointmentHistory
{
    public class AppointmentPresenter : BasePresenter
    {
        private IAppointmentView m_view;
        private DataManager dataManager;

        public AppointmentPresenter(INavigationService navigationService) :
            base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IAppointmentView view)
        {
            m_view = view;
        }

        public void GoToAppointmentDetail()
        {
            navigationService.PushPresenter(new AppointmentDetailPresenter(navigationService));
        }
        public List<Appointment> GetAllAppointmentHistory()
        {
            List<Appointment> list = new List<Appointment>();
            Task.Factory.StartNew(() => list = dataManager.GetAppointmentRepository().GetAppointmentHistory(dataManager.GetToken()))
                .ContinueWith(task =>
                {
                    //m_view.updateListService(services);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            return list;
        }
    }
}
