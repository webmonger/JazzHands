﻿using System;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace Screenmedia.IFTTT.JazzHands
{
	public class Animation : NSObject
	{
		protected UIView View;
		protected List<AnimationKeyFrame<int,object>> KeyFrames;

		private List<AnimationFrame> _timeline; // AnimationFrames
		private int _startTime; // in case timeline starts before t=0

		public Animation ()
		{
			KeyFrames = new List<AnimationKeyFrame<int,object>>();
			_timeline = new List<AnimationFrame> ();
			_startTime = 0;
		}

//		public instancetype AnimationWithView:(UIView view){
//
//		}

		private void InitWithView(UIView view){
			View = view;
		}

		private void AddKeyFrames(List<AnimationKeyFrame<int,object>> keyFrames){
			foreach (AnimationKeyFrame<int,object> keyFrame in keyFrames) {
				AddKeyFrame(keyFrame);
			}
		}

		private void AddKeyFrame(AnimationKeyFrame<int,object> keyFrame){
			if (KeyFrames.Count() == 0) {
				KeyFrames.Add(keyFrame);
				return;
			}

			// because folks might add keyframes out of order, we have to sort here
			if (keyFrame.Time > ((AnimationKeyFrame<int,object>)KeyFrames.Last()).Time) {
				KeyFrames.Add(keyFrame);
			} else {
				for (int i = 0; i < KeyFrames.Count(); i++) {
					if (keyFrame.Time < ((AnimationKeyFrame<int,object>)KeyFrames[i]).Time) {
						KeyFrames.Add(keyFrame);// TODO atIndex:i;
						break;
					}
				}
			}

			_timeline = new List<AnimationFrame> ();
			for (int i = 0; i < KeyFrames.Count() - 1; i++) {
				AnimationKeyFrame<int,object> currentKeyFrame = KeyFrames[i];
				AnimationKeyFrame<int,object> nextKeyFrame = KeyFrames[i+1];

				for (int j = currentKeyFrame.Time + (i == 0 ? 0 : 1); j <= nextKeyFrame.Time; j++) {
					_timeline.Add (FrameForTime (j, currentKeyFrame, nextKeyFrame));
				}
			}
			_startTime = ((AnimationKeyFrame<int,object>)KeyFrames [0]).Time;
		}

		protected AnimationFrame FrameForTime (int time,
			AnimationKeyFrame<int,object> startKeyFrame,
			AnimationKeyFrame<int,object> endKeyFrame)
		{
			System.Console.WriteLine("Hey pal! You need to use a subclass of IFTTTAnimation.");
			return startKeyFrame;
		}

		protected AnimationFrame AnimationFrameForTime(int time){
			if (time < _startTime) {
				return _timeline[0];
			}

			if (time - _startTime < _timeline.Count()) {
				return _timeline[time - _startTime];
			}

			return _timeline.Last();
		}

		public void Animate(int time)
		{
			Console.WriteLine(@"Hey pal! You need to use a subclass of IFTTTAnimation.");
		}

		protected Single TweenValueForStartTime(int startTime,
				int endTime,
				Single startValue,
				Single endValue,
				Single time){
			Single dt = (endTime - startTime);
			Single timePassed = (time - startTime);
			Single dv = (endValue - startValue);
			Single vv = dv / dt;
			return (timePassed * vv) + startValue;
		}
	}
}
