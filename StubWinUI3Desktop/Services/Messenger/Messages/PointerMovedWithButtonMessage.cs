using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;		// for Point
using Microsoft.UI.Input;		// for LocalPoint
using CommunityToolkit.Mvvm.Messaging.Messages;
using StubWinUI3Desktop.Services.Messenger;

namespace StubWinUI3Desktop.Services.Messenger.Messages
{
    public struct MouseButtonsStatus
    {
        public MouseButtonsStatus(bool _left_button, bool _middle_button, bool _right_button)
        {
            IsLeftButtonPressed = _left_button;
            IsMiddleButtonPressed = _middle_button;
            IsRightButtonPressed = _right_button;
        }
        public bool IsLeftButtonPressed { get; set; } = false;
        public bool IsMiddleButtonPressed { get; set; } = false;
        public bool IsRightButtonPressed { get; set; } = false;
    }
    internal class PointerMovedWithButtonMessage : ValueChangedMessage<MouseButtonsStatus>
    {
        private MouseButtonsStatus m_mouse_buttons_status;
        public PointerMovedWithButtonMessage(MouseButtonsStatus value) : base(value)
        {
            m_mouse_buttons_status = value;
        }
    }
}
