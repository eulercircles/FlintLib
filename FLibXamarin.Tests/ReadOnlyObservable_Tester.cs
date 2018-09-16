using System;
using FLibXamarin.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FLibXamarin.Tests
{
	[TestClass]
	public class ReadOnlyObservable_Tester
	{
		[TestMethod]
		public void TestReadOnlyObservable()
		{
			var observable = new Observable<string>("OBSERVABLE");
			var readOnlyObservable = new ReadOnlyObservable<string>(observable);

			readOnlyObservable.ValueChanged += (s, a) => {
				Assert.IsTrue(readOnlyObservable.Value == "CHANGED");
			};

			observable.Value = "CHANGED";
		}
	}
}
