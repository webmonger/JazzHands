using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Screenmedia.IFTTT.JazzHands
{
	public class AnimatedScrollViewController : UIViewController, IUIScrollViewDelegate
	{
		public delegate void AnimatedScrollViewControllerDelegate();

		public Animator Animator{ get; set; }
		public UIScrollView ScrollView { get; set; }

		private bool _isAtEnd;

		static Single MaxContentOffsetXForScrollView(UIScrollView scrollView)
		{
			return scrollView.ContentSize.Width + scrollView.ContentInset.Right - scrollView.Bounds.Width;
		}

		public AnimatedScrollViewController (string nibName, NSBundle bundle) : base(nibName, bundle)
		{
			_isAtEnd = false;
			Animator = new Animator();

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			ScrollView = new UIScrollView(this.View.Bounds);
			ScrollView.Delegate = this;
			this.View.Add(ScrollView);
		}

		public void ScrollViewDidScroll(UIScrollView aScrollView)
		{
			Animator.Animate(Convert.ToInt32(aScrollView.ContentOffset.X));

			_isAtEnd = aScrollView.ContentOffset.X >= MaxContentOffsetXForScrollView(aScrollView);

			Delegate = self.delegate;

			if (_isAtEnd && [delegate respondsToSelector:@selector(AnimatedScrollViewControllerDidScrollToEnd:)]) {
				Delegate = AnimatedScrollViewControllerDidScrollToEnd(this);
			}
		}

		public void ScrollViewDidEndDragging(UIScrollView scrollView, bool willDecelerate)
		{
			delegate = self.delegate;

			if (_isAtEnd && [delegate respondsToSelector:@selector(AnimatedScrollViewControllerDidEndDraggingAtEnd:)]) {
				Delegate = AnimatedScrollViewControllerDidEndDraggingAtEnd(this);
			}
		}

		/**
 *  The user has scrolled to the last page of the scrollview.
 *
 *  @param animatedScrollViewController the scroll view controller that's been scrolled
 */
		public delegate void AnimatedScrollViewControllerDidScrollToEnd(AnimatedScrollViewController animatedScrollViewController);

		/**
 *  The user has released the scrollview (ended dragging) at the last page of the scrollview.
 *
 *  @param animatedScrollViewController the scroll view controller that's been scrolled
 */
		public delegate void AnimatedScrollViewControllerDidEndDraggingAtEnd(AnimatedScrollViewController animatedScrollViewController);

	}
}

