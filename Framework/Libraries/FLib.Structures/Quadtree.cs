using System;
using System.Collections;
using System.Collections.Generic;

namespace FLib.Structures
{
	public class Quadtree : IBounded2D, ITree<IBounded2D>
	{
		private const byte _childCount = 4;

		private readonly IList<IBounded2D> _objects;

		private readonly Quadtree _parent;
		private readonly Quadtree[] _children;

		private readonly ushort _maxItems;
		private readonly ushort _level;

		#region IBounded2D Implementation
		public float XMin { get; private set; }

		public float YMin { get; private set; }

		public float XMax { get; private set; }

		public float YMax { get; private set; }
		#endregion IBounded2D Implementation

		public Quadtree(Quadtree parent, ushort maxItems, ushort level = 0)
		{
			_objects = new List<IBounded2D>();
			_parent = parent;
			_children = new Quadtree[_childCount];
			_level = level;
		}

		private void Split() { throw new NotImplementedException(); }

		private void Join() { }

		#region IList Implementation
		public IBounded2D this[int index] { get { return _objects[index]; } set { _objects[index] = value; } }
		public int Count => _objects.Count;
		public bool IsReadOnly => _objects.IsReadOnly;

		public void Add(IBounded2D item)
		{
			_objects.Add(item);
			if (_objects.Count > _maxItems) { Split(); }
		}

		public void Clear() => _objects.Clear();
		public bool Contains(IBounded2D item) => _objects.Contains(item);
		public void CopyTo(IBounded2D[] array, int arrayIndex) => _objects.CopyTo(array, arrayIndex);
		public IEnumerator<IBounded2D> GetEnumerator() => _objects.GetEnumerator();
		public int IndexOf(IBounded2D item) => _objects.IndexOf(item);
		public void Insert(int index, IBounded2D item) => _objects.Insert(index, item);
		public bool Remove(IBounded2D item) => _objects.Remove(item);
		public void RemoveAt(int index) => _objects.RemoveAt(index);
		IEnumerator IEnumerable.GetEnumerator() => _objects.GetEnumerator();
		#endregion IList Implementation
	}
}
