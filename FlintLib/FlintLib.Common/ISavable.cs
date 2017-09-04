using System;

namespace FlintLib.Common
{
	/// <summary>
	/// 
	/// </summary>
	public interface ISavable
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
