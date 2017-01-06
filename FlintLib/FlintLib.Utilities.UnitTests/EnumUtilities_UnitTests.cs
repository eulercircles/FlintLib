using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlintLib.Utilities.UnitTests
{
	[TestClass]
	public class EnumUtilities_UnitTests
	{
		private enum TestValues
		{
			[System.ComponentModel.Description("The First Value")]
			Value1,
			Value2,
			[System.ComponentModel.Description("This is the third and final value.")]
			Value3
		}

		[TestMethod]
		public void TestGetEnumDescriptionsWithKnownGoods()
		{
			var descriptions = Utilities.EnumUtilities.GetEnumDescriptions<TestValues>();

			foreach (var item in descriptions)
			{
				switch (item.Value)
				{
					case TestValues.Value1:
						Assert.IsTrue(item.Key == "The First Value");
						break;
					case TestValues.Value2:
						Assert.IsTrue(item.Key == "Value2");
						break;
					case TestValues.Value3:
						Assert.IsTrue(item.Key == "This is the third and final value.");
						break;
					default:
						throw new Exception($"Unhandled: {item.Value}");
				}
			}
		}
	}
}
