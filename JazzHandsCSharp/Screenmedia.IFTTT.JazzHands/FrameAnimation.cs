using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace Screenmedia.IFTTT.JazzHands
{
    public class AnimationFrame
    {
        public RectangleF Frame { get; set; }
        public Single Alpha { get; set; }
        public bool Hidden { get; set; }
        public UIColor Color { get; set; }
        public Single Angle { get; set; }
        public Transform3D Transform { get; set; }
        public Single Scale { get; set; }
    }
}

