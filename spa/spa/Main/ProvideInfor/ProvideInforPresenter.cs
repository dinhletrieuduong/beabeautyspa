using System;
using System.Collections.Generic;
using spa.Base;
using spa.Data;
using spa.Data.Model.User;
using spa.Main.Data.Model.User.Source;
using spa.Navigation;
using spa.Utils;
using spa.Verification;

namespace spa.ProvideInfor
{
    public class ProvideInforPresenter : BasePresenter
    {
        private IProvideInforView view;
        DataManager dataManager;
        private string weight;
        private string height;
        private string ic;
        private string profession;
        private string basicLifeStyle;
        private string habit;
        private string bodyMass;
        private string bmi;
        private string fat;
        private string muscle;
        private string stomachFat;

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
            int isValidInfor = CheckInputValid.ProvideInformationCheckInputValid(
                    profession, ic, weight, height);

            if (isValidInfor != 0)
            {
                view.OnProvideFailed(400, isValidInfor.ToString());
                return;
            }

            if (!view.IsNavigating && !view.IsPerformingAction && HasValidInput())
            {
                UserInfor userInfor = new UserInfor(profession, ic, weight, height);

                view.OnActionStarted();
                var userRepository = dataManager.GetUserRepository();

                Dictionary<int, string> resp = userRepository.Register(userInfor);

                view.OnActionFinished();

                if (resp.ContainsKey(200))
                {
                    view.OnNavigationStarted();
                    NavigationService.PushPresenter(new VerificationPresenter(NavigationService));
                }
                else
                {
                    if (resp.ContainsKey(400))
                        view.OnProvideFailed(400, "Username or Email is existed");
                    else
                        view.OnProvideFailed(500, "There was a problem creating your account, please try again later.");
                }
            }
        }
    }
}
