using System;
using spa.Base;
using spa.Data;
using spa.Main.AddService;
using spa.Navigation;

namespace spa.Main.MakeAppointment
{
    public class MakeAppointmentPresenter : BasePresenter
    {
        DataManager dataManager;

        public MakeAppointmentPresenter(INavigationService navigationService) : base(navigationService)
        {
            dataManager = DataManager.GetInstance();
        }

        public void GoToAddService()
        {
            navigationService.PushPresenter(new AddServicePresenter(navigationService));
        }
    }
}
