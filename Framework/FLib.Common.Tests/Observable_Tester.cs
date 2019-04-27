using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlintLib.Common.Tests
{
	[TestClass]
	public class Observable_Tester
	{
		private IObservable<string> _observable;
		private readonly string _changeString = "BINGO";

		[TestMethod]
		public void TestObservable()
		{
			_observable = ObservablesFactory.Create("INITIAL");
			_observable.ValueChanged += Observable_ValueChanged;

			_observable.Value = _changeString;
		}

		private void Observable_ValueChanged(object sender, EventArgs e)
		{
			Assert.IsInstanceOfType(sender, typeof(IObservable<string>));
			Assert.IsTrue(_observable.Value == _changeString);
		}
	}
}
