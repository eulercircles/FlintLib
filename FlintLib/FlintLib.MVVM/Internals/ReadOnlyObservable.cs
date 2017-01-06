#region Using Statements
using System;
using System.Linq;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	internal class ReadOnlyObservable<T> : IReadOnlyObservable<T>
	{
		private readonly IObservable<T> _observable;
		public T Value => _observable.Value;

		// ReadOnlyObservable<T> implements its own ValueChanged event rather than implementing INotifyPropertyChanged
		// or inheriting from PropertyChangedNotifier so that instances of this type cannot be bound to using Data Binding.
		// It's provided so that property values can be observed in a different way, by objects that do not necessarily 
		// support data binding from XAML.
		private EventHandler _valueChanged;
		public event EventHandler ValueChanged
		{
			add
			{
				if (_valueChanged == null || !_valueChanged.GetInvocationList().Contains(value))
				{
					_valueChanged += value;
				}
			}
			remove { _valueChanged -= value; }
		}
		
		internal ReadOnlyObservable(IObservable<T> observable)
		{
			if (observable != null)
			{
				_observable = observable;
				_observable.ValueChanged += _observable_ValueChanged;
			}
			else { throw new ArgumentNullException(nameof(observable)); }
		}

		private void _observable_ValueChanged(object sender, EventArgs args)
		{
			_valueChanged?.Invoke(this, null);
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					if (_observable != null)
					{
						_observable.ValueChanged -= _observable_ValueChanged;
					}
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~ReadOnlyObservable() {
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
