namespace Screenmedia.IFTTT.JazzHandsFSharpDemo

open System
open System.Drawing
open MonoTouch.UIKit
open MonoTouch.Foundation
open Screenmedia.IFTTT.JazzHands

type JHViewController() as this =
    inherit AnimatedScrollViewController() 

    let NumberOfPages = 4
            
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


        // Configure Animation



[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit UIApplicationDelegate ()

    let window = new UIWindow (UIScreen.MainScreen.Bounds)

    // This method is invoked when the application is ready to run.
    override this.FinishedLaunching (app, options) =
        // If you have defined a root view controller, set it here:
        window.RootViewController <- new JHViewController ()
        window.MakeKeyAndVisible ()
        true

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main (args, null, "AppDelegate")
        0

