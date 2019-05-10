using AppKit;
using Foundation;
using INTEGRA_7;
using INTEGRA_7.MacOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.MacOS;

[assembly: Dependency(typeof(MIDI))]

namespace INTEGRA_7_MacOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        NSWindow mainPage_MacOS;
        public INTEGRA_7.MainPage MainPage_Portable { get; set; }
        public override NSWindow MainWindow
        {
            get { return mainPage_MacOS; }
        }

        public AppDelegate()
        {
            var style = NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled;
            var rect = new CoreGraphics.CGRect(200, 200, 1650, 1100);
            mainPage_MacOS = new NSWindow(rect, style, NSBackingStore.Buffered, false);
            mainPage_MacOS.Title = "Roland INTEGRA-7 Librarian and Editor";
        }

        public override void DidFinishLaunching(NSNotification notification)
        {
            Forms.Init();
            LoadApplication(new INTEGRA_7.App());
            UIHandler.appType = UIHandler._appType.MacOS;
            MainPage_Portable = INTEGRA_7.MainPage.GetMainPage();
            MainPage_Portable.uIHandler.DrawLibrarianPage();
            MainPage_Portable.SetDeviceSpecificMainPage(this);
            MainPage_Portable.uIHandler.ShowPleaseWaitPage(WaitingFor.CONNECTION, UIHandler.CurrentPage.LIBRARIAN, null);

            base.DidFinishLaunching(notification);
        }

        public override void WillTerminate(NSNotification notification)
        {
        }
    }
}