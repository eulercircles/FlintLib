#region Using Statements
using System;
using System.Linq;
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
			= DependencyProperty.Register(nameof(Adjutant),
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
			_initializeBindingProperties();
			_initializeBindingCommands();
		}
		
		~ViewModel_Base()
		{
			_unregisterEventHandlers();
		}

		protected virtual void _initializeBindingProperties() { }
		protected virtual void _initializeBindingCommands() { }
		protected virtual void _unregisterEventHandlers() { }

		protected void _issueCommandViaAdjutant<T>(T commandObject) where T : Command
		{
			if (Adjutant != null) { Adjutant.IssueCommand<T>(this, commandObject); }
		}

		#region INotifyPropertyChanged Implementation
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

		protected void _triggerPropertyChangedEvent([CallerMemberName]string propertyName = null)
		{
			if (_propertyChanged != null) { _propertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
		}
		#endregion // INotifyPropertyChanged Implementation
	}
}
