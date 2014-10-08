using Cirrious.MvvmCross.ViewModels;
using System.Windows.Input;

namespace OmnicTabs.Core.ViewModels
{
    public class GrandChildViewModel
        : MvxViewModel
    {
        string _imageUrl;
        public GrandChildViewModel()
        {
            _imageUrl = Parameters.GetImageUrl();

        }
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; RaisePropertyChanged(() => ImageUrl); }
        }
        private MvxCommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                _deleteCommand = _deleteCommand ?? new MvxCommand(Child1ViewModel.DeleteImage);
                return _deleteCommand;
            }
        }
    }
}
