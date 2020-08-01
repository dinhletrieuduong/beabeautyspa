using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Support.V7.Widget;
using System.Collections.Generic;

namespace PersonalCart
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        RecyclerView RecyclerView;
        List<Cart> CartsList;
        PersonalCartAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbarPersonalCart);
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = " ";
            toolbar.SetNavigationIcon(Resource.Drawable.abc_ic_ab_back_material);
            toolbar.NavigationClick += delegate { BackButtonClick(); };

            /*CartsListView = FindViewById<ListView>(Resource.Id.lvCarts);

            Carts = new List<string>();
            Carts.Add("Massage");
            Carts.Add("Foot massage");
            Carts.Add("facial massage");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, Carts);
            CartsListView.Adapter = adapter;*/

            RecyclerView = FindViewById<RecyclerView>(Resource.Id.cartsList);
            CartsList = new List<Cart>();
            CartsList.Add(new Cart("Foot Massage", 60));
            CartsList.Add(new Cart("Facial Massage", 60));
            CartsList.Add(new Cart("Body Massage", 60));

            adapter = new PersonalCartAdapter(CartsList, this);
            LinearLayoutManager linearLayoutManager = new LinearLayoutManager(this);

            RecyclerView.SetAdapter(adapter);
            RecyclerView.SetLayoutManager(linearLayoutManager);
        }

        public void BackButtonClick ()
        {
            Android.Widget.Toast.MakeText(this, "Back button clicked", Android.Widget.ToastLength.Long).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}