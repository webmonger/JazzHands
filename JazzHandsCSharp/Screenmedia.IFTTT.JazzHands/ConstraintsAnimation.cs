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

			View.TranslatesAutoresizingMaskIntoConstraints = false;

			View.Frame = animationFrame.Frame;

			View.AddConstraints (new[] {
				NSLayoutConstraint.Create (View, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 14),
				NSLayoutConstraint.Create (View, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, animationFrame.constraintConstant),
			});

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

