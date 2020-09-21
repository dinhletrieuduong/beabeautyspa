using System;
using spa.Base;
using spa.Data;
using spa.AddService;
using spa.Navigation;
using System.Collections.Generic;
using spa.Data.Model.Therapist;
using System.Threading.Tasks;
using spa.Data.Model.Appointment;

namespace spa.Main.MakeAppointment
{
    public class MakeAppointmentPresenter : BasePresenter
    {
        DataManager dataManager;
        private IMakeAppointmentView m_view;
        public string location { get; set; }

        public MakeAppointmentPresenter(INavigationService navigationService) : base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IMakeAppointmentView view)
        {
            m_view = view;
        }

        public void GoToAddService()
        {
            navigationService.PushPresenter(new AddServicePresenter(navigationService));
        }

        public List<Therapist> GetTherapistOutlet()
        {
            List<Therapist> list = new List<Therapist>();
            int outletID = dataManager.GetOutletID();
            Task.Factory.StartNew(() => list = dataManager.GetTherapistRepository().GetTherapistOutlet(dataManager.GetToken(), outletID))
                .ContinueWith(task =>
                {
                    m_view.updateListTherapist(list);
                    //GetPreOrderList();
                }, TaskScheduler.FromCurrentSynchronizationContext());
            return list;
        }

        public List<Data.Model.PreOrder.PreOrder> GetPreOrderList()
        {
            List<Data.Model.PreOrder.PreOrder> preOrders = new List<Data.Model.PreOrder.PreOrder>();
            int outletID = dataManager.GetOutletID();
            Task.Factory.StartNew(() => preOrders = dataManager.GetPreOrderRepository().GetPreOrderList(dataManager.GetToken(), outletID))
                .ContinueWith(task =>
                {
                    m_view.updateListPreOrder(preOrders);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            return preOrders;
        }

        public void MakeAppointment(Appointment appointment)
        {
            Task.Factory.StartNew(() => dataManager.GetAppointmentRepository().CreateAppointment(dataManager.GetToken(), appointment))
                .ContinueWith(task =>
                {
                    //m_view.updateListService(preOrders);
                }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
