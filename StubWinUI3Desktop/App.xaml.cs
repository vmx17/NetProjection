using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.UI.Xaml.Shapes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using static PInvoke.User32;
using StubWinUI3Desktop.Views;
using StubWinUI3Desktop.Models;
using System.Collections.ObjectModel;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace StubWinUI3Desktop
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public partial class App : Application
    {
        static ObservableCollection<WindowManager> WindowManagers;
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            WindowManagers = new ObservableCollection<WindowManager>();
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            if (WindowManagers.Count == 0)
                AddMainWindow(args);
        }
        private static void AddMainWindow(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {
            var wm = new WindowManager();
            WindowManagers.Add(wm);
            wm.BindedWindow = new MainWindow(wm.WinID);
            wm.WindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(wm.BindedWindow);
            wm.BindedWindow.Title = $"Window:" + wm.WinID.ToString("D");
            // WinUI 3's Window does not have Width and Height. So use the Win32 API
            SetWindowDetails(ref wm, 1440, 900);
            //wm.theWindow.Activate();	// --> called by XAML
            WindowManagers.Last().BindedWindow.Activate();
        }
        private static void SetWindowDetails(ref WindowManager manager, int _width, int _height)
        {
            // Win32 uses pixels and WinUI 3 uses effective pixels, so you should apply the DPI scale factor
            manager.Dpi = PInvoke.User32.GetDpiForWindow(manager.WindowHandle);
            manager.ScalingFactor = (float)manager.Dpi / 96;
            int width = (int)(_width * manager.ScalingFactor);
            int height = (int)(_height * manager.ScalingFactor);

            _ = SetWindowPos(manager.WindowHandle, PInvoke.User32.SpecialWindowHandles.HWND_TOP,
                    0, 0, width, height,
                    PInvoke.User32.SetWindowPosFlags.SWP_NOMOVE);
            _ = SetWindowLong(manager.WindowHandle,
                    WindowLongIndexFlags.GWL_STYLE,
                    (SetWindowLongFlags)(GetWindowLong(manager.WindowHandle,
                        WindowLongIndexFlags.GWL_STYLE) &
                        ~(int)SetWindowLongFlags.WS_MINIMIZEBOX &
                        ~(int)SetWindowLongFlags.WS_MAXIMIZEBOX));
        }
    }
}
