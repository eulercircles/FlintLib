using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Structures
{
	public sealed class LinkedList : ListNode
	{
		private ListNode _head;
		private ListNode _tail;

		protected override ListNode Next { get => null; set { } }
		protected override ListNode Prev { get => null; set { } }

		public void Add()
		{
			var node = new T();
			var listNode = (node as ListNode);
\		}
	}
}
