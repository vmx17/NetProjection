using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

//using SimpleMathComponent;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace StubWinUI3Desktop.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DxPage : Page
    {
        private bool m_getPointer;
        public DxPage()
        {
            this.InitializeComponent();
            //var renderer = new SimpleMathComponent.BoxRenderer();
        }

        private void SCPBorder_Entered(object sender, PointerRoutedEventArgs args)
        {
            m_getPointer = true;
            args.Handled = true;
        }

        private void SCPBorder_Exited(object sender, PointerRoutedEventArgs args)
        {
            m_getPointer = false;
            args.Handled = true;
        }

        private void SCPBorder_PointerCaptureLost(object sender, PointerRoutedEventArgs args)
        {
            m_getPointer = false;
            args.Handled = true;
        }

        private void SCPPointer_Moved(object sender, PointerRoutedEventArgs args)
        {
            if (m_getPointer)
            {
                PointerPoint p = args.GetCurrentPoint(nuGetSwapChainPanel);
                viewModel.SCPX = p.Position.X / nuGetSwapChainPanel.ActualWidth;
                viewModel.SCPY = p.Position.Y / nuGetSwapChainPanel.ActualHeight;
            }
            args.Handled = true;
        }

        private void SCPBorder_SizeChanged(object sender, SizeChangedEventArgs args)
        {
            var sz = args.NewSize;
            viewModel.SCPWidth = sz.Width;
            viewModel.SCPHeight = sz.Height;
        }
    }
}
