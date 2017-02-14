using System;

namespace FlintLib.Core.Structures
{
	public class OctNode : SPTreeNode
	{
		public OctNode() { }

		public OctNode(byte maxLevels) : base(maxLevels)
		{
			Children = new OctNode[8];
		}

		public override void Split()
		{
			Split<OctNode>();
		}
	}
}
