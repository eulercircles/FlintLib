using System;

namespace FLib.Structures.Generic
{
	public class Node4<T>
	{
		public T Value { get; set; }

		public Node4<T> NENode { get; private set; }
		public Node4<T> NWNode { get; private set; }
		public Node4<T> SWNode { get; private set; }
		public Node4<T> SENode { get; private set; }

		public Node4(T initialValue)
		{
			Value = initialValue;
		}
	}
}
