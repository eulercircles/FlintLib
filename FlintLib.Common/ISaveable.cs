using System;

namespace FlintLib.Common
{
	/// <summary>
	/// 
	/// </summary>
	public interface ISaveable
	{
		/// <summary>
		/// 
		/// </summary>
		IReadOnlyObservable<bool> IsDirty { get; }

		/// <summary>
		/// 
		/// </summary>
		void Save();
	}
}
