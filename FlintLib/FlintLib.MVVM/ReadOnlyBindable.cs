#region Using Statements
using System;
using System.ComponentModel;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public class ReadOnlyBindable<T> : PropertyChangedNotifier, IDisposable
	{
		private readonly Bindable<T> _bindable;
		public T Value => _bindable.Value;

		public ReadOnlyBindable(Bindable<T> bindable)
		{
			if (bindable != null)
			{
				_bindable = bindable;
				_bindable.PropertyChanged += _bindable_PropertyChanged;
			}
			else { throw new ArgumentNullException(nameof(bindable)); }
		}

		private void _bindable_PropertyChanged(object sender, PropertyChangedEventArgs args)
		{
			_triggerPropertyChangedEvent(nameof(Value));
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (_bindable != null)
					{
						_bindable.PropertyChanged -= _bindable_PropertyChanged;
					}
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~ReadOnlyBindable() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion // IDisposable Support
	}
}
