using System;
using spa.Base;
using spa.Navigation;
using spa.Utils;
using spa.Verification;

namespace spa.ProvideInfor
{
    public class ProvideInforPresenter : BasePresenter
    {
        private IProvideInforView view;
        private string weight;
        private string height;
        private string ic;
        private string professional;
        private string basicLifeStyle;
        private string habit;
        private string bodyMass;
        private string bmi;
        private string fat;
        private string muscle;
        private string stomachFat;

        public ProvideInforPresenter(INavigationService navigationService) : base(navigationService)
        {
        }

        public void SetVIew(IProvideInforView v)
        {
            view = v;
        }

        private void ValidateInput()
        {
            //Check input valid on each edit text
            //m_view.OnInputValidated(HasValidInput());
        }

        public void UpdateWeight(string weight)
        {
            this.weight = weight;
            ValidateInput();
        }

        public void UpdateHeight(string height)
        {
            this.height = height;
            ValidateInput();
        }

        public void UpdateIC(string ic)
        {
            this.ic = ic;
            ValidateInput();
        }

        public void UpdateProfessional(string professional)
        {
            this.professional = professional;
            ValidateInput();
        }

        public void UpdateBasicLifeStyle(string basicLifeStyle)
        {
            this.basicLifeStyle = basicLifeStyle;
            ValidateInput();
        }

        public void UpdateHabit(string habit)
        {
            this.habit = habit;
            ValidateInput();
        }

        public void UpdateBodyMass(string bodyMass)
        {
            this.bodyMass = bodyMass;
            ValidateInput();
        }

        public void UpdateBmi(string bmi)
        {
            this.bmi = bmi;
            ValidateInput();
        }

        public void UpdateFat(string fat)
        {
            this.fat = fat;
            ValidateInput();
        }

        public void UpdateMuscle(string muscle)
        {
            this.muscle = muscle;
            ValidateInput();
        }

        public void UpdateStomachFat(string stomachFat)
        {
            this.stomachFat = stomachFat;
            ValidateInput();
        }

        private bool HasValidInput()
        {
            return CheckInputValid.isHeightValid(height) &&
                CheckInputValid.isWeightValid(weight) &&
                CheckInputValid.isICValid(ic) &&
                CheckInputValid.isProfessionValid(professional);
        }

        public void ProvideInfor()
        {
            if (!view.IsNavigating && !view.IsPerformingAction)
            {
                view.OnNavigationStarted();
                NavigationService.PushPresenter(new VerificationPresenter(NavigationService));
            }
        }
    }
}
