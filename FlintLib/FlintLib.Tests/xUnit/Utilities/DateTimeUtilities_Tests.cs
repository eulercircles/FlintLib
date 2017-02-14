using System;

using Xunit;

using FlintLib.Utilities;

namespace FlintLib.Tests.xUnit.Utilities
{
	public class DateTimeUtilities_Tests
	{
		// Manually define the 7 consecutive days of the same week (any week).
		private readonly DateTime _refSunday = new DateTime(2017, 2, 12);
		private readonly DateTime _refMonday = new DateTime(2017, 2, 13);
		private readonly DateTime _refTuesday = new DateTime(2017, 2, 14);
		private readonly DateTime _refWednesday = new DateTime(2017, 2, 15);
		private readonly DateTime _refThursday = new DateTime(2017, 2, 16);
		private readonly DateTime _refFriday = new DateTime(2017, 2, 17);
		private readonly DateTime _refSaturday = new DateTime(2017, 2, 18);

		// Boundary Conditions
		private readonly DateTime _saturdayBefore = new DateTime(2017, 2, 11);
		private readonly DateTime _sundayAfter = new DateTime(2017, 2, 19);
		private readonly DateTime _mondayAfter = new DateTime(2017, 2, 20);

		[Fact]
		public void TestGetSundayOfWeek()
		{
			Assert.True(_refSunday.GetSundayOfWeek() == _refSunday);
			Assert.True(_refMonday.GetSundayOfWeek() == _refSunday);
			Assert.True(_refTuesday.GetSundayOfWeek() == _refSunday);
			Assert.True(_refWednesday.GetSundayOfWeek() == _refSunday);
			Assert.True(_refThursday.GetSundayOfWeek() == _refSunday);
			Assert.True(_refFriday.GetSundayOfWeek() == _refSunday);
			Assert.True(_refSaturday.GetSundayOfWeek() == _refSunday);

			Assert.False(_saturdayBefore.GetSundayOfWeek() == _refSunday);
			Assert.False(_sundayAfter.GetSundayOfWeek() == _refSunday);
			Assert.False(_mondayAfter.GetSundayOfWeek() == _refSunday);
		}

		[Fact]
		public void TestGetMondayOfWeek()
		{
			Assert.True(_refSunday.GetMondayOfWeek() == _refMonday);
			Assert.True(_refMonday.GetMondayOfWeek() == _refMonday);
			Assert.True(_refTuesday.GetMondayOfWeek() == _refMonday);
			Assert.True(_refWednesday.GetMondayOfWeek() == _refMonday);
			Assert.True(_refThursday.GetMondayOfWeek() == _refMonday);
			Assert.True(_refFriday.GetMondayOfWeek() == _refMonday);
			Assert.True(_refSaturday.GetMondayOfWeek() == _refMonday);

			Assert.False(_saturdayBefore.GetMondayOfWeek() == _refMonday);
			Assert.False(_sundayAfter.GetMondayOfWeek() == _refMonday);
		}
	}
}
