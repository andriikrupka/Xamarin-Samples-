using System;
using CoreGraphics;
using ForceTouchNavigationSample.Models;
using ForceTouchNavigationSample.ViewModels;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.iOS.Views;
using UIKit;

namespace ForceTouchNavigationSample
{
    [MvxFromStoryboard("Main")]
    [MvvmCross.iOS.Views.Presenters.Attributes.MvxRootPresentation(WrapInNavigationController = true)]
    public partial class ViewController : MvxViewController<MainViewModel>, IUIViewControllerPreviewingDelegate
    {
        private MvxIosViewPresenter _viewPresenter;
        private IMvxViewModelLoader _viewModelLoader;
        private MvxViewModelInstanceRequest _previewViewModelRequest;

        protected ViewController(IntPtr handle) : base(handle)
        { }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            _viewModelLoader = Mvx.Resolve<IMvxViewModelLoader>();
            _viewPresenter = Mvx.Resolve<IMvxIosModalHost>() as MvxIosViewPresenter;

            if (TraitCollection.ForceTouchCapability == UIForceTouchCapability.Available)
            {
                RegisterForPreviewingWithDelegate(this, TableView);
            }

            var source = new MvxStandardTableViewSource(TableView,
                                                        UITableViewCellStyle.Subtitle,
                                                        new Foundation.NSString("EmployeeListView"),
                                                        "TitleText FullName; DetailText Position",
                                                        UITableViewCellAccessory.DisclosureIndicator);
            source.DeselectAutomatically = true;

            TableView.Source = source;
            var set = this.CreateBindingSet<ViewController, MainViewModel>();
            set.Bind(source).For(s => s.ItemsSource).To(vm => vm.Employee);
            set.Bind(source).For(s => s.SelectionChangedCommand).To(vm => vm.ViewDetailsCommand);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();

        }


        public void CommitViewController(IUIViewControllerPreviewing previewingContext, UIViewController viewControllerToCommit)
        {
            if (_previewViewModelRequest != null)
            {
                _viewPresenter.Show(_previewViewModelRequest);
                _previewViewModelRequest = null;
            }
        }

        public UIViewController GetViewControllerForPreview(IUIViewControllerPreviewing previewingContext, CGPoint location)
        {
            var itemIndex = TableView.IndexPathForRowAtPoint(location);
            if (itemIndex == null)
                return null;
            var cell = TableView.CellAt(itemIndex) as MvxTableViewCell;
            if (cell == null)
                return null;

            _previewViewModelRequest = new MvxViewModelInstanceRequest(typeof(DetailsViewModel));
            _previewViewModelRequest.ViewModelInstance = _viewModelLoader.LoadViewModel(_previewViewModelRequest, null);

            if (_previewViewModelRequest.ViewModelInstance is IMvxViewModel<Employee> childViewModel)
            {
                childViewModel.Prepare(cell.DataContext as Employee);
            }

            var viewController = _viewPresenter.CreateViewControllerFor<DetailsViewModel>(_previewViewModelRequest) as UIViewController;
            viewController.PreferredContentSize = new CGSize(0, 500);
            previewingContext.SourceRect = cell.Frame;

            return viewController;
        }
    }
}
