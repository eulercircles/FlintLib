using System;

namespace FlintLib.MVVM
{
	public static class ObservableFactory
	{
		public static IObservable<T> Create<T>() { return new Observable<T>(); }
		public static IObservable<T> Create<T>(T initialValue) { return new Observable<T>(initialValue); }

		public static IReadOnlyObservable<T> CreateReadOnly<T>(IObservable<T> observable) { return new ReadOnlyObservable<T>(observable); }
	}
}
