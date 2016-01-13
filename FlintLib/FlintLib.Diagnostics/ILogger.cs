using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Diagnostics
{
	public interface ILogger
	{
		void LogException(Exception exception);
	}
}
