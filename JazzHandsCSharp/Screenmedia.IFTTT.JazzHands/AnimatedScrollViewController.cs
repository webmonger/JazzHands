using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using MonoTouch.ObjCRuntime;

namespace Screenmedia.IFTTT.JazzHands
{

	public interface IAnimatedScrollViewController 
	{
		NSObject WeakDelegate { get; set; }
		void AnimatedScrollViewControllerDidScrollToEnd(AnimatedScrollViewController animatedScrollViewController);
		void AnimatedScrollViewControllerDidEndDraggingAtEnd(AnimatedScrollViewController animatedScrollViewController);
	}


	public class AnimatedScrollViewController : UIViewController, IUIScrollViewDelegate
	{
		//public delegate void AnimatedScrollViewControllerDelegate();

		public Animator Animator{ get; set; }
		public UIScrollView ScrollView { get; set; }

		public IAnimatedScrollViewController animatedScrolledService;

		private bool _isAtEnd;

		static Single MaxContentOffsetXForScrollView(UIScrollView scrollView)
		{
			return scrollView.ContentSize.Width + scrollView.ContentInset.Right - scrollView.Bounds.Width;
		}

		public AnimatedScrollViewController (string nibName, NSBundle bundle) : base(nibName, bundle)
		{
			_isAtEnd = false;
			Animator = new Animator();
			//animatedScrolledService = Resolve<> new IAnimatedScrollViewController ();

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ScrollView = new UIScrollView(this.View.Bounds);
			ScrollView.Scrolled +=  (sender, args) =>
			{
				Animator.Animate(Convert.ToInt32(ScrollView.ContentOffset.X));

				_isAtEnd = ScrollView.ContentOffset.X >= MaxContentOffsetXForScrollView(ScrollView);

				//animatedScrolledService = ScrollView.Delegate;

				if (_isAtEnd && this.RespondsToSelector(new Selector("AnimatedScrollViewControllerDidScrollToEnd:")))
				{
					//animatedScrolledService.AnimatedScrollViewControllerDidScrollToEnd(this);
				}
			};

			ScrollView.ScrollAnimationEnded += (sender, args) => 
			{
				//WeakDelegate = scrollView.Delegate;
				//animatedScrolledService =  ScrollView.Delegate;

				if (_isAtEnd && this.RespondsToSelector(new Selector("AnimatedScrollViewControllerDidEndDraggingAtEnd:")))
				{
					//animatedScrolledService.AnimatedScrollViewControllerDidEndDraggingAtEnd(this);
				}
			};

			this.View.Add(ScrollView);
		}

	}
}

