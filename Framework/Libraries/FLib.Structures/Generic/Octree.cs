using System;
using System.Collections;
using System.Collections.Generic;

namespace FLib.Structures.Generic
{
	public class Octree : IBounded3D, ITree<IBounded3D>
	{
		private const byte _childCount = 8;

		private readonly IList<IBounded3D> _objects;

		private readonly Octree _parent;
		private readonly Octree[] _children;
		private readonly int _level;

		public IBounded3D this[int index] { get { return _objects[index]; } set { _objects[index] = value; } }

		#region IBounded3D Implementation
		public float XMin { get { throw new NotImplementedException(); } }

		public float XMax { get { throw new NotImplementedException(); } }

		public float YMin { get { throw new NotImplementedException(); } }

		public float YMax { get { throw new NotImplementedException(); } }

		public float ZMin { get { throw new NotImplementedException(); } }

		public float ZMax { get { throw new NotImplementedException(); } }
		#endregion IBounded3D Implementation

		#region IList Implementation
		public int Count { get { throw new NotImplementedException(); } }

		public bool IsReadOnly { get { throw new NotImplementedException(); } }

		public void Add(IBounded3D item)
		{
			throw new NotImplementedException();
		}

		public void Clear()
		{
			throw new NotImplementedException();
		}

		public bool Contains(IBounded3D item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(IBounded3D[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public IEnumerator<IBounded3D> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		public int IndexOf(IBounded3D item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, IBounded3D item)
		{
			throw new NotImplementedException();
		}

		public bool Remove(IBounded3D item)
		{
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		#endregion IList Implementation
	}
}
