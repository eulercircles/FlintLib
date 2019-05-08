using System;
using System.Linq;
using System.ComponentModel;
using System.Diagnostics;

namespace FLib.MVVM
{
	internal abstract class PropertyChangedNotifier : INotifyPropertyChanged
	{
		private PropertyChangedEventHandler _propertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { if (_propertyChanged == null || !_propertyChanged.GetInvocationList().Contains(value)) { _propertyChanged += value; } }
			remove { if (_propertyChanged != null && _propertyChanged.GetInvocationList().Contains(value)) { _propertyChanged -= value; } }
		}

		protected void TriggerPropertyChangedEvent(string propertyName)
		{
			Debug.Assert(!string.IsNullOrWhiteSpace(propertyName));
			_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
