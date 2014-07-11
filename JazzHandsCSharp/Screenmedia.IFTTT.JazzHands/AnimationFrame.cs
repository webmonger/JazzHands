using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace Screenmedia.IFTTT.JazzHands
{
	public class AnimationFrame
	{
		public RectangleF Frame = new RectangleF();
		public Single Alpha;
		public bool Hidden = false;
		public UIColor Color;
        public Single Angle;
		public Transform3D Transform = new Transform3D();
        public Single Scale;
	}
}

