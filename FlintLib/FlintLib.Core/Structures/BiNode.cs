using System;

namespace FlintLib.Core.Structures
{
	public class BiNode : SPTreeNode
	{
		/// <summary>
		/// Default constructor is used internally. To create a new binary tree root node, use the
		/// BiNode(byte maxLevels) constructor.
		/// </summary>
		public BiNode()
		{
			this.Children = new BiNode[2];
		}

		public BiNode(byte maxLevels) : base(maxLevels)
		{
			this.Children = new BiNode[2];
		}

		public override void Split()
		{
			this.Split<BiNode>();
		}

		//private const byte maxLevels = 8;

		//private BiNode[] _children;

		//public int Level { get; private set; }

		//public BiNode()
		//{
		//	_children = new BiNode[2];
		//}

		//public virtual void Split()
		//{
		//	if (Level == maxLevels) { return; }

		//	var nextLevel = Level + 1;
		//	for (int i = 0; i < _children.Length; i++)
		//	{
		//		_children[i] = new BiNode() { Level = nextLevel };
		//	}
		//}

		//public virtual void Clear()
		//{
		//	for (int i = 0; i < _children.Length; i++)
		//	{
		//		if (_children[i] != null)
		//		{
		//			_children[i].Clear();
		//			_children[i] = null;
		//		}
		//	}
		//}
	}
}
