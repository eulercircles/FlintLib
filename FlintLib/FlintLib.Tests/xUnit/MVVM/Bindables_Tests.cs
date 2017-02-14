using System;

using Xunit;

using FlintLib.MVVM;

namespace FlintLib.Tests.xUnit.MVVM
{
	public class Bindables_Test
	{
		[Fact]
		public void TestBindablesFactory()
		{
			var bindable1 = BindablesFactory.Create<string>();
			var bindable2 = BindablesFactory.Create("Bindable2");
			var bindable3 = BindablesFactory.Create<int>();
			var bindable4 = BindablesFactory.Create(45);
			var bindable5 = BindablesFactory.Create<bool>();
			var bindable6 = BindablesFactory.Create(true);

			Assert.NotNull(bindable1);
			Assert.True(bindable1 is IBindable<string>);
			Assert.True(bindable1.Value == default(string));

			Assert.NotNull(bindable2);
			Assert.True(bindable2 is IBindable<string>);
			Assert.True(bindable2.Value == "Bindable2");

			Assert.NotNull(bindable3);
			Assert.True(bindable3 is IBindable<int>);
			Assert.True(bindable3.Value == default(int));

			Assert.NotNull(bindable4);
			Assert.True(bindable4 is IBindable<int>);
			Assert.True(bindable4.Value == 45);

			Assert.NotNull(bindable5);
			Assert.True(bindable5 is IBindable<bool>);
			Assert.True(bindable5.Value == default(bool));

			Assert.NotNull(bindable6);
			Assert.True(bindable6 is IBindable<bool>);
			Assert.True(bindable6.Value == true);
		}
	}
}
