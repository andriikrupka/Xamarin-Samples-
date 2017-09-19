// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ForceTouchNavigationSample
{
	[Register ("DetailViewController")]
	partial class DetailViewController
	{
		[Outlet]
		UIKit.UIImageView AvatarImageView { get; set; }

		[Outlet]
		UIKit.UILabel DetailsLabel { get; set; }

		[Outlet]
		UIKit.UILabel EmailLabel { get; set; }

		[Outlet]
		UIKit.UILabel FullNameTitle { get; set; }

		[Outlet]
		UIKit.UILabel PositionLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AvatarImageView != null) {
				AvatarImageView.Dispose ();
				AvatarImageView = null;
			}

			if (FullNameTitle != null) {
				FullNameTitle.Dispose ();
				FullNameTitle = null;
			}

			if (EmailLabel != null) {
				EmailLabel.Dispose ();
				EmailLabel = null;
			}

			if (PositionLabel != null) {
				PositionLabel.Dispose ();
				PositionLabel = null;
			}

			if (DetailsLabel != null) {
				DetailsLabel.Dispose ();
				DetailsLabel = null;
			}
		}
	}
}
