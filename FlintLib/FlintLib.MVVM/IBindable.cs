using System.ComponentModel;

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IBindable<T> : INotifyPropertyChanged
	{
		/// <summary>
		/// 
		/// </summary>
		T Value { get; set; }
	}
}
