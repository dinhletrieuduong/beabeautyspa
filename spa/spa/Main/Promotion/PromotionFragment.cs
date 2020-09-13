
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using spa.Data.Promotion;
using spa.Navigation;

namespace spa.Main.PromotionsList
{
    [Obsolete]
    public class PromotionFragment : Fragment, IPromotionView
    {
        public RecyclerView recyclerView;
        List<Promotion> promotionsList;
        PromotionsListAdapter adapter;
        private PromotionPresenter presenter;

        public static PromotionFragment NewInstance(String param1, String param2)
        {
            PromotionFragment fragment = new PromotionFragment();
            Bundle args = new Bundle();
            //        args.putString(ARG_PARAM1, param1);
            fragment.Arguments = args;
            return fragment;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment
        }

        public override Android.Views.View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment_promotion, container, false);

            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.AppointmentList);

            promotionsList = new List<Promotion>();
            promotionsList.Add(new Promotion("Sale 10%", 10));
            promotionsList.Add(new Promotion("Sale 10%", 10));
            promotionsList.Add(new Promotion("Sale 10%", 10));

            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(Context);
            adapter = new PromotionsListAdapter(promotionsList, Context, presenter);
            recyclerView.SetAdapter(adapter);
            recyclerView.SetLayoutManager(linearLayoutManager);

            presenter = new PromotionPresenter(new NavigationService(this.Activity.Application));
            presenter.SetView(this);

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
    }
}
