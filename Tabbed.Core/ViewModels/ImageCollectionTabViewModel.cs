using System.Collections.ObjectModel;
using Cirrious.MvvmCross.ViewModels;
using OmnicTabs.Core.Services;
using System.Linq;
using System.Windows.Input;
using System.Threading.Tasks;

namespace OmnicTabs.Core.ViewModels
{
    public class Child1ViewModel
    : MvxViewModel
    {
        Image _chosenItem;
        public Image ChosenItem
        {
            get { return _chosenItem; }
            set
            {
                _chosenItem = value;
                Parameters.SetImageUrl(value.Url);
                RaisePropertyChanged(() => ChosenItem);
            }
        }
        static ObservableCollection<Image> _images;
        public ObservableCollection<Image> Images
        {
            get { return _images; }
            set { _images = value; RaisePropertyChanged(() => Images); }
        }
         public string Refresh { get { return "Refresh"; } }
         public Child1ViewModel(IImageService service)
         {
             LoadImages(service);
         }

        public ICommand ZoomImageCommand
        {
            // I thinks its a bug, but ShowViewModel<T> doesnt work, so for now i pass params throu static.
            get
            {
                return new MvxCommand(() => ShowViewModel(typeof(GrandChildViewModel)));
            }
        }
        public ICommand RefreshCommand
        {
            get { return new MvxCommand(() => LoadImages(new ImageLoader())); }
        }

       

       
        

       
        private async void LoadImages(IImageService service)
        {
            Images = await Task<ObservableCollection<Image>>.Factory.StartNew(() =>
            {
                var newList = new ObservableCollection<Image>();
                for (var i = 0; i < 100; i++)
                {
                    var newImage = service.ImageFactory();
                    newList.Add(newImage);
                }

                return newList;
            });
        }

        public static void DeleteImage()
        {
            var imageToDel = new Parameters().ImageToDel;
            if (_images.Any() && imageToDel.HasValue)
                _images.RemoveAt(imageToDel.Value);
        }
    }
}
