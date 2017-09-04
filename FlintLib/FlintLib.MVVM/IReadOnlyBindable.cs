using System.ComponentModel;

namespace FlintLib.MVVM
{
	public interface IReadOnlyBindable<T> : INotifyPropertyChanged
	{
		T Value { get; }

		/// <summary>
		/// Will alert any bound objects that they should reassess the value, even though the value has not changed.
		/// </summary>
		void Bump();
	}
}
