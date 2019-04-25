using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Structures
{
	public abstract class ListNode
	{
		protected abstract ListNode Next { get; set; }
		protected abstract ListNode Prev { get; set; }
	}
}
