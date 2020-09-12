using System;
using System.Collections.Generic;
using spa.Base;
using spa.Navigation;

namespace spa.Main.MakeAppointment
{
    public interface IMakeAppointmentView : IBaseView, INavigationView
    {
        void updateListService(List<Data.Model.Service.Service> services);
    }
}
