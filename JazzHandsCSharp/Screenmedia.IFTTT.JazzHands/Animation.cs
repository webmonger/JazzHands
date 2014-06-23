using System;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Screenmedia.IFTTT.JazzHands
{
	public class Animation : NSObject
	{
		private UIView _view;
		private List<AnimationKeyFrame> _keyFrames;

		private List<AnimationFrame> _timeline; // AnimationFrames
		private int _startTime; // in case timeline starts before t=0

		public Animation ()
		{
			_keyFrames = new List<AnimationKeyFrame>();
			_timeline = new List<AnimationFrame> ();
			_startTime = 0;
		}

//		public instancetype AnimationWithView:(UIView view){
//
//		}

		private void InitWithView(UIView view){
			_view = view;
		}

		private void Animate(int time){
			System.Console.WriteLine("Hey pal! You need to use a subclass of IFTTTAnimation.");
		}

		private void AddKeyFrames(List<AnimationKeyFrame> keyFrames){
			foreach (AnimationKeyFrame keyFrame in keyFrames) {
				AddKeyFrame(keyFrame);
			}
		}

		private void AddKeyFrame(AnimationKeyFrame keyFrame){
			if (_keyFrames.Count() == 0) {
				_keyFrames.Add(keyFrame);
				return;
			}

			// because folks might add keyframes out of order, we have to sort here
			if (keyFrame.Time > ((AnimationKeyFrame)_keyFrames[_keyFrames.Count()]).Time) {
				_keyFrames.Add(keyFrame);
			} else {
				for (int i = 0; i < _keyFrames.Count(); i++) {
					if (keyFrame.Time < ((AnimationKeyFrame)_keyFrames[i]).Time) {
						_keyFrames.Add(keyFrame);// TODO atIndex:i;
						break;
					}
				}
			}

			_timeline = new List<AnimationFrame> ();
			for (int i = 0; i < _keyFrames.Count() - 1; i++) {
				AnimationKeyFrame currentKeyFrame = _keyFrames[i];
				AnimationKeyFrame nextKeyFrame = _keyFrames[i+1];

				for (int j = currentKeyFrame.Time + (i == 0 ? 0 : 1); j <= nextKeyFrame.Time; j++) {
					_timeline.Add (FrameForTime (j, currentKeyFrame, nextKeyFrame));
				}
			}
			startTime = ((AnimationKeyFrame)_keyFrames [0]).Time;
		}

		private AnimationFrame FrameForTime (int time,
			AnimationKeyFrame startKeyFrame,
			AnimationKeyFrame endKeyFrame)
		{
			System.Console.WriteLine("Hey pal! You need to use a subclass of IFTTTAnimation.");
			return startKeyFrame;
		}

		private AnimationFrame AnimationFrameForTime(int time){

		}
		private Single TweenValueForStartTime(int startTime,
			int endTime,
			Single startValue,
			Single endValue,
			Single time){

		}
	}
}

