
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using spa.Navigation;

namespace spa.ProvideInfor
{
    [Activity(Label = "ProvideInforActivity")]
    public class ProvideInforActivity : Activity, IProvideInforView
    {
        private ProvideInforPresenter presenter;
        private EditText edtProfession;
        private EditText edtIC;
        private EditText edtWeight;
        private EditText edtHeight;
        private EditText edtLifeStyle;
        private EditText edtHabit;
        private EditText edtBodyMass;
        private EditText edtBmi;
        private EditText edtMuscle;
        private EditText edtFat;
        private EditText edtStomachFat;
        private Button btnFinish;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.activity_provide_infor);

            presenter = new ProvideInforPresenter(new NavigationService(this.Application));
            presenter.SetView(this);

            edtProfession = FindViewById<EditText>(Resource.Id.edtProfession);
            edtProfession.TextChanged += edtProfession_TextChanged;
            edtIC = FindViewById<EditText>(Resource.Id.edtIC);
            edtIC.TextChanged += edtIC_TextChanged;
            edtWeight = FindViewById<EditText>(Resource.Id.edtWeight);
            edtWeight.TextChanged += edtWeight_TextChanged;
            edtHeight = FindViewById<EditText>(Resource.Id.edtHeight);
            edtHeight.TextChanged += edtHeight_TextChanged;
            edtLifeStyle = FindViewById<EditText>(Resource.Id.edtBasicLifestyle);
            edtLifeStyle.TextChanged += edtLifeStyle_TextChanged;
            edtHabit = FindViewById<EditText>(Resource.Id.edtHabit);
            edtHabit.TextChanged += edtHabit_TextChanged;
            edtBodyMass = FindViewById<EditText>(Resource.Id.edtBodyMass);
            edtBodyMass.TextChanged += edtBodyMass_TextChanged;
            edtBmi = FindViewById<EditText>(Resource.Id.edtBmi);
            edtBmi.TextChanged += edtBmi_TextChanged;
            edtMuscle = FindViewById<EditText>(Resource.Id.edtMuscle);
            edtMuscle.TextChanged += edtMuscle_TextChanged;
            edtFat = FindViewById<EditText>(Resource.Id.edtFat);
            edtFat.TextChanged += edtFat_TextChanged;
            edtStomachFat = FindViewById<EditText>(Resource.Id.edtStomachFat);
            edtStomachFat.TextChanged += edtStomachFat_TextChanged;

            btnFinish = FindViewById<Button>(Resource.Id.btnFinish);
            btnFinish.Click += delegate { presenter.ProvideInfor(); };
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

        public void OnInputValidated(bool isValid)
        {
            //throw new NotImplementedException();
        }

        public void OnProvideFailed(int statusCode, string errorMessage)
        {
            throw new NotImplementedException();
        }

        private void edtProfession_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateProfessional(e.Text.ToString());
        }
        private void edtIC_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateProfessional(e.Text.ToString());
        }
        private void edtWeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateWeight(int.Parse(e.Text.ToString()));
        }
        private void edtHeight_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateHeight(int.Parse(e.Text.ToString()));
        }
        private void edtLifeStyle_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateBasicLifeStyle(e.Text.ToString());
        }
        private void edtHabit_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateHabit(e.Text.ToString());
        }
        private void edtBodyMass_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateBodyMass(int.Parse(e.Text.ToString()));
        }
        private void edtBmi_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateBmi(int.Parse(e.Text.ToString()));
        }
        private void edtMuscle_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateMuscle(int.Parse(e.Text.ToString()));
        }
        private void edtFat_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateFat(int.Parse(e.Text.ToString()));
        }
        private void edtStomachFat_TextChanged(object sender, TextChangedEventArgs e)
        {
            presenter.UpdateStomachFat(int.Parse(e.Text.ToString()));
        }
    }
}
