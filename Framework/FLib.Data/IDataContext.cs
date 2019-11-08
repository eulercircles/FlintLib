using System;

namespace FLib.Data
{
	public interface IDataContext
	{
		bool IsLoaded { get; }

		void Save();

		void Load();
	}
}
