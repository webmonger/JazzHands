﻿
using System;
using System.Collections.Generic;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Screenmedia.IFTTT.JazzHands;



namespace Screenmedia.IFTTT.JazzHandsDemo
{
	public class JHViewController : AnimatedScrollViewController, IAnimatedScrollViewController
	{
		private const int NumberOfPages = 5;

		public UIImageView Wordmark { get; set;}
		public UIImageView Unicorn { get; set;}
		public UILabel LastLabel { get; set;}
		public UILabel FirstLabel { get; set;}
		public UITextField InputText { get; set;}
		public UIButton InputButton { get; set;}


		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ScrollView.ContentSize = new SizeF (NumberOfPages * View.Frame.Width, View.Frame.Height);

			ScrollView.PagingEnabled = true;
			ScrollView.ShowsHorizontalScrollIndicator = false;

			// Perform any additional setup after loading the view, typically from a nib.
		    PlaceViews();
		    ConfigureAnimation();
		}

		private void PlaceViews ()
		{
			// put a unicorn in the middle of page two, hidden
            Unicorn = new UIImageView(UIImage.FromBundle("404_unicorn"));
			Unicorn.Center = View.Center;
			Unicorn.Alpha = 0.0f;
			var rect = Unicorn.Frame;
			rect.Offset (new PointF ( View.Frame.Width, -100));
			Unicorn.Frame = rect;
			ScrollView.AddSubview(Unicorn);


			// put a logo on top of it
            Wordmark = new UIImageView(UIImage.FromBundle("IFTTT"));
			Wordmark.Center = View.Center;
			var rect2 = Wordmark.Frame;
			rect2.Offset (new PointF ( View.Frame.Width, -100));
			Wordmark.Frame = rect2;
			ScrollView.AddSubview(Wordmark);

			FirstLabel = AddLabel ("Introducing Jazz Hands", false);
			ScrollView.AddSubview(FirstLabel);
			UILabel secondPageText = AddLabel ("Brought to you by IFTTT", true, 2, 180);
			ScrollView.AddSubview(secondPageText);
			UILabel thirdPageText = AddLabel ("Simple keyframe animations", true, 3, -100);
			ScrollView.AddSubview(thirdPageText);
			UILabel fourthPageText = AddLabel ("Optimized for scrolling intros", true, 4, 0);
			ScrollView.AddSubview(fourthPageText);

			InputText = AddTextField ("Animation Test", true, 5, 0);

			//InputText.TranslatesAutoresizingMaskIntoConstraints = false;

			InputText.AddConstraints (new[] {
				NSLayoutConstraint.Create (InputText, NSLayoutAttribute.Height, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 30),
				NSLayoutConstraint.Create (InputText, NSLayoutAttribute.Width, NSLayoutRelation.Equal, null, NSLayoutAttribute.NoAttribute, 1, 180),
			});


			ScrollView.Add (InputText);

			ScrollView.AddConstraints (new[] {
				NSLayoutConstraint.Create (InputText, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ScrollView, NSLayoutAttribute.Left, 1, (View.Frame.Size.Width * 4)+50),
				NSLayoutConstraint.Create (InputText, NSLayoutAttribute.Top, NSLayoutRelation.Equal, ScrollView, NSLayoutAttribute.Top, 1, 130),
			});

			View.LayoutIfNeeded ();

			LastLabel = fourthPageText;
		}


		int TimeForPage(float page)
		{
			return (int)(View.Frame.Size.Width * (page - 1));
		}

		private UILabel AddLabel(string text, bool IsOffset, int page = 0, float y = 0)
		{
			var l = new UILabel();
			l.Text = text;
			l.SizeToFit();
			l.Center = View.Center;
			if (IsOffset) 
			{
				var rect = l.Frame;
				rect.Offset (new PointF (TimeForPage (page), y));
				l.Frame = rect;
			}
			return l;
		}

		private UITextField AddTextField(string text, bool IsOffset, int page = 0, float y = 0)
		{
			var l = new UITextField();
			l.Text = text;
			l.SizeToFit();
			l.Center = View.Center;
			l.BackgroundColor = UIColor.Gray;
			if (IsOffset) 
			{
				var rect = l.Frame;
				rect.Offset (new PointF (TimeForPage (page), y));
				l.Frame = rect;
			}
			return l;
		}

