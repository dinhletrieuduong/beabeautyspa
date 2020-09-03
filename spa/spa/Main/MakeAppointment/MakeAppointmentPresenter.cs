using System;
using spa.Base;
using spa.Data;
using spa.AddService;
using spa.Navigation;

namespace spa.Main.MakeAppointment
{
    public class MakeAppointmentPresenter : BasePresenter
    {
        DataManager dataManager;
        public string location { get; set; }
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
