using Android.App;
using Android.OS;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Plugins.Location;
using OmnicTabs.Core.ViewModels;

namespace OmnicTabs.Droid.Views
{
    [Activity]
    public class OmnicTabsView : MvxTabActivity
    {
        protected OmnicTabsViewModel FirstViewModel
        {
            get
            {
                if (ViewModel != null) 
                    return ViewModel as OmnicTabsViewModel;
                return new OmnicTabsViewModel(Mvx.Resolve<IMvxLocationWatcher>());
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.OmnicTabsView);

            TabHost.TabSpec spec = TabHost.NewTabSpec("child1");
            spec.SetIndicator("1");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child1));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child2");
            spec.SetIndicator("2");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child2));
            TabHost.AddTab(spec);

            spec = TabHost.NewTabSpec("child3");
            spec.SetIndicator("3");
            spec.SetContent(this.CreateIntentFor(FirstViewModel.Child3));
            TabHost.AddTab(spec);
        }
    }
}