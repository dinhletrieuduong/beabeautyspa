using System;
using System.Collections.Generic;
using spa.Base;
using spa.Navigation;

namespace spa.Main.MakeAppointment
{
    public interface IMakeAppointmentView : IBaseView, INavigationView
    {
        void updateListTherapist(List<Data.Model.Therapist.Therapist> therapists);
        void updateListPreOrder(List<Data.Model.PreOrder.PreOrder> preOrders);
    }
}
