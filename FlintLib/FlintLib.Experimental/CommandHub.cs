using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Experimental
{
	internal static class CommandHub
	{
		public static ActionCommand PerformMethod { get; set; }
		public static ActionCommand<int> SetSomeValue { get; set; }
		public static FunctionCommand<string> GetName { get; set; }
		public static FunctionCommand<string, int> GetValueByKey { get; set; }
	}
}
