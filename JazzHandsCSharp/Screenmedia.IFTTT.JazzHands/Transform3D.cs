using System;
using MonoTouch.Foundation;

namespace Screenmedia.IFTTT.JazzHands
{
    public class Transform3D : NSObject
    {
        public float M34;
        public Transform3DScale Scale;
        public Transform3DRotate Rotate;
        public Transform3DTranslate Translate;

        public Transform3D()
        {
            Scale = new Transform3DScale()
            {
                Sx = 1.0f,
                Sy = 1.0f,
                Sz = 1.0f
            };
        }
    }

    public class Transform3DTranslate
    {
        public float Tx, Ty, Tz;
    }

    public class Transform3DRotate
    {
        public float Angle;
        public float X, Y, Z;
    }

    public class Transform3DScale
    {
        public float Sx, Sy, Sz;

    }
}

