using System.Collections.Generic;
using System.Threading.Tasks;
using spa.Base;
using spa.Data;
using spa.Navigation;

namespace spa.AddService
{
    public class AddServicePresenter : BasePresenter
    {
        private IAddServiceView m_view;
        DataManager dataManager;

        public AddServicePresenter(INavigationService navigationService) :
            base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IAddServiceView view)
        {
            m_view = view;
        }

        public List<Data.Model.Service.Service> GetServicesByOutlet()
        {
            int outletID = dataManager.GetOutletID();

            List<Data.Model.Service.Service> services = new List<Data.Model.Service.Service>();
            Task.Factory.StartNew(() => services = dataManager.GetServiceRepository().GetServicesByOutlet(dataManager.GetToken(), outletID))
                .ContinueWith(task =>
                {
                    m_view.updateListService(services);

                }, TaskScheduler.FromCurrentSynchronizationContext());
            return services;
        }

        public List<Data.Model.PreOrder.PreOrder> AddPreOrderItem(int serviceID)
        {
            int outletID = dataManager.GetOutletID();

            List<Data.Model.PreOrder.PreOrder> preOrders = new List<Data.Model.PreOrder.PreOrder>();
            Task.Factory.StartNew(() => dataManager.GetPreOrderRepository().AddPreOrderItem(dataManager.GetToken(), outletID, serviceID))
                .ContinueWith(task =>
                {

                }, TaskScheduler.FromCurrentSynchronizationContext());
            return preOrders;
        }

    }
}
