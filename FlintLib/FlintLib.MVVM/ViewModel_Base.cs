#region Using Statements
using System;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public abstract class ViewModel_Base : DependencyObject, INotifyPropertyChanged
	{
		#region Dependency Properties

		#region Adjutant
		public static readonly DependencyProperty AdjutantProperty
			= DependencyProperty.Register("Adjutant",
			typeof(IAdjutant),
			typeof(ViewModel_Base),
			new PropertyMetadata(null));

		public IAdjutant Adjutant
		{
			protected get { return (IAdjutant)this.GetValue(AdjutantProperty); }
			set
			{
				this.SetValue(AdjutantProperty, value);
				this._onSetAdjutant();
			}
		}

		protected virtual void _onSetAdjutant() { }
		#endregion // Adjutant

		#endregion // Dependency Properties

		public ViewModel_Base()
		{
			this._initializeBindingProperties();
			this._initializeBindingCommands();
		}
		
		~ViewModel_Base()
		{
			this._unregisterEventHandlers();
		}

		protected virtual void _initializeBindingProperties() { }
		protected virtual void _initializeBindingCommands() { }
		protected virtual void _unregisterEventHandlers() { }

		protected void _issueCommandViaAdjutant<T>(T commandObject) where T : Command
		{
			if (this.Adjutant != null) { this.Adjutant.IssueCommand<T>(this, commandObject); }
		}

		#region INotifyPropertyChanged Implementation
		public event PropertyChangedEventHandler PropertyChanged;

		protected void _triggerPropertyChangedEvent([CallerMemberName]string propertyName = null)
		{
			if (this.PropertyChanged != null) { this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
		}
		#endregion // INotifyPropertyChanged Implementation
	}
}
