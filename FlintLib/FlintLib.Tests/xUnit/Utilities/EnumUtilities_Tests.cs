using System;

using Xunit;

using FlintLib.Utilities;

namespace FlintLib.Tests.xUnit.Utilities
{
	public class EnumUtilities_Tests
	{
		private enum TestValues
		{
			[System.ComponentModel.Description("The First Value")]
			Value1,
			Value2,
			[System.ComponentModel.Description("This is the third and final value.")]
			Value3
		}

		[Fact]
		public void TestGetEnumDescriptionsWithKnownGoods()
		{
			var descriptions = EnumUtilities.GetEnumDescriptions<TestValues>();

			foreach (var item in descriptions)
			{
				switch (item.Value)
				{
					case TestValues.Value1:
						Assert.True(item.Key == "The First Value");
						break;
					case TestValues.Value2:
						Assert.True(item.Key == "Value2");
						break;
					case TestValues.Value3:
						Assert.True(item.Key == "This is the third and final value.");
						break;
					default:
						throw new Exception($"Unhandled: {item.Value}");
				}
			}
		}
	}
}
