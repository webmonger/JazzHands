using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using System.Drawing;

namespace Screenmedia.IFTTT.JazzHands
{
	public class AnimationKeyFrame<T1,T2> : AnimationFrame
	{
		public int Time { get; set; }

		public AnimationKeyFrame (AnimationType type, T1 time, T2 value2)
		{
		    switch (type)
		    {
		        case AnimationType.Frame:
		            Frame = value2;
		            break;
		        case AnimationType.Alpha:
		            break;
		        case AnimationType.Hidden:
		            break;
		        case AnimationType.Color:
		            break;
		        case AnimationType.Angle:
		            break;
		        case AnimationType.Transform:
		            break;
		        case AnimationType.Scale:
		            break;
		        default:
		            throw new ArgumentOutOfRangeException("type");
		    }
		}

        public List<AnimationKeyFrame<int,double>> KeyFramesWithTimes(AnimationType animationType, params Tuple<int, double>[] pairCount)
		{
            return KeyFramesGeneric(animationType, pairCount);
		}

        private static List<AnimationKeyFrame<T1, T2>> KeyFramesGeneric<T1, T2>(AnimationType animationType, Tuple<T1, T2>[] pairCount)
	    {
	        T1 time;
	        T2 item2; // This is the varying type
	        if (pairCount.Length > 0)
	        {
	            var keyFrames = new List<AnimationKeyFrame<T1, T2>>();

	            for (int i = 0; i < pairCount.Length; i++)
	            {
	                time = pairCount[i].Item1;
	                item2 = pairCount[i].Item2; // use double to suppress a va_arg conversion warning
                    var keyFrame = new AnimationKeyFrame<T1, T2>(animationType, time, item2);
	                // TODO: Add the method required for this
	                keyFrames.Add(keyFrame);
	            }
	            return keyFrames;
	        }
	        else
	        {
	            return null;
	        }
	    }

        public List<AnimationKeyFrame<int, RectangleF>> KeyFramesWithTimesAndFrames(AnimationType animationType, params Tuple<int, RectangleF>[] pairCount)
		{
            return KeyFramesGeneric(animationType, pairCount);
//			va_list argumentList;
//			int time;
//			RectangleF frame;
//			if (pairCount > 0) {
//				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];
//
//				va_start(argumentList, pairCount);
//
//				for (int i=0; i<pairCount; i++) {
//					time = va_arg(argumentList, NSInteger);
//					frame = va_arg(argumentList, CGRect);
//					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
//						andFrame:frame];
//					[keyFrames addObject:keyFrame];
//				}
//
//				va_end(argumentList);
//
//				return [NSArray arrayWithArray:keyFrames];
//			}
//			else {
//				return nil;
//			}
		}

        public List<AnimationKeyFrame<int, bool>> KeyFramesWithTimesAndHiddens(AnimationType animationType, params Tuple<int, bool>[] pairCount)
		{
            return KeyFramesGeneric(animationType, pairCount);
//			va_list argumentList;
//			NSInteger time;
//			BOOL hidden;
//			if (pairCount > 0) {
//				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];
//
//				va_start(argumentList, pairCount);
//
//				for (int i=0; i<pairCount; i++) {
//					time = va_arg(argumentList, NSInteger);
//					hidden = (BOOL)va_arg(argumentList, int); // use int to suppress a va_arg conversion warning
//					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
//						andHidden:hidden];
//					[keyFrames addObject:keyFrame];
//				}
//
//				va_end(argumentList);
//
//				return [NSArray arrayWithArray:keyFrames];
//			}
//			else {
//				return nil;
//			}
		}

        public List<AnimationKeyFrame<int, UIColor>> KeyFramesWithTimesAndColors(AnimationType animationType, params Tuple<int, UIColor>[] pairCount)
		{
            return KeyFramesGeneric(animationType, pairCount);
//			va_list argumentList;
//			NSInteger time;
//			UIColor *color;
//			if (pairCount > 0) {
//				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];
//
//				va_start(argumentList, pairCount);
//
//				for (int i=0; i<pairCount; i++) {
//					time = va_arg(argumentList, NSInteger);
//					color = va_arg(argumentList, id);
//					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
//						andColor:color];
//					[keyFrames addObject:keyFrame];
//				}
//
//				va_end(argumentList);
//
//				return [NSArray arrayWithArray:keyFrames];
//			}
//			else {
//				return nil;
//			}
		}

        public List<AnimationKeyFrame<int, Single>> KeyFramesWithTimesAndAngles(AnimationType animationType, params Tuple<int, Single>[] pairCount)
	    {
            return KeyFramesGeneric(animationType, pairCount);
//			va_list argumentList;
//			NSInteger time;
//			CGFloat angle;
//			if (pairCount > 0) {
//				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];
//
//				va_start(argumentList, pairCount);
//
//				for (int i=0; i<pairCount; i++) {
//					time = va_arg(argumentList, NSInteger);
//					angle = (CGFloat)va_arg(argumentList, double);
//					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
//						andAngle:angle];
//					[keyFrames addObject:keyFrame];
//				}
//
//				va_end(argumentList);
//
//				return [NSArray arrayWithArray:keyFrames];
//			}
//			else {
//				return nil;
//			}
		}

        public List<AnimationKeyFrame<int, object>> KeyFramesWithTimesAndTransform3D(AnimationType animationType, params Tuple<int, object>[] pairCount)
        {
            return KeyFramesGeneric(animationType, pairCount);
//			va_list argumentList;
//			NSInteger time;
//			IFTTTTransform3D * transform;
//			if (pairCount > 0) {
//				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];
//
//				va_start(argumentList, pairCount);
//
//				for (int i=0; i<pairCount; i++) {
//					time = va_arg(argumentList, NSInteger);
//					transform = va_arg(argumentList, id);
//					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
//						andTransform3D:transform];
//					[keyFrames addObject:keyFrame];
//				}
//
//				va_end(argumentList);
//
//				return [NSArray arrayWithArray:keyFrames];
//			} else {
//				return nil;
//			}
		}

        public List<AnimationKeyFrame<int, Single>> KeyFramesWithTimesAndScales(AnimationType animationType, params Tuple<int, Single>[] pairCount)
        {
            return KeyFramesGeneric(animationType, pairCount);
//			va_list argumentList;
//			NSInteger time;
//			CGFloat scale;
//			if (pairCount > 0) {
//				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];
//
//				va_start(argumentList, pairCount);
//
//				for (int i=0; i<pairCount; i++) {
//					time = va_arg(argumentList, NSInteger);
//					scale = (CGFloat)va_arg(argumentList, double);
//					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime: time
//						andScale: scale];
//					[keyFrames addObject:keyFrame];
//				}
//
//				va_end(argumentList);
//
//				return [NSArray arrayWithArray:keyFrames];
//			} else {
//				return nil;
//			}
		}
	}

    public enum AnimationType
    {
        Frame,
        Alpha,
        Hidden,
        Color,
        Angle,
        Transform,
        Scale,
    }
}

