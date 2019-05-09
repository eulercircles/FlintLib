using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLib.Diagnostics
{
	public interface ILogger
	{
		void WriteEntry(LogEntry entry);
	}
}
