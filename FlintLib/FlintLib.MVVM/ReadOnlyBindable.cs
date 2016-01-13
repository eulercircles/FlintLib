#region Using Statements
using System.ComponentModel;

using FlintLib.Utilities;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public class ReadOnlyBindable<T> : PropertyChangedNotifier
	{
		private readonly Bindable<T> _bindable;
		public T Value { get { return _bindable.Value; } }

		public ReadOnlyBindable(Bindable<T> property)
		{
			_bindable = property;
			if (_bindable != null)
			{
				_bindable.PropertyChanged += this._bindable_PropertyChanged;
			}
		}

		private void _bindable_PropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			_triggerPropertyChangedEvent(ReflectionUtilities.GetVariableName(() => this.Value));
		}
	}
}
