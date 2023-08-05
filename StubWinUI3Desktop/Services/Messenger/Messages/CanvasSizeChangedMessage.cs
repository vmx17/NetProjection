using Windows.Foundation;		// for Size, Point
using Microsoft.UI.Input;		// for LocalPoint
using CommunityToolkit.Mvvm.Messaging.Messages;
using StubWinUI3Desktop.Services.Messenger;

namespace StubWinUI3Desktop.Services.Messenger.Messages
{
	// this message is to propergate ActualSize of the SwapChainPanel
	public class CanvasSizeChangedMessage : ValueChangedMessage<Size>
	{
		private Size m_size;
		public Size CanvasSize { get => m_size; }
		public double CanvasWidth { get => m_size.Width; }
		public double CanvasHeight { get => m_size.Height; }
		public CanvasSizeChangedMessage(Size size) : base(size)
		{
			m_size = size;
		}
	}
}
