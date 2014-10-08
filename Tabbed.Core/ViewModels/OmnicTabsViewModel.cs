using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using OmnicTabs.Core.BusinessLayer;
using OmnicTabs.Core.Services;
using System.Threading.Tasks;
using System;
using Cirrious.MvvmCross.Plugins.Location;

namespace OmnicTabs.Core.ViewModels
{
    public class OmnicTabsViewModel 
		: MvxViewModel
    {
        public OmnicTabsViewModel(IMvxLocationWatcher watcher)
        {
            Child1 = new Child1ViewModel(new ImageLoader());
            Child2 = new Child2ViewModel();
            Child3 = new Child3ViewModel(watcher);
        }
        private Child1ViewModel _child1;
        public Child1ViewModel Child1
        {
            get { return _child1; }
            set { _child1 = value; RaisePropertyChanged(() => Child1); }
        }

        private Child2ViewModel _child2;
        public Child2ViewModel Child2
        {
            get { return _child2; }
            set { _child2 = value; RaisePropertyChanged(() => Child2); }
        }

        private Child3ViewModel _child3;
        public Child3ViewModel Child3
        {
            get { return _child3; }
            set { _child3 = value; RaisePropertyChanged(() => Child3); }
        }
    }

    public class Parameters
    {
       static string _imageUrl;
       public static void SetImageUrl(string url)
        {
            _imageUrl = url;
        }
       public static string GetImageUrl()
        {
            return _imageUrl;
        }

        private static int? _imageToDel;
        public int? ImageToDel {
            get { return  _imageToDel; }
            set { _imageToDel = value; }
        }

        private static LocationEntityManager _locationEntityManager;
        public static LocationEntityManager LocationEntityManager
        {
            get { return _locationEntityManager; }
            set { _locationEntityManager = value; }
        }

        private static LocationEntity _locationEntity;
        public static LocationEntity LocationEntity
        {
            get { return  _locationEntity; }
            set { _locationEntity = value; }
        }
    }
}
