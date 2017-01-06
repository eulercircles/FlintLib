using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FlintLib.Diagnostics.UnitTests
{
	[TestClass]
	public class LoggerFactory_UnitTests
	{
		[TestMethod]
		public void TestCreateFileLogger()
		{
			var fileLogger = LoggerFactory.CreateFileLogger("C:");

			Assert.IsNotNull(fileLogger);
		}

		[TestMethod]
		public void TestCreateDatabaseLogger()
		{
			var databaseLogger = LoggerFactory.CreateDatabaseLogger("connection");

			Assert.IsNotNull(databaseLogger);
		}
	}
}
