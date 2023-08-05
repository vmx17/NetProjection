using System;
using System.Threading.Tasks;

namespace ProtoCAD.Services.Logging
{
	public interface ILoggingService
	{
		Task Log(string message);
	}
}
