﻿using System;
using spa.Base;
using spa.Navigation;

namespace spa.PersonalCart
{
    public class PersonalCartPresenter : BasePresenter
    {
        private IPersCartView m_view;

        public PersonalCartPresenter(INavigationService navigationService) :
            base(navigationService)
        {
        }

        public void SetView(IPersCartView view)
        {
            m_view = view;
        }

    }
}
