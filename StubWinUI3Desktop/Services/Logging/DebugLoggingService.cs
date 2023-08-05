using System;
using System.Diagnostics;		// for Debug
using System.Threading.Tasks;

namespace ProtoCAD.Services.Logging
{
	/// <summary>
	/// refer to: https://xamlbrewer.wordpress.com/2020/11/16/a-lap-around-the-microsoft-mvvm-toolkit/comment-page-1/
	/// </summary>
	public class DebugLoggingService : ILoggingService
	{
		public Task Log(string message)
		{
			Debug.WriteLine(DateTime.UtcNow.ToString("UTC,yyyy/MM/dd,HH:mm:ss,") + message);	// for *.cvs
			return Task.FromResult(0);
		}
	}
}
