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
	[Register ("ChildViewController")]
	partial class ChildViewController
	{
		[Outlet]
		UIKit.UIImageView AvatarImageView { get; set; }

		[Outlet]
		UIKit.UILabel DetailLabel { get; set; }

		[Outlet]
		UIKit.UILabel EmailLabel { get; set; }

		[Outlet]
		UIKit.UILabel FullNameLabel { get; set; }

		[Outlet]
		UIKit.UILabel PositionLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (AvatarImageView != null) {
				AvatarImageView.Dispose ();
				AvatarImageView = null;
			}

			if (FullNameLabel != null) {
				FullNameLabel.Dispose ();
				FullNameLabel = null;
			}

			if (EmailLabel != null) {
				EmailLabel.Dispose ();
				EmailLabel = null;
			}

			if (PositionLabel != null) {
				PositionLabel.Dispose ();
				PositionLabel = null;
			}

			if (DetailLabel != null) {
				DetailLabel.Dispose ();
				DetailLabel = null;
			}
		}
	}
}
