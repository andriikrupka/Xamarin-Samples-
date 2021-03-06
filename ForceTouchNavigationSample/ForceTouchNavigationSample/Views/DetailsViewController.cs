// This file has been autogenerated from a class added in the UI designer.

using System;
using ForceTouchNavigationSample.ViewModels;
using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using UIKit;

namespace ForceTouchNavigationSample
{
	[MvxFromStoryboard("Main")]
	[MvvmCross.iOS.Views.Presenters.Attributes.MvxChildPresentation]
	public partial class DetailViewController : MvxTableViewController<DetailsViewModel>
	{
		private MvxImageViewLoader _imageLoader;

		public DetailViewController (IntPtr handle) : base (handle)
		{
		}

		public string ImageUrl
		{
			get { return _imageLoader?.ImageUrl; }
			set { _imageLoader.ImageUrl = value; }
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			_imageLoader = new MvxImageViewLoader(() => AvatarImageView, AvatarImageView.SetNeedsLayout);

			TableView.RowHeight = UITableView.AutomaticDimension;
			TableView.EstimatedRowHeight = 40;

			var set = this.CreateBindingSet<DetailViewController, DetailsViewModel>();
            set.Bind(FullNameTitle).To(x => x.Emplyee.FullName);
			set.Bind(EmailLabel).To(x => x.Emplyee.Email);
			set.Bind(PositionLabel).To(x => x.Emplyee.Position);
			set.Bind(DetailsLabel).To(x => x.Emplyee.Description);
			set.Bind().For(x => x.ImageUrl).To(x => x.Emplyee.AvatarUrl);
			set.Apply();
		}

        public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return UITableView.AutomaticDimension;
        }
	}
}
