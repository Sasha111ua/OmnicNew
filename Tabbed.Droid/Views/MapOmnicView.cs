using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Droid.Fragging;
using System.ComponentModel;
using Android.Gms.Maps.Model;
using Android.Gms.Maps;
using OmnicTabs.Core.ViewModels;
using OmnicTabs.Core.BusinessLayer;

namespace OmnicTabs.Droid.Views
{
    [Activity(Label = "View for Child3ViewModel")]
    public class Child3View : MvxFragmentActivity, INotifyPropertyChanged
    {
        private Marker _curentLocation;
        private SupportMapFragment _mapFragment;
        private Child3ViewModel _viewModel;
        private double _lt;
        public double Lt
        {
            get { return _lt; }
            set
            {
                _lt = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, null);
            }
        }
        private double _lng;
        public double Lng
        {
            get { return _lng; }
            set
            {
                _lng = value;
                if (PropertyChanged != null)
                    PropertyChanged.Invoke(this, null);
            }
        }
        protected override void OnCreate(Bundle bundle)
        {

            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child3View);
            PropertyChanged += PositionUpdate;
            _viewModel = (Child3ViewModel)ViewModel;
            Init();

            var set = this.CreateBindingSet<Child3View, Child3ViewModel>();
            set.Bind(this)
               .For(m => m.Lt)
               .To(vm => vm.Lt);
            set.Apply();

            var set2 = this.CreateBindingSet<Child3View, Child3ViewModel>();
            set.Bind(this)
               .For(m => m.Lng)
               .To(vm => vm.Lng);
            set2.Apply();

            _mapFragment.Map.MapLongClick += Map_MapLongClick;

        }

        void Map_MapLongClick(object sender, GoogleMap.MapLongClickEventArgs e)
        {
            MarkerFactory(e.P0);
            _viewModel.LocationEntity.Add(new LocationEntity() { Latitude = e.P0.Latitude, Longitude = e.P0.Longitude });

        }

        Marker MarkerFactory(LatLng latLan, string name = "None")
        {
            var option = new MarkerOptions();
            option.SetPosition(latLan);
            option.SetTitle(name);
            return _mapFragment.Map.AddMarker(option);
        }

        void Init()
        {
            _mapFragment = (SupportMapFragment)SupportFragmentManager.FindFragmentById(Resource.Id.map);
            _mapFragment.Map.Clear();
            foreach (var location in _viewModel.LocationEntity)
            {
                if (location.Latitude.HasValue && location.Longitude.HasValue)
                {
                    MarkerFactory(new LatLng(location.Latitude.Value, location.Longitude.Value), location.Name);
                }
            }
            _curentLocation = MarkerFactory(new LatLng(_viewModel.Lt, _viewModel.Lng), "Current location");

        }

        private void PositionUpdate(object sender, PropertyChangedEventArgs e)
        {
            if (_curentLocation != null)
                _curentLocation.Remove();
            _curentLocation = MarkerFactory(new LatLng(_viewModel.Lt, _viewModel.Lng), "Current location");

        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}