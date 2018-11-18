using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using static FlintLib.Common.StringUtilities;

namespace FlintLib.Common.Tests
{
	[TestClass]
	public class StringUtilities_Tester
	{
		[TestMethod]
		public void TestGenerateID()
		{
			var ids = new List<string>();
			for (int length = 1; length <= 32; length++)
			{
				var id = GenerateUniqueID(length);
				ids.Add(id);
			}
			var count = ids.Count;
		}
	}
}
