using Windows.Foundation;		// for Point
using Microsoft.UI.Input;		// for LocalPoint
using CommunityToolkit.Mvvm.Messaging.Messages;
using StubWinUI3Desktop.Services.Messenger;

namespace StubWinUI3Desktop.Services.Messenger.Messages {

    public class NormalizedPointerPositionChangedMessage : ValueChangedMessage<Point>
	{
		private Point m_normalized_position;
		public Point NormalizedPosition { get => m_normalized_position; }
		public NormalizedPointerPositionChangedMessage(in Point value) : base(value)
		{
            m_normalized_position = value;
		}
	}
}
