namespace Screenmedia.IFTTT.JazzHandsFSharpDemo

open System
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

        let unicorn = new UIImageView(UIImage.FromBundle("404_unicorn"))
        unicorn.Center <- base.View.Center

        base.ScrollView.AddSubview (unicorn)    





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

