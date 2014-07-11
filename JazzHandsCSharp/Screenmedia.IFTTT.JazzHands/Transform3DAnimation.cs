using System;
using System.Linq;
using System.Drawing;
using MonoTouch.CoreAnimation;
using MonoTouch.CoreGraphics;
using MonoTouch.UIKit;

namespace Screenmedia.IFTTT.JazzHands
{
	public class Transform3DAnimation : Animation
	{
	    private readonly float _m34;

	    public Transform3DAnimation(UIView view, float m34) : base(view)
	    {
	        _m34 = m34;
	    }

	    public override void Animate(int time)
		{
			if (KeyFrames.Count () <= 1)
				return;

			AnimationFrame animationFrame = AnimationFrameForTime (time);
			if (animationFrame.Transform == null)
				return;

			CATransform3D transform = CATransform3D.Identity;
			transform.m34 = _m34;
			//if (animationFrame.Transform.Rotate != null)
				transform.Rotate (
					animationFrame.Transform.Rotate.Angle,
					animationFrame.Transform.Rotate.X,
					animationFrame.Transform.Rotate.Y,
					animationFrame.Transform.Rotate.Z);
			//if (animationFrame.Transform.Scale != null)
				transform.Scale (
					animationFrame.Transform.Scale.Sx,
					animationFrame.Transform.Scale.Sy,
					animationFrame.Transform.Scale.Sz);
			//if (animationFrame.Transform.Translate != null)
				transform.Translate (
					animationFrame.Transform.Translate.Tx,
					animationFrame.Transform.Translate.Ty,
					animationFrame.Transform.Translate.Tz);

			View.Layer.Transform = transform;
		}

	    public override AnimationFrame FrameForTime(int time,
            AnimationKeyFrame startKeyFrame,
            AnimationKeyFrame endKeyFrame)
        {
			AnimationFrame animationFrame = new AnimationFrame();
			animationFrame.Transform = new Transform3D();
			animationFrame.Transform.M34 = startKeyFrame.Transform.M34;

			//if (startKeyFrame.Transform.Translate != null) {
				Transform3DTranslate translate = new Transform3DTranslate ();
				translate.Tx = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Translate.Tx, endKeyFrame.Transform.Translate.Tx, time);
				translate.Ty = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Translate.Ty, endKeyFrame.Transform.Translate.Ty, time);
				translate.Tz = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Translate.Tz, endKeyFrame.Transform.Translate.Tz, time);
				animationFrame.Transform.Translate = translate;
			//}

			//if (startKeyFrame.Transform.Rotate != null) {
				Transform3DRotate rotate = new Transform3DRotate ();
				rotate.Angle = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Rotate.Angle, endKeyFrame.Transform.Rotate.Angle, time); 
				rotate.X = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Rotate.X, endKeyFrame.Transform.Rotate.X, time); 
				rotate.Y = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Rotate.Y, endKeyFrame.Transform.Rotate.Y, time); 
				rotate.Z = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Rotate.Z, endKeyFrame.Transform.Rotate.Z, time); 
				animationFrame.Transform.Rotate = rotate;
			//}


			//if (startKeyFrame.Transform.Scale != null) {
				Transform3DScale scale = new Transform3DScale ();
				scale.Sx = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Scale.Sx, endKeyFrame.Transform.Scale.Sx, time); 
				scale.Sy = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Scale.Sy, endKeyFrame.Transform.Scale.Sy, time); 
				scale.Sz = TweenValueForStartTime (startKeyFrame.Time, endKeyFrame.Time, startKeyFrame.Transform.Scale.Sz, endKeyFrame.Transform.Scale.Sz, time); 
				animationFrame.Transform.Scale = scale;
			//}
			return animationFrame;
        }
	}
}

