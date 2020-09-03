using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using spa.Data.Model.Appointment;
using spa.Navigation;

namespace spa.Main.AppointmentHistory
{
    [Obsolete]
    public class AppointmentFragment : Fragment, IAppointmentView
    {
        public RecyclerView recyclerView;
        List<Appointment> appointmentsList;
        AppointmentHistoryAdapter adapter;
        AppointmentPresenter presenter;

        public static AppointmentFragment NewInstance(String param1, String param2)
        {
            AppointmentFragment fragment = new AppointmentFragment();
            Bundle args = new Bundle();
            //        args.putString(ARG_PARAM1, param1);
            fragment.Arguments = args;
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View view = inflater.Inflate(Resource.Layout.fragment_appointment, container, false);

            presenter = new AppointmentPresenter(new NavigationService(Activity.Application));
            presenter.GetAllAppointmentHistory();

            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.AppointmentList);

            string mDate = "2020/03/17";
            string mOutDate;
            FormatDateString(mDate, out mOutDate);
            appointmentsList = new List<Appointment>();
            appointmentsList.Add(new Appointment(mOutDate, ChangeIntToStringComma(15000000)));
            appointmentsList.Add(new Appointment(mOutDate, ChangeIntToStringComma(15000000)));
            appointmentsList.Add(new Appointment(mOutDate, ChangeIntToStringComma(15000000)));

            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(Context);
            adapter = new AppointmentHistoryAdapter(appointmentsList, Context, presenter);
            recyclerView.SetAdapter(adapter);
            recyclerView.SetLayoutManager(linearLayoutManager);

            return view;
        }

        public bool IsPerformingAction { get; private set; }

        public void OnActionStarted()
        {
            IsPerformingAction = true;
        }

        public void OnActionFinished()
        {
            IsPerformingAction = false;
        }

        public bool IsNavigating { get; private set; }

        public void OnNavigationStarted()
        {
            IsNavigating = true;
        }

        //public void updateListAppointment(List<Data.Model.Service.Service> services)
        //{
        //adapter = new ServiceAdapter(services);
        //recyclerView.SetAdapter(adapter);
        //}

        public string ChangeIntToStringComma(int a)
        {
            string input = a.ToString();
            List<char> re = new List<char>();
            for (int j = 1, i = input.Length - 1; i >= 0; ++j)
            {
                if (j % 4 == 0)
                {
                    //re.Add(' ');
                    re.Add(',');
                    //re.Add(' ');
                    continue;
                }
                re.Add(input[i]);
                i--;
            }

            char[] charArray = re.ToArray();
            Array.Reverse(charArray);
            string result = new string(charArray);
            return result;
        }

        public string ReverseString(string input)
        {
            char[] tmp = input.ToCharArray();
            Array.Reverse(tmp);
            return new string(tmp);
        }


        public bool FormatDateString(string inputDate, out string outputdate)
        {
            DateTime dateValue;
            if (DateTime.TryParse(inputDate, out dateValue))
            {
                dateValue = DateTime.Parse(inputDate);
                outputdate = dateValue.ToString("dd/MM/yyyy");
                return true;
            }
            outputdate = null;
            return false;
        }
    }
}
