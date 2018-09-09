#region Using Statements
using System;
using System.Linq;
using System.Diagnostics;
using System.ComponentModel;

#endregion // Using Statements

namespace FlintLib.MVVM
{
	public abstract class ViewModel_Base : INotifyPropertyChanged, IDisposable
	{
		#region Dependency Properties

		#endregion Dependency Properties

		public ViewModel_Base() { }

		protected abstract void ConstructBindables();

		public virtual void Initialize() { }

		public virtual void UnInitialize() { }

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

		protected void _triggerPropertyChangedEvent(string propertyName)
		{
			Debug.Assert(!string.IsNullOrWhiteSpace(propertyName));

			if (!string.IsNullOrWhiteSpace(propertyName))
			{
				_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
			}
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
					UnInitialize();
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

		/// <summary>
		/// 
		/// </summary>
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
