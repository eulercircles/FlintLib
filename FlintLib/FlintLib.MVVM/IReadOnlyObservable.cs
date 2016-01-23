using System;

namespace FlintLib.MVVM
{
	public interface IReadOnlyObservable<T> : IDisposable
	{
		event EventHandler ValueChanged;
		T Value { get; }
	}
}
