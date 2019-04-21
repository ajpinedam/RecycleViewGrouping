using System;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace GroupedListView
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private RecyclerView _recyclerView;
        private RecyclerView.LayoutManager _layoutManager;
        private MyDataGroupedAdapter _dataAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);

            _recyclerView = FindViewById<RecyclerView>(Resource.Id.rv_my_data);

            _layoutManager = new LinearLayoutManager(this);

            var data = GetMyData();
            _dataAdapter = new MyDataGroupedAdapter(data);

            _recyclerView.SetLayoutManager(_layoutManager);
            _recyclerView.SetAdapter(_dataAdapter);

            fab.Click += FabOnClick;
        }

        private IList<MyData> GetMyData()
        {
            var data = new List<MyData> 
            {
                new MyData{ City ="Montreal", Country="Canada", Population=5500 },
                new MyData{ City ="Toronto", Country="Canada", Population=9500 },
                new MyData{ City ="Santo Domingo", Country="Dominican Republic", Population=4300 },
                new MyData{ City ="New York", Country="United States", Population=102700 },
                new MyData{ City ="Santiago", Country="Chile", Population=4800 },
                new MyData{ City ="New Jersey", Country="United States", Population=6140 },
                new MyData{ City ="Acapulco", Country="Mexico", Population=5600 },
                new MyData{ City ="Boston", Country="United States", Population=8640 },
                new MyData{ City ="Santiago", Country="Dominican Republic", Population=4900 },
                new MyData{ City ="Punta Cana", Country="Dominican Republic", Population=3320 },
                new MyData{ City ="San Diego", Country="United States", Population=3320 },
            };

            return data;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}

