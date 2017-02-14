using System;

namespace FlintLib.Core.Structures
{
	/// <summary>
	/// Base abstract class for nodes of a space partitioning tree, such as a quad- or octree.
	/// </summary>
	public abstract class SPTreeNode
	{
		protected readonly byte _maxLevels;

		public int Level { get; set; }

		public SPTreeNode[] Children { get; protected set; }

		public SPTreeNode() { }

		public SPTreeNode(byte maxLevels)
		{
			_maxLevels = maxLevels;
		}

		public abstract void Split();

		protected void Split<T>() where T : SPTreeNode, new()
		{
			if (Level == _maxLevels) { return; }

			if (Children != null)
			{
				var nextLevel = Level + 1;
				for (int i = 0; i < Children.Length; i++)
				{
					Children[i] = new T() { Level = nextLevel };
				}
			}
		}

		public void Clear()
		{
			if (Children != null)
			{
				for (int i = 0; i < Children.Length; i++)
				{
					if (Children[i] != null)
					{
						Children[i].Clear();
						Children[i] = null;
					}
				}
			}
		}
	}
}
