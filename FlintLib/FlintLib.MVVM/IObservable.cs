using System;

namespace FlintLib.MVVM
{
	public interface IObservable<T>
	{
		event EventHandler ValueChanged;
		T Value { get; set; }
	}
}
