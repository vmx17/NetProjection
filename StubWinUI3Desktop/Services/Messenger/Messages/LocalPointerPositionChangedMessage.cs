using Windows.Foundation;		// for Point
using Microsoft.UI.Input;		// for LocalPoint
using CommunityToolkit.Mvvm.Messaging.Messages;
using StubWinUI3Desktop.Services.Messenger;

namespace StubWinUI3Desktop.Services.Messenger.Messages
{
	public class LocalPointerPositionChangedMessage : ValueChangedMessage<PointerPoint>
	{
		private PointerPoint m_point;
		public Point CursorPosition { get => m_point.Position; }
		public LocalPointerPositionChangedMessage(PointerPoint value) : base(value)
		{
			m_point = value;
		}
	}
}
