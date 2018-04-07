using System;
using System.Collections.Generic;

using FlintLib.MVVM.Internals;

namespace FlintLib.MVVM
{
	public static class BindablesFactory
	{
		public static IBindable<T> Create<T>()
		{ return new Bindable<T>(); }

		public static IBindable<T> Create<T>(T initialValue)
		{ return new Bindable<T>(initialValue); }

		public static IBindable<T> Create<T>(Common.IObservable<T> observable)
		{
			return new TwoWayBindable<T>(observable);
		}

		public static IReadOnlyBindable<T> Create<T>(IBindable<T> bindable)
		{ return new ReadOnlyBindable<T>(bindable); }

		public static IBindableSelectionList<T> Create<T>(Dictionary<string, T> listItems)
		{ return new BindableSelectionList<T>(listItems); }
	}
}
