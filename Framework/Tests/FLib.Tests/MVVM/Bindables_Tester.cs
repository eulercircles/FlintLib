using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLib.Common;
using FLib.MVVM;

namespace FLib.Tests.MVVM
{
	[TestClass]
	public class Bindables_Tester
	{
		[TestMethod]
		public void TestCreateTwoWayBindable()
		{
			var observable = ObservablesFactory.Create("Initial Value");

			var twoWayBindable = BindablesFactory.Create(observable);

			twoWayBindable.PropertyChanged += (s, e) =>
			{
				string value = twoWayBindable.Value;
			};

			observable.ValueChanged += (s, e) =>
			{
				string value = observable.Value;
			};

			observable.Value = "Changed";
		}
	}
}
