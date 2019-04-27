#region Using Statements
using System;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public abstract class ViewModel_Base : IDisposable
	{
		public ViewModel_Base()
		{
			ConstructBindables();
		}

		protected abstract void ConstructBindables();

		public virtual void Initialize() { }

		public virtual void UnInitialize() { }

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
