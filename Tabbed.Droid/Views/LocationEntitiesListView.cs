using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using OmnicTabs.Core.ViewModels;
using Android.Content;
using OmnicTabs.Core.BusinessLayer;
using Android.Views;

namespace OmnicTabs.Droid.Views
{
    [Activity(Label = "View for Child2ViewModel")]
    public class Child2View : MvxActivity
    {
        private MvxListView _listView;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Child2View);
            _listView = FindViewById<MvxListView>(Resource.Id.list_view2);
            _listView.Adapter = new CustomAdapter(this, (IMvxAndroidBindingContext)BindingContext);
        }

        protected override void OnResume()
        {
            base.OnResume();
            ((Child2ViewModel)ViewModel).UpdateListView();

        }
    }
    public class CustomAdapter : MvxAdapter
    {
        public CustomAdapter(Context context, IMvxAndroidBindingContext bindingContext)
            : base(context, bindingContext)
        {
        }

        public override int GetItemViewType(int position)
        {
            var item = GetRawItem(position);
            if (item is LocationEntity)
                return 0;
            return 1;
        }

        public override int ViewTypeCount
        {
            get { return 2; }
        }

        protected override View GetBindableView(View convertView, object source, int templateId)
        {
            var location = source as LocationEntity;
            if (location != null)
            {
                templateId = location.Latitude >= 0 ? Resource.Layout.Item_Customlocationnorth : Resource.Layout.Item_Customlocation;
            }
            return base.GetBindableView(convertView, source, templateId);
        }
    }
}