	    private void ConfigureAnimation()
	    {
	        Single dy = 240;
            // apply a 3D zoom animation to the first label
			Transform3DAnimation labelTransform = new Transform3DAnimation(FirstLabel, 0.3f);
	        Transform3D tt1 = new Transform3D() {M34 = 0.03f};
	        Transform3D tt2 = new Transform3D() {M34 = 0.3f};
	        tt2.Rotate = new Transform3DRotate {Angle = Convert.ToSingle(Math.PI), X = 1, Y = 0, Z = 0};
	        tt2.Translate = new Transform3DTranslate() {Tx = 320, Ty = 150, Tz = -50};
			tt2.Scale = new Transform3DScale(){ Sx = 1.0f,Sy = 1.0f,Sz = 1.0f };
	        labelTransform.AddKeyFrame(new AnimationKeyFrame()
	        {
	            Time= TimeForPage(0),
	            Alpha = 1.0f
	        });
	        labelTransform.AddKeyFrame(new AnimationKeyFrame()
	        {
	            Time = TimeForPage(1),
	            Transform = tt1
	        });
	        labelTransform.AddKeyFrame(new AnimationKeyFrame()
	        {
	            Time = TimeForPage(1.5f),
	            Transform = tt2
	        });
//	        labelTransform.AddKeyFrame(new AnimationKeyFrame()
//	        {
//	            Time = TimeForPage(1.5f) + 1,
//	            Alpha = 0.0f
//	        });
	        Animator.AddAnimation(labelTransform);

	        // let's animate the wordmark
	        var wordmarkFrameAnimation = new FrameAnimation(Wordmark);
	        Animator.AddAnimation(wordmarkFrameAnimation);

			var newAnimaitons = new List<AnimationKeyFrame> ();

			var temp1 = Wordmark.Frame;
			temp1.Offset (new PointF (200, 0));

			newAnimaitons.Add (new AnimationKeyFrame () {
				Time = TimeForPage (1),
				Frame = temp1
			});

			newAnimaitons.Add (new AnimationKeyFrame() {Time = TimeForPage(2), Frame = Wordmark.Frame});


			var temp2 = Wordmark.Frame;
			temp2.Offset (new PointF (View.Frame.Width, dy));

			newAnimaitons.Add (new AnimationKeyFrame () {
				Time = TimeForPage (3),
				Frame = temp2
			});

			var temp3 = Wordmark.Frame;
			temp3.Offset (new PointF (0, dy));

			newAnimaitons.Add (new AnimationKeyFrame () {
				Time = TimeForPage (4),
				Frame =temp3
			});

			wordmarkFrameAnimation.AddKeyFrames(newAnimaitons);

	        //Rotate a full circle from page 2 to 3
			var wordmarkRotationAnimation = new AngleAnimation (Wordmark);
			Animator.AddAnimation (wordmarkRotationAnimation);
		    wordmarkRotationAnimation.AddKeyFrames(
		        new List<AnimationKeyFrame>()
		        {
		            new AnimationKeyFrame()
		            {
		                Time = TimeForPage(2),
		                Angle = 0.0f
		            },
		            new AnimationKeyFrame()
		            {
		                Time = TimeForPage(3),
		                Angle = Convert.ToSingle(2*Math.PI)
		            }
		        });

            // now, we animate the unicorn
			FrameAnimation unicornFrameAnimation = new FrameAnimation(Unicorn);
			Animator.AddAnimation (unicornFrameAnimation);

			float ds = 50f;

			// move down and to the right, and shrink between pages 2 and 3
			unicornFrameAnimation.AddKeyFrame (new AnimationKeyFrame {
				Time = TimeForPage (2),
				Frame = Unicorn.Frame
			});

			Unicorn.Frame = RectangleF.Inflate (Unicorn.Frame, -ds, -ds);
			var uTemp1 = Unicorn.Frame;
			uTemp1.Offset (TimeForPage (2), dy);
			Unicorn.Frame = uTemp1;

		    var animKeyFrame = new AnimationKeyFrame
		    {
		        Time = TimeForPage(3),
				Frame = Unicorn.Frame
		    };
		    unicornFrameAnimation.AddKeyFrame(animKeyFrame);

			// fade the unicorn in on page 2 and out on page 4
		    AlphaAnimation unicornAlphaAnimation = new AlphaAnimation(Unicorn);
            Animator.AddAnimation(unicornAlphaAnimation);

		    unicornAlphaAnimation.AddKeyFrame(new AnimationKeyFrame()
		    {
		        Time = TimeForPage(1),
		        Alpha = 0.0f
		    });
		    unicornAlphaAnimation.AddKeyFrame(new AnimationKeyFrame()
		    {
		        Time = TimeForPage(2),
		        Alpha = 1.0f
		    });
		    unicornAlphaAnimation.AddKeyFrame(new AnimationKeyFrame()
		    {
		        Time = TimeForPage(3),
		        Alpha = 1.0f
		    });
            unicornAlphaAnimation.AddKeyFrame(new AnimationKeyFrame()
            {
                Time = TimeForPage(4),
                Alpha = 0.0f
            });

			// Fade out the label by dragging on the last page
			AlphaAnimation labelAlphaAnimation = new AlphaAnimation(this.LastLabel);

			labelAlphaAnimation.AddKeyFrame(new AnimationKeyFrame()
				{
					Time = TimeForPage(4),
					Alpha = 1.0f
				});
			labelAlphaAnimation.AddKeyFrame(new AnimationKeyFrame()
				{
					Time = TimeForPage(4.35f),
					Alpha = 0.0f
				});
			Animator.AddAnimation(labelAlphaAnimation);

			//Constraint Animation on textfield of last page

			ConstraintsAnimation textFieldConstraintAnimation = new ConstraintsAnimation (this.InputText);

			textFieldConstraintAnimation.AddKeyFrame (new AnimationKeyFrame ()
				{ 
					Time = TimeForPage(4),
					constraintConstant=180
				});

			textFieldConstraintAnimation.AddKeyFrame (new AnimationKeyFrame ()
				{ 
					Time = TimeForPage(4.50f),
					constraintConstant=200
				});

			textFieldConstraintAnimation.AddKeyFrame (new AnimationKeyFrame ()
				{ 
					Time = TimeForPage(5),
					constraintConstant=80
				});



			Animator.AddAnimation(textFieldConstraintAnimation);
			
		}

		#region IAnimatedScrollViewController implementation

	    public NSObject WeakDelegate { get; set; }

	    public void AnimatedScrollViewControllerDidScrollToEnd (AnimatedScrollViewController animatedScrollViewController)
		{
			System.Console.WriteLine(@"Scrolled to end of scrollview!");
		}

		public void AnimatedScrollViewControllerDidEndDraggingAtEnd (AnimatedScrollViewController animatedScrollViewController)
		{
			System.Console.WriteLine(@"Scrolled to end of scrollview!");
		}

		#endregion
	}
}

