using System;
using MonoTouch.UIKit;
using System.Linq;
using MonoTouch.CoreGraphics;

namespace Screenmedia.IFTTT.JazzHands
{
	public class ConstraintsAnimation: Animation
	{
		public ConstraintsAnimation (UIView view) : base(view)
		{
		}
		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1)
				return;

			AnimationFrame animationFrame = AnimationFrameForTime(time);

//			NSLayoutConstraint viewConstraint = new NSLayoutConstraint ();
//			viewConstraint.Constant=animationFrame.constraintConstant;

			View.Frame = animationFrame.Frame;

			View.TranslatesAutoresizingMaskIntoConstraints = false;

			var textFieldTopConstraint = NSLayoutConstraint.Create (View, NSLayoutAttribute.Top, NSLayoutRelation.GreaterThanOrEqual, null, NSLayoutAttribute.Top, 1.0f, animationFrame.constraintConstant);
			var textFieldBottomConstraint = NSLayoutConstraint.Create (View, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, null, NSLayoutAttribute.Bottom, 1.0f, 0f);
			View.AddConstraints (new NSLayoutConstraint[] {textFieldTopConstraint, textFieldBottomConstraint }); 

			//View.AddConstraint (viewConstraint);

			View.LayoutIfNeeded ();
		}

		public override AnimationFrame FrameForTime(int time,
			AnimationKeyFrame startKeyFrame,
			AnimationKeyFrame endKeyFrame)
		{
			AnimationFrame animationFrame = new AnimationFrame ();
			animationFrame.constraintConstant = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.constraintConstant, endKeyFrame.constraintConstant, time);
			
			return animationFrame;
		}
	}
}

