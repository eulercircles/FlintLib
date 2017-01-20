using System;

namespace FlintLib.MVVM
{
	/// <summary>
	/// An interface that represents a value that is observable but not intended for data binding.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IObservable<T>
	{
		/// <summary>
		/// 
		/// </summary>
		event EventHandler ValueChanged;

		/// <summary>
		/// 
		/// </summary>
		T Value { get; set; }
	}
}
