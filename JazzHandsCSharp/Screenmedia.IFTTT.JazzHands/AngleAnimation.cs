using System;
using MonoTouch.UIKit;
using System.Linq;
using MonoTouch.CoreGraphics;

namespace Screenmedia.IFTTT.JazzHands
{
	public class AngleAnimation : Animation
	{
		public AngleAnimation (UIView view) : base(view)
		{
		}
		public override void Animate(int time)
		{
			if (KeyFrames.Count() <= 1) return;

			AnimationFrame animationFrame = AnimationFrameForTime(time);
			View.Transform = CGAffineTransform.MakeRotation(animationFrame.Angle);
		}

		public override AnimationFrame FrameForTime(int time,
			AnimationKeyFrame startKeyFrame,
			AnimationKeyFrame endKeyFrame)
		{
			AnimationFrame animationFrame = new AnimationFrame ();
			animationFrame.Angle = TweenValueForStartTime (startKeyFrame.Time,
				endKeyFrame.Time,
				startKeyFrame.Angle,
				endKeyFrame.Angle,
				time);

			return animationFrame;
		}
	}
}

