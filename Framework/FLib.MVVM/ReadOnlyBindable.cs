using System;
using System.Linq;
using System.ComponentModel;

namespace FLib.MVVM
{
	internal class ReadOnlyBindable<T> : PropertyChangedNotifier
	{
		private readonly Bindable<T> _bindable;

		public T Value => _bindable.Value;

		internal ReadOnlyBindable(Bindable<T> bindable)
		{
			_bindable = bindable ?? throw new ArgumentNullException(nameof(bindable));

			_bindable.PropertyChanged += Bindable_PropertyChanged;
		}

		private void Bindable_PropertyChanged(object sender, PropertyChangedEventArgs e) => TriggerPropertyChangedEvent(nameof(Value));
	}
}
