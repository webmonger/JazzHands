using System;
using MonoTouch.UIKit;
using System.Drawing;

namespace Screenmedia.IFTTT.JazzHands
{
	public class AnimationKeyFrame
	{
		public int Time { get; set; }
		public Single Alpha { get; set; }
		public RectangleF Frame { get; set; }
		public bool Hidden { get; set; }
		public UIColor Color { get; set; }
		public Single Angle { get; set; }
		public Transform3D Transform { get; set; }
		public Single Scale { get; set; }

		public AnimationKeyFrame ()
		{
		}

		public NSArray KeyFramesWithTimesAndAlphas(params int[] pairCount)
		{
			int time;
			Single alpha;
			if (pairCount.Length > 0) {
				AnimationKeyFrame[] keyFrames = new AnimationKeyFrame[pairCount.Length];
				
				for (int i=0; i<pairCount; i++) {
						time = pairCount[i];
					alpha = (Single)va_arg(argumentList, double);   // use double to suppress a va_arg conversion warning
					AnimationKeyFrame keyFrame = [AnimationKeyFrame keyFrameWithTime:time
						andAlpha:alpha];
					[keyFrames addObject:keyFrame];
				}

				return [NSArray arrayWithArray:keyFrames];
			}
			else {
				return nil;
			}
		}

					public NSArray KeyFramesWithTimesAndFrames(int pairCount)
		{
			va_list argumentList;
			int time;
			RectangleF frame;
			if (pairCount > 0) {
				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];

				va_start(argumentList, pairCount);

				for (int i=0; i<pairCount; i++) {
					time = va_arg(argumentList, NSInteger);
					frame = va_arg(argumentList, CGRect);
					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
						andFrame:frame];
					[keyFrames addObject:keyFrame];
				}

				va_end(argumentList);

				return [NSArray arrayWithArray:keyFrames];
			}
			else {
				return nil;
			}
		}

		+ (NSArray *)keyFramesWithTimesAndHiddens:(NSInteger)pairCount,...
		{
			va_list argumentList;
			NSInteger time;
			BOOL hidden;
			if (pairCount > 0) {
				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];

				va_start(argumentList, pairCount);

				for (int i=0; i<pairCount; i++) {
					time = va_arg(argumentList, NSInteger);
					hidden = (BOOL)va_arg(argumentList, int); // use int to suppress a va_arg conversion warning
					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
						andHidden:hidden];
					[keyFrames addObject:keyFrame];
				}

				va_end(argumentList);

				return [NSArray arrayWithArray:keyFrames];
			}
			else {
				return nil;
			}
		}

		+ (NSArray *)keyFramesWithTimesAndColors:(NSInteger)pairCount,...
		{
			va_list argumentList;
			NSInteger time;
			UIColor *color;
			if (pairCount > 0) {
				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];

				va_start(argumentList, pairCount);

				for (int i=0; i<pairCount; i++) {
					time = va_arg(argumentList, NSInteger);
					color = va_arg(argumentList, id);
					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
						andColor:color];
					[keyFrames addObject:keyFrame];
				}

				va_end(argumentList);

				return [NSArray arrayWithArray:keyFrames];
			}
			else {
				return nil;
			}
		}

		+ (NSArray *)keyFramesWithTimesAndAngles:(NSInteger)pairCount, ... {
			va_list argumentList;
			NSInteger time;
			CGFloat angle;
			if (pairCount > 0) {
				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];

				va_start(argumentList, pairCount);

				for (int i=0; i<pairCount; i++) {
					time = va_arg(argumentList, NSInteger);
					angle = (CGFloat)va_arg(argumentList, double);
					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
						andAngle:angle];
					[keyFrames addObject:keyFrame];
				}

				va_end(argumentList);

				return [NSArray arrayWithArray:keyFrames];
			}
			else {
				return nil;
			}
		}

		+ (NSArray *)keyFramesWithTimesAndTransform3D:(NSInteger)pairCount, ...{
			va_list argumentList;
			NSInteger time;
			IFTTTTransform3D * transform;
			if (pairCount > 0) {
				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];

				va_start(argumentList, pairCount);

				for (int i=0; i<pairCount; i++) {
					time = va_arg(argumentList, NSInteger);
					transform = va_arg(argumentList, id);
					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime:time
						andTransform3D:transform];
					[keyFrames addObject:keyFrame];
				}

				va_end(argumentList);

				return [NSArray arrayWithArray:keyFrames];
			} else {
				return nil;
			}
		}

		+ (NSArray *)keyFramesWithTimesAndScales:(NSInteger)pairCount, ... {
			va_list argumentList;
			NSInteger time;
			CGFloat scale;
			if (pairCount > 0) {
				NSMutableArray *keyFrames = [NSMutableArray arrayWithCapacity:(NSUInteger)pairCount];

				va_start(argumentList, pairCount);

				for (int i=0; i<pairCount; i++) {
					time = va_arg(argumentList, NSInteger);
					scale = (CGFloat)va_arg(argumentList, double);
					IFTTTAnimationKeyFrame *keyFrame = [IFTTTAnimationKeyFrame keyFrameWithTime: time
						andScale: scale];
					[keyFrames addObject:keyFrame];
				}

				va_end(argumentList);

				return [NSArray arrayWithArray:keyFrames];
			} else {
				return nil;
			}
		}
	}
}

