using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using spa.Base;
using spa.Data;
using spa.Data.Model.PreOrder;
using spa.AddService;
using spa.Main.MakeAppointment;
using spa.Navigation;
using Android.Content;

namespace spa.Main.PreOrder
{
    public class PersonalCartPresenter : BasePresenter
    {
        private IPersonalCartView m_view;
        private DataManager dataManager;
        public PersonalCartPresenter(INavigationService navigationService) :
            base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IPersonalCartView view)
        {
            m_view = view;
        }

        public void GoToMakeAppointment()
        {
            navigationService.PushPresenter(new MakeAppointmentPresenter(navigationService));
        }

        public void GoToAddService()
        {
            navigationService.PushPresenter(new AddServicePresenter(navigationService));
        }

        public List<Data.Model.PreOrder.PreOrder> GetPreOrderList()
        {
            List<Data.Model.PreOrder.PreOrder> preOrders = new List<Data.Model.PreOrder.PreOrder>();
            int outletID = dataManager.GetOutletID();
            Task.Factory.StartNew(() => preOrders = dataManager.GetPreOrderRepository().GetPreOrderList(dataManager.GetToken(), outletID))
                .ContinueWith(task =>
                {
                    m_view.updateListService(preOrders);
                }, TaskScheduler.FromCurrentSynchronizationContext());
            return preOrders;
        }

        public void DeletePreOrderItem(int serviceID)
        {
            //List<Data.Model.PreOrder.PreOrder> preOrders = new List<Data.Model.PreOrder.PreOrder>();
            //int outletID = dataManager.GetOutletID();
            m_view.updateListService(serviceID);
            int outletID = dataManager.GetOutletID();
            Task.Factory.StartNew(() => dataManager.GetPreOrderRepository().DeletePreOrderItem(dataManager.GetToken(), outletID, serviceID))
                .ContinueWith(task =>
                {
                }, TaskScheduler.FromCurrentSynchronizationContext());
            //return preOrders;
        }
    }
}
