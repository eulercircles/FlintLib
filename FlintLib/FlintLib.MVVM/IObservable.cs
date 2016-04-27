using System;

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
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
