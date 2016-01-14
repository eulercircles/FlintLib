#region Using Statements
using System;
using System.Linq;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public abstract class ViewModel_Base : DependencyObject, INotifyPropertyChanged, IDisposable
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
			protected get { return (IAdjutant)GetValue(AdjutantProperty); }
			set
			{
				SetValue(AdjutantProperty, value);
				_onSetAdjutant();
			}
		}

		protected virtual void _onSetAdjutant() { }
		#endregion // Adjutant

		#endregion // Dependency Properties

		public ViewModel_Base()
		{
			InitializeBindingProperties();
			InitializeBindingCommands();
		}

		protected virtual void InitializeBindingProperties() { }
		protected virtual void InitializeBindingCommands() { }
		protected virtual void UnregisterEventHandlers() { }

		protected abstract void UnregisterExecutors();

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

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					UnregisterExecutors();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~ViewModel_Base() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public virtual void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion
	}
}
