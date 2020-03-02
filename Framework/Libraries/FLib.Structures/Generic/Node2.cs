using System;

namespace FLib.Structures.Generic
{
	public abstract class Node2<T>
	{
		private T _value;

		public Node2<T> LNode { get; protected set; }
		public Node2<T> RNode { get; protected set; }

		public Node2 (T initialValue)
		{
			_value = initialValue;
		}
	}
}
