using Cirrious.MvvmCross.Plugins.Location;
using Cirrious.MvvmCross.ViewModels;
using OmnicTabs.Core.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace OmnicTabs.Core.ViewModels
{
    public class Child2ViewModel
    : MvxViewModel
    {
        public Child2ViewModel()
        {
        }

        public void UpdateListView()
        {
            LocationEntity = new ObservableCollection<LocationEntity>(Parameters.LocationEntityManager.GetItems().ToList());
        }

        private ObservableCollection<LocationEntity> _locationEntity;
        public ObservableCollection<LocationEntity> LocationEntity
        {
            get { return _locationEntity; }
            set { _locationEntity = value; RaisePropertyChanged(() => LocationEntity); }
        }
        public ICommand ItemClickCommand
        {
            get
            {
                return new MvxCommand(
                    () =>
                        ShowViewModel(typeof(LocationEntityDetailsViewModel)));
            }
        }

        public ICommand AddCommand
        {
            get
            {
                return new MvxCommand(
                    () =>
                        ShowViewModel(typeof(LocationEntityDetailsViewModel)));
            }
        }

        LocationEntity _chosenItem;
        private IMvxLocationWatcher watcher;
        public LocationEntity ChosenItem
        {
            get { return _chosenItem; }
            set
            {
                _chosenItem = value;
                Parameters.LocationEntity = value;
                RaisePropertyChanged(() => ChosenItem);
            }
        }

    }
}
