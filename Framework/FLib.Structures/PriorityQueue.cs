using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace FlintLib.Structures
{
	public class PriorityQueue<T> : ICollection, IEnumerable<T>, IEnumerable, IReadOnlyCollection<T> where T : IPrioritizable
	{
		public int Count => _items.Count;

		public object SyncRoot => null;

		public bool IsSynchronized => false;

		public void CopyTo(Array array, int index)
		{
			throw new NotImplementedException();
		}

		public IEnumerator GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			throw new NotImplementedException();
		}

		private readonly List<T> _items = new List<T>();

		public PriorityQueue() : this(null) { }

		public PriorityQueue(IEnumerable<T> items)
		{
			items?.ToList().ForEach(item => Enqueue(item));
		}

		public void Enqueue(T item)
		{
			if (item != null && !_items.Contains(item))
			{
				_items.Add(item);
				var childIndex = (_items.Count - 1);
				while (childIndex > 0)
				{
					var parentIndex = ((childIndex - 1) / 2);
					if (_items[childIndex].Priority >= _items[parentIndex].Priority) { break; }
					var temp = _items[childIndex]; _items[childIndex] = _items[parentIndex]; _items[parentIndex] = temp;
					childIndex = parentIndex;
				}
			}
		}

		public T Dequeue()
		{
			var lastIndex = (_items.Count - 1);
			var frontItem = _items[0];
			_items[0] = _items[lastIndex];
			_items.RemoveAt(lastIndex);

			--lastIndex;
			var parentIndex = 0;

			while(true)
			{
				var leftChildIndex = (parentIndex * 2 + 1);
				if (leftChildIndex > lastIndex) { break; }
				var rightChildIndex = (leftChildIndex + 1);

				if (rightChildIndex <= lastIndex
					&& _items[rightChildIndex].Priority < _items[leftChildIndex].Priority)
				{
					leftChildIndex = rightChildIndex;
				}

				if (_items[parentIndex].Priority <= _items[leftChildIndex].Priority) { break; }

				var temp = _items[parentIndex]; _items[parentIndex] = _items[leftChildIndex]; _items[leftChildIndex] = temp;
				parentIndex = leftChildIndex;
			}

			return frontItem;
		}

		public T Peek() =>_items.Count > 0 ? _items[0] : default(T);

		public void Clear() => _items.Clear();

		public bool Contains(T item) => _items.Contains(item);
	}
}
