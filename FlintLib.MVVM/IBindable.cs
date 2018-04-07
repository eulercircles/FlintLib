using System.ComponentModel;

namespace FlintLib.MVVM
{
	public interface IBindable<T> : INotifyPropertyChanged
	{
		T Value { get; set; }

		/// <summary>
		/// Will alert any bound objects that they should reassess the value, even though the value has not changed.
		/// </summary>
		void Bump();
	}
}
