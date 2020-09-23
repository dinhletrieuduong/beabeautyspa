using System;
using spa.Navigation;
using spa.Base;
using spa.Login;
using spa.Data;
using System.Threading.Tasks;
using spa.Data.Model.User;

namespace spa.Main.Account
{
    public class AccountPresenter : BasePresenter
    {
        private IAccountView m_view;
        private DataManager dataManager;
        public AccountPresenter(INavigationService navigationService) :
            base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void SetView(IAccountView view)
        {
            m_view = view;
        }

        public void LogOut()
        {
            if (!m_view.IsNavigating)
            {
                dataManager.ClearToken();
                m_view.OnNavigationStarted();
                navigationService.PushPresenter(new LoginPresenter(navigationService));
            }
        }

        public void GetHealthInformation()
        {
            //List<Appointment> list = new List<Appointment>();
            Task.Factory.StartNew(() => dataManager.GetUserRepository().GetHealthInformation(dataManager.GetToken()))
                .ContinueWith(task =>
                {
                    //m_view.updateListService(services);
                }, TaskScheduler.FromCurrentSynchronizationContext());

        }
        public void UpdateHealthInfor(HealthInfor health)
        {
            //List<Appointment> list = new List<Appointment>();
            Task.Factory.StartNew(() => dataManager.GetUserRepository().UpdateHealthInformation(health, dataManager.GetToken()))
                .ContinueWith(task =>
                {
                    //m_view.updateListService(services);
                }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public void GetProfile()
        {
            User user = new User();
            Task.Factory.StartNew(() => user = dataManager.GetUserRepository().GetProfile(dataManager.GetToken()))
                   .ContinueWith(task =>
                   {
                       m_view.updateProfile(user);
                   }, TaskScheduler.FromCurrentSynchronizationContext());

        }
    }
}
