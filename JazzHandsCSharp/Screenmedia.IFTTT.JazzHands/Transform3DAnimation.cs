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
	        if (KeyFrames.Count() <= 1)
	            return;

            AnimationFrame animationFrame = AnimationFrameForTime(time);

	        CATransform3D transform = CATransform3D.Identity;
	        transform.m34 = _m34;
	        if (animationFrame.Transform != null)
	        {
	            transform.Rotate(
	                animationFrame.Transform.Rotate.Angle,
	                animationFrame.Transform.Rotate.X,
	                animationFrame.Transform.Rotate.Y,
	                animationFrame.Transform.Rotate.Z);
	            transform.Scale(
	                animationFrame.Transform.Scale.Sx,
	                animationFrame.Transform.Scale.Sy,
	                animationFrame.Transform.Scale.Sz);
	            transform.Translate(
	                animationFrame.Transform.Translate.Tx,
	                animationFrame.Transform.Translate.Ty,
	                animationFrame.Transform.Translate.Tz);

	            View.Layer.Transform = transform;
	        }
	    }

	    public override AnimationFrame FrameForTime(int time,
            AnimationKeyFrame startKeyFrame,
            AnimationKeyFrame endKeyFrame)
        {
            int startTime = startKeyFrame.Time;
            int endTime = endKeyFrame.Time;
            RectangleF startLocation = startKeyFrame.Frame;
            RectangleF endLocation = endKeyFrame.Frame;

            RectangleF frame = View.Frame;
            frame.Location =
                new PointF(
                    TweenValueForStartTime(startTime, endTime, startLocation.GetMinX(), endLocation.GetMinX(), time),
                    TweenValueForStartTime(startTime, endTime, startLocation.GetMinY(), endLocation.GetMinY(), time));
            frame.Size =
                new SizeF(TweenValueForStartTime(startTime, endTime, startLocation.Width, endLocation.Width, time),
                    TweenValueForStartTime(startTime, endTime, startLocation.Height, endLocation.Height, time));

            AnimationFrame animationFrame = new AnimationFrame();
            animationFrame.Frame = frame;

            return animationFrame;
        }
	}
}

