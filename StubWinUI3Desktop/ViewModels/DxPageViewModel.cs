using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;     // for RelayCommand, AsyncRelayCommand

namespace StubWinUI3Desktop.ViewModels
{
    internal class DxPageViewModel: ObservableObject
    {
        private double m_scp_width=640.0, m_scp_height=480.0;
        internal double SCPWidth
        {
            get { return m_scp_width; }
            set { m_scp_width = value; }
        }
        internal double SCPHeight
        {
            get { return m_scp_height; }
            set { m_scp_height = value; }
        }
        private double m_scp_x, m_scp_y, m_scp_z = 0.0f;
        internal double SCPX { get => m_scp_x; set => SetProperty(ref m_scp_x, value); }
        internal double SCPY { get => m_scp_y; set => SetProperty(ref m_scp_y, value); }
        internal double SCPZ { get => m_scp_z; set => SetProperty(ref m_scp_z, value); }
        /// <summary>
        /// flag to get pointer position or not
        /// </summary>
        internal RelayCommand<PointerRoutedEventArgs> SwapChainPanel_PointerWheelChangedCommand { get; private set; }
        private void SwapChainPanel_PointerWheelChanged(PointerRoutedEventArgs arges)
        {
            ;
        }
        internal RelayCommand<SizeChangedEventArgs> SwapChainPanel_SizeChangedCommand { get; private set; }
        private void SwapChainPanel_SizeChanged(SizeChangedEventArgs arges)
        {
            ;
        }
        internal DxPageViewModel()
        {
            SwapChainPanel_PointerWheelChangedCommand = new RelayCommand<PointerRoutedEventArgs>(SwapChainPanel_PointerWheelChanged);
            SwapChainPanel_SizeChangedCommand = new RelayCommand<SizeChangedEventArgs>(SwapChainPanel_SizeChanged);
        }
    }
}
