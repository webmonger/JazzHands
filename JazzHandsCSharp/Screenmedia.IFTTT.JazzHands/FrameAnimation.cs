using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq;
using MonoTouch.CoreGraphics;

namespace Screenmedia.IFTTT.JazzHands
{
    public class FrameAnimation : Animation
    {
        public void Animate(int time)
        {
            if (KeyFrames.Count() <= 1)
                return;

            AnimationFrame animationFrame = AnimationFrameForTime(time);

            // Store the current transform
            CGAffineTransform tempTransform = View.Transform;

            // Reset rotation to 0 to avoid warping
            View.Transform = CGAffineTransform.MakeRotation(0);
            View.Frame = animationFrame.Frame;

            // Return to original transform
            View.Transform = tempTransform;
        }

        public AnimationFrame FrameForTime(int time,
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

