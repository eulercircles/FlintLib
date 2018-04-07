using System;

namespace FlintLib.Common
{
	public static class ObservablesFactory
	{
		public static IObservable<T> Create<T>()
		{ return new Observable<T>(); }

		public static IObservable<T> Create<T>(T initialValue)
		{ return new Observable<T>(initialValue); }

		public static IReadOnlyObservable<T> Create<T>(IObservable<T> observable)
		{ return new ReadOnlyObservable<T>(observable); }
	}
}
