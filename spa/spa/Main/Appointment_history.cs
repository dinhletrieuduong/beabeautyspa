using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;
using Android.Text;
using System;

namespace AppointmentHustory
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public RecyclerView recyclerView;
        List<Appointment> appointmentsList;
        AppointmentHistoryAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarAppointmentHistory);
            SetSupportActionBar(toolbar);
            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);
            toolbar.NavigationClick += delegate { backButtonClick(); };

            recyclerView = FindViewById<RecyclerView>(Resource.Id.AppointmentList);

            string mDate = "2020/03/17";
            string mOutDate;
            FormatDateString(mDate, out mOutDate);
            appointmentsList = new List<Appointment>();
            appointmentsList.Add(new Appointment(mOutDate, ChangeIntToStringComma(15000000)));
            appointmentsList.Add(new Appointment(mOutDate, ChangeIntToStringComma(15000000)));
            appointmentsList.Add(new Appointment(mOutDate, ChangeIntToStringComma(15000000)));

            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);
            adapter = new AppointmentHistoryAdapter(appointmentsList, this);
            recyclerView.SetAdapter(adapter);
            recyclerView.SetLayoutManager(linearLayoutManager);
        }

        public void backButtonClick()
        {
            Android.Widget.Toast.MakeText(this, "Back button clicked", Android.Widget.ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

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