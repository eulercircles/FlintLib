using System;
using System.IO.Abstractions;

namespace FLib.Data.FileSystem
{
	internal class FileDataContext : IDataContext
	{
		private readonly IFileSystem _fileSystem;
		private readonly string _filePath;

		internal FileDataContext(IFileSystem fileSystem, string filePath)
		{
			_fileSystem = fileSystem;
			_filePath = filePath;
		}

		public bool IsLoaded => throw new NotImplementedException();

		public void Load()
		{
			throw new NotImplementedException();
		}

		public void Save()
		{
			throw new NotImplementedException();
		}
	}
}
