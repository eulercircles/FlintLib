#region Using Statements
using System;
using System.ComponentModel;

using static FlintLib.MVVM.EventUtilities;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	internal abstract class PropertyChangedNotifier : INotifyPropertyChanged
	{
		private readonly PropertyChangedEventHandler _propertyChanged;
		public event PropertyChangedEventHandler PropertyChanged
		{
			add { Subscribe(_propertyChanged, value); }
			remove { Unsubscribe(_propertyChanged, value); }
		}

		protected void TriggerPropertyChangedEvent(string propertyName = null)
		{
			_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
