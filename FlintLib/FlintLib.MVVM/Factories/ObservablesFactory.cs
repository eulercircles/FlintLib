using System;

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	public static class ObservableFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static IObservable<T> Create<T>() { return new Observable<T>(); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="initialValue"></param>
		/// <returns></returns>
		public static IObservable<T> Create<T>(T initialValue) { return new Observable<T>(initialValue); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="observable"></param>
		/// <returns></returns>
		public static IReadOnlyObservable<T> CreateReadOnly<T>(IObservable<T> observable) { return new ReadOnlyObservable<T>(observable); }
	}
}
