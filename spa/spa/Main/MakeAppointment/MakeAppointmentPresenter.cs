using System;
using spa.Base;
using spa.Data;
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
    }
}
