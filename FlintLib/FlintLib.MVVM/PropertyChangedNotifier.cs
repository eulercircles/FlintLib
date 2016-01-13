#region Using Statements
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public abstract class PropertyChangedNotifier : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void _triggerPropertyChangedEvent([CallerMemberName]string propertyName = null)
		{
			if (this.PropertyChanged != null) { this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
		}
	}
}
