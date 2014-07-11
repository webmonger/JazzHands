namespace Screenmedia.IFTTT.JazzHandsFSharpDemo

open System
open System.Drawing
open MonoTouch.UIKit
open MonoTouch.Foundation
open Screenmedia.IFTTT.JazzHands

type JHViewController() as this =
    inherit AnimatedScrollViewController() 

    let timeForPage page = this.View.Frame.Size.Width * (page - 1.0f)

    let addLabel text isOffset page y : UILabel = 
        let l = new UILabel()
        l.Text <- text
        l.SizeToFit()
        l.Center <- this.View.Center
        if isOffset then
            let rect : RectangleF = l.Frame
            rect.Offset (new PointF (timeForPage (page), y))
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

        let firstLabel : UILabel = addLabel "Introducing Jazz Hands" false 0.0f 0.0f
        base.ScrollView.AddSubview(firstLabel)
        let secondPageText : UILabel = addLabel "Brought to you by IFTTT" true 2.0f 180.0f
        base.ScrollView.AddSubview(secondPageText)
        let thirdPageText : UILabel = addLabel "Simple keyframe animations" true 3.0f -100.0f
        base.ScrollView.AddSubview(thirdPageText)
        let fourthPageText : UILabel = addLabel "Optimized for scrolling intros" true 4.0f 0.0f
        base.ScrollView.AddSubview(fourthPageText)

        // Configure Animation
//        let dy = 240

        // let's animate the wordmark
//        var wordmarkFrameAnimation = new FrameAnimation(Wordmark);
//        Animator.AddAnimation(wordmarkFrameAnimation);
//
//        var newAnimaitons = new List<AnimationKeyFrame> ();
//
//        var temp1 = Wordmark.Frame;
//        temp1.Offset (new PointF (200, 0));
//
//        newAnimaitons.Add (new AnimationKeyFrame () {
//            Time = TimeForPage (1),
//            Frame = temp1
//        });
//
//        newAnimaitons.Add (new AnimationKeyFrame() {Time = TimeForPage(2), Frame = Wordmark.Frame});


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

