using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Common;

namespace FlintLib.Tests.Common
{
	[TestClass]
	public class Observable_Tester
	{
		private FlintLib.Common.IObservable<string> _observable;
		private string _changeString = "BINGO";

		[TestMethod]
		public void TestObservable()
		{
			_observable = ObservablesFactory.Create("INITIAL");
			_observable.ValueChanged += Observable_ValueChanged;

			_observable.Value = _changeString;
		}

		private void Observable_ValueChanged(object sender, EventArgs e)
		{
			Assert.IsInstanceOfType(sender, typeof(FlintLib.Common.IObservable<string>));
			Assert.IsTrue(_observable.Value == _changeString);
		}
	}
}
