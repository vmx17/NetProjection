using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging; // for Messenger.Register
using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;   // for Size, Point
using StubWinUI3Desktop.Services.Messenger.Messages;

namespace StubWinUI3Desktop.Models
{
    public class WindowManager : ObservableRecipient
    {
        /// <summary>
        /// window itself corresponds to this WindowManager
        /// </summary>
        public Window BindedWindow { get; set; }
        private Guid m_winId;
        public Guid WinID { get => m_winId; set => SetProperty(ref m_winId, value); }

        private static Dictionary<Guid, PageBridge> m_bridges = new();
        public static int BridgeCount { get => m_bridges.Count; }
        
        public IntPtr WindowHandle { get; set; }
        
        private float m_scalingFactor = 1.0f;
        public float ScalingFactor { get => m_scalingFactor; set => SetProperty(ref m_scalingFactor, value); }
        
        private int m_dpi = 96;
        public int Dpi { get => m_dpi; set => SetProperty(ref m_dpi, value); }
        
        private Size m_canvasSize = Size.Empty;
        public Size CanvasSize { get => m_canvasSize; set => SetProperty(ref m_canvasSize, value); }

        //private static List<PageBridge> pageBridges = new List<PageBridge>();
        private PageBridge m_bridge = null;
        public PageBridge CurrentBridge { get => m_bridge; set => SetProperty(ref m_bridge, value); }

        public WindowManager()
        {
            WinID = Guid.NewGuid();     // origin of WindowID
            Messenger.Register<CanvasSizeChangedMessage>(this, (r, m) =>
            {
                CanvasSize = m.Value;
            });
        }
        public Guid AddNewBridge()
        {
            var guid = Guid.NewGuid();
            m_bridges.Add(guid, new PageBridge(guid));  // Add first,
            SetCurrent(guid);                           // Point second.
            return guid;
        }
        public void SetCurrent(Guid n)
        {
            if (n != Guid.Empty)
            {
                CurrentBridge = (PageBridge)m_bridges[n];
                Messenger.Send(new CurrentPageSwitchedMessage(n));
            }
        }

        public static void Remove(Guid pageID)
        {
            m_bridges.Remove(pageID);
        }
    }
}
