#region Using Statements
using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	internal abstract class PropertyChangedNotifier : INotifyPropertyChanged
	{
		private PropertyChangedEventHandler _propertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				if (_propertyChanged == null || !_propertyChanged.GetInvocationList().Contains(value))
				{
					_propertyChanged += value;
				}
			}
			remove { _propertyChanged -= value; }
		}

		protected void _triggerPropertyChangedEvent(string propertyName = null)
		{
			if (_propertyChanged != null) { _propertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
		}
	}
}
