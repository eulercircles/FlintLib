using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Common
{
	public class Latch
	{
		private bool _isClosed = false;
		public bool IsClosed => _isClosed;

		public void Close() => _isClosed = true;
	}
}
