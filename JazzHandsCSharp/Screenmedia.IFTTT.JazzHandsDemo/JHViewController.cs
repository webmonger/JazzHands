
using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Screenmedia.IFTTT.JazzHands;



namespace Screenmedia.IFTTT.JazzHandsDemo
{
	public class JHViewController : AnimatedScrollViewController, IAnimatedScrollViewController
	{
		private const int NUMBER_OF_PAGES = 4;

		public UIImageView wordmark { get; set;}
		public UIImageView unicorn { get; set;}
		public UILabel lastLabel { get; set;}
		public UILabel firstLabel { get; set;}

		public JHViewController () : base ("JHViewController", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ScrollView.ContentSize = new SizeF (NUMBER_OF_PAGES * View.Frame.Width, View.Frame.Height);

			ScrollView.PagingEnabled = true;
			ScrollView.ShowsHorizontalScrollIndicator = false;

			// Perform any additional setup after loading the view, typically from a nib.
		}

		private void PlaceViews ()
		{
			// put a unicorn in the middle of page two, hidden
			unicorn = new UIImageView(new UIImage("Unicorn"));
			AddImage (unicorn);

			// put a logo on top of it
			wordmark = new UIImageView(new UIImage("IFTTT"));
			AddImage (wordmark);


			firstLabel = AddLabel ("Introducing Jazz Hands");

			UILabel secondPageText = AddLabel ("Brought to you by IFTTT");
			secondPageText.Frame = RectangleF.Inflate(secondPageText.Frame, TimeForPage(2), -180);

			UILabel thirdPageText = AddLabel ("Simple keyframe animations");
			thirdPageText.Frame =   RectangleF.Inflate(thirdPageText.Frame, TimeForPage(3), 100);

			UILabel fourthPageText = AddLabel ("Optimized for scrolling intros");
			fourthPageText.Frame =   RectangleF.Inflate(fourthPageText.Frame, TimeForPage(4), 0);

			lastLabel = fourthPageText;
		}


		int TimeForPage(int page)
		{
			return (int)(View.Frame.Size.Width * (page - 1));
		}


		void AddImage(UIImageView iv)
		{
			iv.Center = View.Center;
			iv.Frame = RectangleF.Inflate(iv.Frame, -View.Frame.Size.Width, 100);
			iv.Alpha = 0.0f;
			ScrollView.AddSubview(iv);
		}

		private UILabel AddLabel(string text)
		{
			var l = new UILabel();
			l.Text = text;
			l.SizeToFit();
			l.Center = View.Center;
			ScrollView.AddSubview(l);
			return l;
		}

		private void ConfigureAnimation ()
		{
			Single dy = 240;
			/*
			// apply a 3D zoom animation to the first label
			Transform3DAnimation labelTransform = Transform3DAnimation.AnimationWithView(firstLabel);
			Transform3D tt1 = Transform3D.TransformWithM34(0.03f);
			Transform3D tt2 =  Transform3D.TransformWithM34(0.3f);
			tt2.rotate = (IFTTTTransform3DRotate){ -(CGFloat)(M_PI), 1, 0, 0 };
			tt2.translate = (IFTTTTransform3DTranslate){ 0, 0, 50 };
			tt2.scale = (IFTTTTransform3DScale){ 1.f, 2.f, 1.f };
			[labelTransform addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(0)
				andAlpha:1.0f]];
			[labelTransform addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(1)
				andTransform3D:tt1]];
			[labelTransform addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(1.5)
				andTransform3D:tt2]];
			[labelTransform addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(1.5) + 1
				andAlpha:0.0f]];
			[self.animator addAnimation:labelTransform];

			// let's animate the wordmark
			IFTTTFrameAnimation *wordmarkFrameAnimation = [IFTTTFrameAnimation animationWithView:self.wordmark];
			[self.animator addAnimation:wordmarkFrameAnimation];

			[wordmarkFrameAnimation addKeyFrames:@[
				[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(1) andFrame:CGRectOffset(self.wordmark.frame, 200, 0)],
				[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(2) andFrame:self.wordmark.frame],
				[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(3) andFrame:CGRectOffset(self.wordmark.frame, self.view.frame.size.width, dy)],
				[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(4) andFrame:CGRectOffset(self.wordmark.frame, 0, dy)],
			]];

			// Rotate a full circle from page 2 to 3
			IFTTTAngleAnimation *wordmarkRotationAnimation = [IFTTTAngleAnimation animationWithView:self.wordmark];
			[self.animator addAnimation:wordmarkRotationAnimation];
			[wordmarkRotationAnimation addKeyFrames:@[
				[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(2) andAngle:0.0f],
				[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(3) andAngle:(CGFloat)(2 * M_PI)],
			]];

			// now, we animate the unicorn
			IFTTTFrameAnimation *unicornFrameAnimation = [IFTTTFrameAnimation animationWithView:self.unicorn];
			[self.animator addAnimation:unicornFrameAnimation];

			CGFloat ds = 50;

			// move down and to the right, and shrink between pages 2 and 3
			[unicornFrameAnimation addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(2) andFrame:self.unicorn.frame]];
			[unicornFrameAnimation addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(3)
				andFrame:CGRectOffset(CGRectInset(self.unicorn.frame, ds, ds), timeForPage(2), dy)]];
			// fade the unicorn in on page 2 and out on page 4
			IFTTTAlphaAnimation *unicornAlphaAnimation = [IFTTTAlphaAnimation animationWithView:self.unicorn];
			[self.animator addAnimation:unicornAlphaAnimation];

			[unicornAlphaAnimation addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(1) andAlpha:0.0f]];
			[unicornAlphaAnimation addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(2) andAlpha:1.0f]];
			[unicornAlphaAnimation addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(3) andAlpha:1.0f]];
			[unicornAlphaAnimation addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(4) andAlpha:0.0f]];

			// Fade out the label by dragging on the last page
			IFTTTAlphaAnimation *labelAlphaAnimation = [IFTTTAlphaAnimation animationWithView:self.lastLabel];
			[labelAlphaAnimation addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(4) andAlpha:1.0f]];
			[labelAlphaAnimation addKeyFrame:[IFTTTAnimationKeyFrame keyFrameWithTime:timeForPage(4.35f) andAlpha:0.0f]];
			[self.animator addAnimation:labelAlphaAnimation];
			*/
		}

		#region IAnimatedScrollViewController implementation

		public NSObject WeakDelegate {
			get {
				throw new NotImplementedException ();
			}
			set {
				throw new NotImplementedException ();
			}
		}

		public void AnimatedScrollViewControllerDidScrollToEnd (AnimatedScrollViewController animatedScrollViewController)
		{
			System.Console.WriteLine(@"Scrolled to end of scrollview!");
		}

		public void AnimatedScrollViewControllerDidEndDraggingAtEnd (AnimatedScrollViewController animatedScrollViewController)
		{
			System.Console.WriteLine(@"Scrolled to end of scrollview!");
		}

		#endregion
	}
}

