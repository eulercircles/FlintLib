using System;

namespace FlintLib.MVVM
{
	public static class BindablesFactory
	{
		public static IBindable<T> Create<T>() { return new Bindable<T>(); }
		public static IBindable<T> Create<T>(T initialValue) { return new Bindable<T>(initialValue); }
	}
}
