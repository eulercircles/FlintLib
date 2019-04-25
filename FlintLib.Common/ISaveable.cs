using System;

namespace FLib.Common
{
	public interface ISaveable
	{
		ReadOnlyObservable<bool> IsDirty { get; }

		void Save();
	}
}
