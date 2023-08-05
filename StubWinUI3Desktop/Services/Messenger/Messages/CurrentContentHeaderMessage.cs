using System;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace StubWinUI3Desktop.Services.Messenger.Messages
{
	public class CurrentContentHeaderMessage : ValueChangedMessage<string>
	{
		public CurrentContentHeaderMessage(string value) : base(value)
		{
		}
	}
}
