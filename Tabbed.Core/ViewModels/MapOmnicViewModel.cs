using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.ViewModels;
using OmnicTabs.Core.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OmnicTabs.Core.ViewModels
{
    public class Child3ViewModel
     : MvxViewModel
    {

        private IMvxLocationWatcher _watcher;

        private ObservableCollection<LocationEntity> _locationEntity;
        public ObservableCollection<LocationEntity> LocationEntity
        {
            get { return _locationEntity; }
            set { _locationEntity = value; RaisePropertyChanged(() => LocationEntity); }
        }



        private double _lng;
        public double Lng
        {
            get { return _lng; }
            set { _lng = value; RaisePropertyChanged(() => Lng); }
        }
        private double _lt;
        public double Lt
        {
            get { return _lt; }
            set { _lt = value; RaisePropertyChanged(() => Lt); }
        }

        public Child3ViewModel(IMvxLocationWatcher watcher)
        {
            _watcher = watcher;
            _watcher.Start(new MvxLocationOptions(), OnFix, OnError);
            LocationEntity = new ObservableCollection<LocationEntity>(Parameters.LocationEntityManager.GetItems().ToList());
        }

        private void OnError(MvxLocationError obj)
        {
            throw new NotImplementedException();
        }

        private void OnFix(MvxGeoLocation obj)
        {
            Lt = obj.Coordinates.Latitude;
            Lng = obj.Coordinates.Longitude;
        }
    }
}
