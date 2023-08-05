using System;
using CommunityToolkit.Mvvm.Messaging.Messages;
using StubWinUI3Desktop.Services.Messenger;

namespace StubWinUI3Desktop.Services.Messenger.Messages
{
	public class CurrentPageSwitchedMessage : ValueChangedMessage<Guid>
	{
		public CurrentPageSwitchedMessage(Guid value) : base(value)
		{
		}
	}
}
