using System;

using FlintLib.Structures;

namespace FlintLib.Tests.Structures
{
	internal class PQItem : IPrioritizable
	{
		public string Name { get; private set; }
		public ushort Priority { get; private set; }

		internal PQItem(string name, ushort priority)
		{
			Name = name;
			Priority = priority;
		}
	}
}
