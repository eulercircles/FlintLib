using System;

namespace FlintLib.Core.Structures
{
	public class QuadNode : SPTreeNode
	{
		public QuadNode()
		{
			Children = new QuadNode[4];
		}

		public QuadNode(byte maxLevels) : base(maxLevels)
		{
			Children = new QuadNode[4];
		}

		public override void Split()
		{
			Split<QuadNode>();
		}
	}
}
