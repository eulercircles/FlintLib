using System;
using System.ComponentModel;

namespace FlintLib.MVVM
{
	public interface IBindable<T> : INotifyPropertyChanged
	{
		T Value { get; set; }
	}
}
