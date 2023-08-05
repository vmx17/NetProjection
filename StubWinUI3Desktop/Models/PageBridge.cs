using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging; // for Messenger.Register
using Microsoft.UI.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;	// for Point
using StubWinUI3Desktop.Services.Messenger.Messages;

namespace StubWinUI3Desktop.Models
{
    public class PageBridge : ObservableRecipient
    {
        private string m_path;
        public string FilePath { get => m_path; set => SetProperty(ref m_path, value); }
        PointerPoint m_point;
        public PointerPoint PointerPoint { get => m_point; set => SetProperty(ref m_point, value); }
        Point m_normalized_point;
        public Point NormalizedPointerPoint { get => m_normalized_point; set => SetProperty(ref m_normalized_point, value); }
        MouseButtonsStatus m_mouse_buttons;
        public MouseButtonsStatus MouseButtons { get => m_mouse_buttons; set => SetProperty(ref m_mouse_buttons, value); }
        private Guid m_drawPageID = Guid.Empty;
        public Guid DrawPageID { get => m_drawPageID; set => SetProperty(ref m_drawPageID, value); }
        public PageBridge(Guid g)
        {
            DrawPageID = g;
            Messenger.Register<LocalPointerPositionChangedMessage>(this, (r, m) =>
            {
                if (r != null)
                {
                    PointerPoint = m.Value;
                }
            });
            Messenger.Register<NormalizedPointerPositionChangedMessage>(this, (r, m) =>
            {
                if (r != null)
                {
                    NormalizedPointerPoint = m.Value;
                }
            });
            Messenger.Register<PointerMovedWithButtonMessage>(this, (r, m) =>
            {
                if (r != null)
                {
                    MouseButtons = m.Value;
                }
            });
        }
    }
}
