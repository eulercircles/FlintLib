using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLibXamarin.Common;

namespace FLibXamarin.Tests
{
	[TestClass]
	public class Observable_Tester
	{
		[TestMethod]
		public void TestObservable()
		{
			var observable = new Observable<string>("OBSERVABLE");

			observable.ValueChanged += (s, a) => {
				Assert.IsTrue(observable.Value == "CHANGED");
			};

			observable.Value = "CHANGED";
		}
	}
}
