using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.MVVM;

namespace FlintLib.MVVM.UnitTests
{
	[TestClass]
	public class Bindables_Test
	{
		[TestMethod]
		public void TestBindablesFactory()
		{
			var bindable1 = BindablesFactory.Create<string>();
			var bindable2 = BindablesFactory.Create("Bindable2");
			var bindable3 = BindablesFactory.Create<int>();
			var bindable4 = BindablesFactory.Create(45);
			var bindable5 = BindablesFactory.Create<bool>();
			var bindable6 = BindablesFactory.Create(true);

			Assert.IsNotNull(bindable1);
			Assert.IsInstanceOfType(bindable1, typeof(IBindable<string>));
			Assert.IsTrue(bindable1.Value == default(string));

			Assert.IsNotNull(bindable2);
			Assert.IsInstanceOfType(bindable2, typeof(IBindable<string>));
			Assert.IsTrue(bindable2.Value == "Bindable2");

			Assert.IsNotNull(bindable3);
			Assert.IsInstanceOfType(bindable3, typeof(IBindable<int>));
			Assert.IsTrue(bindable3.Value == default(int));

			Assert.IsNotNull(bindable4);
			Assert.IsInstanceOfType(bindable4, typeof(IBindable<int>));
			Assert.IsTrue(bindable4.Value == 45);

			Assert.IsNotNull(bindable5);
			Assert.IsInstanceOfType(bindable5, typeof(IBindable<bool>));
			Assert.IsTrue(bindable5.Value == default(bool));

			Assert.IsNotNull(bindable6);
			Assert.IsInstanceOfType(bindable6, typeof(IBindable<bool>));
			Assert.IsTrue(bindable6.Value == true);
		}
	}
}
