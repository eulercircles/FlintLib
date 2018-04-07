using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Common;
using FlintLib.MVVM;

namespace FlintLib.Tests.MVVM
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
