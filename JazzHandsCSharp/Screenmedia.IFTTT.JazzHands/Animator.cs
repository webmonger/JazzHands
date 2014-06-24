using System;
using System.Collections.Generic;

namespace Screenmedia.IFTTT.JazzHands
{
	public class Animator
	{
		private List<Animation> _animations;

		public Animator ()
		{
			_animations = new List<Animation> ();
		}

		public void Animate(int time){
			foreach (var animation in _animations) {
				animation.Animate(time);
			}
		}

		public void AddAnimation(Animation animation)
		{
			_animations.Add(animation);
		}
	}
}

