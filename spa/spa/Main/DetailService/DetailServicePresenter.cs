using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using spa.Base;
using spa.Data;
using spa.Main.AppointmentHistory;
using spa.Navigation;

namespace spa.Main.DetailService
{
    public class DetailServicePresenter : BasePresenter
    {
        private IDetailServiceView m_view;
        private DataManager dataManager;
        public DetailServicePresenter(INavigationService navigationService) :
            base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IDetailServiceView view)
        {
            m_view = view;
        }

        //public void GoBackToAppointmentHistory()
        //{
        //    navigationService.PushPresenter(new AppointmentPresenter(navigationService));
        //}

        public List<Data.Model.Service.Service> GetServiceDetail()
        {
            int serviceID = dataManager.GetServiceID();
            List<Data.Model.Service.Service> services = new List<Data.Model.Service.Service>();
            Task.Factory.StartNew(() => services = dataManager.GetServiceRepository().GetServiceDetail(dataManager.GetToken(), serviceID))
                .ContinueWith(task =>
                {
                    m_view.updateServiceDetail(services[0]);

                }, TaskScheduler.FromCurrentSynchronizationContext());
            return services;
        }
    }
}
