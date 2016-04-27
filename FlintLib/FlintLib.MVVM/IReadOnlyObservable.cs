using System;

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IReadOnlyObservable<T> : IDisposable
	{
		/// <summary>
		/// 
		/// </summary>
		event EventHandler ValueChanged;

		/// <summary>
		/// 
		/// </summary>
		T Value { get; }
	}
}
