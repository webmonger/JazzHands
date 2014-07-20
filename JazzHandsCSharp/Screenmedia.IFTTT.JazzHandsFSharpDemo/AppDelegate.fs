namespace Screenmedia.IFTTT.JazzHandsFSharpDemo

open System
open System.Linq
open System.Collections.Generic
open System.Drawing
open MonoTouch.UIKit
open MonoTouch.Foundation
open Screenmedia.IFTTT.JazzHands

type JHViewController() as this =
    inherit AnimatedScrollViewController() 

    let timeForPage page : int = (int)this.View.Frame.Size.Width * (page - 1)

    let addLabel text isOffset page y : UILabel = 
        let l = new UILabel()
        l.Text <- text
        l.SizeToFit()
        l.Center <- this.View.Center
        if isOffset then
            let rect : RectangleF = l.Frame
            let pageOffSet = timeForPage (page)
            rect.Offset (new PointF (float32 pageOffSet, y))
            l.Frame <- rect
        l

    let numberOfPages = 4.0f
            
//    let ProductCellRowHeight = 300.0f
//
//    let source = new ProductListViewSource(fun x-> this.ProductTapped(x))
//
//    let GetData () = async {
//        let! products = WebService.Shared.GetProducts ()
//        source.Products <- products
//        WebService.Shared.PreloadImages(320.0f * UIScreen.MainScreen.Scale) |> Async.StartImmediate
//        this.TableView.ReloadData () }
//
//    do // Hide the back button text when you leave this View Controller.
//       this.NavigationItem.BackBarButtonItem <- new UIBarButtonItem ("", UIBarButtonItemStyle.Plain, handler=null)
//       this.TableView.SeparatorStyle <- UITableViewCellSeparatorStyle.None
//       this.TableView.RowHeight <- ProductCellRowHeight
//       this.TableView.Source <- source :> UITableViewSource
//
//       GetData () |> Async.StartImmediate
//
//    member val ImageWidth = UIScreen.MainScreen.Bounds.Width * UIScreen.MainScreen.Scale with get
//    member val ProductTapped = (fun (x:Product)->()) with get,set


    override this.ViewDidLoad () = 
        base.ViewDidLoad ()

        base.ScrollView.ContentSize <-  new SizeF (numberOfPages * this.View.Frame.Width, this.View.Frame.Height)

        base.ScrollView.PagingEnabled <- true
        base.ScrollView.ShowsHorizontalScrollIndicator <- false

        // Place Views
        let unicorn = new UIImageView(UIImage.FromBundle("404_unicorn"))
        unicorn.Center <- base.View.Center
        unicorn.Alpha <- 0.0f
        let rect = unicorn.Frame
        rect.Offset (new PointF ( base.View.Frame.Width, -100.0f));
        unicorn.Frame <- rect;
        base.ScrollView.AddSubview (unicorn)    

        let wordmark = new UIImageView(UIImage.FromBundle("IFTTT"))
        wordmark.Center <- base.View.Center
        let rect2 = wordmark.Frame;
        rect2.Offset (new PointF ( base.View.Frame.Width, -100.0f));
        wordmark.Frame <- rect2;
        base.ScrollView.AddSubview(wordmark);

        let firstLabel : UILabel = addLabel "Introducing Jazz Hands" false 0 0.0f
        base.ScrollView.AddSubview(firstLabel)
        let secondPageText : UILabel = addLabel "Brought to you by IFTTT" true 2 180.0f
        base.ScrollView.AddSubview(secondPageText)
        let thirdPageText : UILabel = addLabel "Simple keyframe animations" true 3 -100.0f
        base.ScrollView.AddSubview(thirdPageText)
        let fourthPageText : UILabel = addLabel "Optimized for scrolling intros" true 4 0.0f
        base.ScrollView.AddSubview(fourthPageText)

        // Configure Animation
        let dy : float32 = 240.0f

        // let's animate the wordmark
        let wordmarkFrameAnimation = new FrameAnimation(wordmark)
        base.Animator.AddAnimation(wordmarkFrameAnimation)

        let newAnimaitons = new List<AnimationKeyFrame>()

        let temp1 = wordmark.Frame;
        temp1.Offset (new PointF (200.0f, 0.0f));

        let animationKeyFrame1 = new AnimationKeyFrame ()
        animationKeyFrame1.Time <- timeForPage(1)
        animationKeyFrame1.Frame <- temp1

        newAnimaitons.Add (animationKeyFrame1)

        let animationKeyFrame2 = new AnimationKeyFrame ()
        animationKeyFrame2.Time <- timeForPage(2)
        animationKeyFrame2.Frame <- wordmark.Frame

        newAnimaitons.Add (animationKeyFrame2)

        let temp2 = wordmark.Frame;
        temp2.Offset (new PointF (base.View.Frame.Width, dy));

        let animationKeyFrame3 = new AnimationKeyFrame ()
        animationKeyFrame3.Time <- timeForPage (3)
        animationKeyFrame3.Frame <- temp2

        newAnimaitons.Add (animationKeyFrame3)

        let temp3 = wordmark.Frame;
        temp3.Offset (new PointF (0.0f, dy));

        let animationKeyFrame4 = new AnimationKeyFrame ()
        animationKeyFrame4.Time <- timeForPage (4)
        animationKeyFrame4.Frame <- temp3

        newAnimaitons.Add (animationKeyFrame4)

        wordmarkFrameAnimation.AddKeyFrames(newAnimaitons);


    interface IAnimatedScrollViewController with
        member x.WeakDelegate
            with get (): NSObject = 
                raise (System.NotImplementedException())
        
        member x.WeakDelegate
            with set (v: NSObject): unit = 
                raise (System.NotImplementedException())
        
        member x.AnimatedScrollViewControllerDidScrollToEnd(animatedScrollViewController: AnimatedScrollViewController): unit = 
            System.Console.WriteLine "Scrolled to end of scrollview!"
        
        member x.AnimatedScrollViewControllerDidEndDraggingAtEnd(animatedScrollViewController: AnimatedScrollViewController): unit = 
            System.Console.WriteLine "Scrolled to end of scrollview!"

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit UIApplicationDelegate ()

    let window = new UIWindow (UIScreen.MainScreen.Bounds)

    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching (app, options) =
        // If you have defined a root view controller, set it here:
        window.RootViewController <- new JHViewController ()
        window.BackgroundColor <- UIColor.White
        window.MakeKeyAndVisible ()
        true

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main (args, null, "AppDelegate")
        0

