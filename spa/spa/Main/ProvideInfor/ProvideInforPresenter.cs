using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using spa.Base;
using spa.Data;
using spa.Data.Model.User;
using spa.Main;
using spa.Navigation;
using spa.Utils;
using spa.Verification;

namespace spa.ProvideInfor
{
    public class ProvideInforPresenter : BasePresenter
    {
        private IProvideInforView view;
        DataManager dataManager;
        private int weight;
        private int height;
        private int ic;
        private string profession;
        private string basicLifeStyle;
        private string habit;
        private int bodyMass;
        private float bmi;
        private int fat;
        private int muscle;
        private int stomachFat;

        public ProvideInforPresenter(INavigationService navigationService) : base(navigationService)
        {
            dataManager = DataManager.GetInstance();
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

        public void UpdateWeight(int weight)
        {
            this.weight = weight;
            ValidateInput();
        }

        public void UpdateHeight(int height)
        {
            this.height = height;
            ValidateInput();
        }

        public void UpdateIC(int ic)
        {
            this.ic = ic;
            ValidateInput();
        }

        public void UpdateProfessional(string profession)
        {
            this.profession = profession;
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

        public void UpdateBodyMass(int bodyMass)
        {
            this.bodyMass = bodyMass;
            ValidateInput();
        }

        public void UpdateBmi(float bmi)
        {
            this.bmi = bmi;
            ValidateInput();
        }

        public void UpdateFat(int fat)
        {
            this.fat = fat;
            ValidateInput();
        }

        public void UpdateMuscle(int muscle)
        {
            this.muscle = muscle;
            ValidateInput();
        }

        public void UpdateStomachFat(int stomachFat)
        {
            this.stomachFat = stomachFat;
            ValidateInput();
        }

        private bool HasValidInput()
        {
            return CheckInputValid.isHeightValid(height) &&
                CheckInputValid.isWeightValid(weight) &&
                CheckInputValid.isICValid(ic) &&
                CheckInputValid.isProfessionValid(profession);
        }

        public void ProvideInfor()
        {
            int isValidInfor = CheckInputValid.ProvideInformationCheckInputValid(
                    profession, ic, weight, height);

            if (isValidInfor != 0)
            {
                view.OnProvideFailed(400, isValidInfor.ToString());
                return;
            }

            if (!view.IsNavigating && !view.IsPerformingAction && HasValidInput())
            {
                UserInfor userInfor = new UserInfor(
                    profession, ic, weight, height, basicLifeStyle, habit, bodyMass, bmi, fat, muscle, stomachFat);

                view.OnActionStarted();
                var userRepository = dataManager.GetUserRepository();

                Dictionary<int, string> resp = new Dictionary<int, string>();
                Task.Factory.StartNew(() =>
                {
                    resp = userRepository.ProvideInfor(userInfor);
                }).ContinueWith(task =>
                {
                    view.OnActionFinished();

                    if (resp.ContainsKey(200))
                    {
                        view.OnNavigationStarted();
                        navigationService.PushPresenter(new MainPresenter(navigationService));
                    }
                    else
                    {
                        view.OnProvideFailed(500, "There was a problem creating your information, please try again later.");
                    }

                }, TaskScheduler.FromCurrentSynchronizationContext());


            }
        }
    }
}
