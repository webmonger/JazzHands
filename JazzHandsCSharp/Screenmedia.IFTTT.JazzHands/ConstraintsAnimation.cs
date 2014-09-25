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

			NSLayoutConstraint viewConstraint = new NSLayoutConstraint ();

			viewConstraint.Constant=animationFrame.constraintConstant;

			View.AddConstraint (viewConstraint);

			View.Frame = animationFrame.Frame;

			View.SetNeedsLayout ();
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

