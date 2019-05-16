using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FLib.Common.Tests
{
	[TestClass]
	public class Observable_Tester
	{
		[TestMethod]
		public void TestObservable()
		{
			var observable = new Observable<string>("INITIAL");
			var newValue = "BINGO";

		var valueChangeTriggered = false;
			observable.ValueChanged.Subscribe((s, a) => {
				Assert.IsInstanceOfType(s, typeof(Observable<string>));
				Assert.IsTrue(observable.Value == newValue);
				valueChangeTriggered = true;
			});
			
			observable.Value = newValue;

			Assert.IsTrue(valueChangeTriggered);
		}
	}
}
