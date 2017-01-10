#region Using Statements
using System;
using System.Linq;
using System.Windows;
using System.Diagnostics;
using System.ComponentModel;

using FlintLib.Utilities;
using FlintLib.MVVM.Mediator;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	public abstract class ViewModel_Base : DependencyObject, INotifyPropertyChanged, IDisposable
	{
		#region Dependency Properties
		#region IMediator
		/// <summary>
		/// 
		/// </summary>
		public static readonly DependencyProperty MediatorProperty
			= DependencyProperty.RegisterAttached("Mediator",
			typeof(IMediator),
			typeof(ViewModel_Base),
			new PropertyMetadata(null));

		/// <summary>
		/// 
		/// </summary>
		/// <param name="viewModel"></param>
		/// <returns></returns>
		public static IMediator GetMediator(DependencyObject viewModel)
		{
			return (IMediator)viewModel.GetValue(MediatorProperty);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="viewModel"></param>
		/// <param name="value"></param>
		public static void SetMediator(DependencyObject viewModel, IMediator value)
		{
			viewModel.SetValue(MediatorProperty, value);
		}
		#endregion // IMediator
		#endregion // Dependency Properties

		/// <summary>
		/// 
		/// </summary>
		public ViewModel_Base()
		{
			InitializeBindables();
		}

		/// <summary>
		/// 
		/// </summary>
		protected virtual void InitializeBindables() { }

		/// <summary>
		/// 
		/// </summary>
		public virtual void Initialize() { }

		/// <summary>
		/// 
		/// </summary>
		public virtual void UnInitialize() { }

		#region INotifyPropertyChanged Implementation
		private PropertyChangedEventHandler _propertyChanged;

		/// <summary>
		/// 
		/// </summary>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="propertyName"></param>
		protected void _triggerPropertyChangedEvent(string propertyName)
		{
			Debug.Assert(propertyName != null);
			_propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName.Validate()));
		}
		#endregion // INotifyPropertyChanged Implementation

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		/// <summary>
		/// 
		/// </summary>
		/// <param name="disposing"></param>
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
