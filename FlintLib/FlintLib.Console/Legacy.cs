using System;

namespace FlintLib.Console
{
	public static class Legacy
	{
		public static void Pause()
		{
			System.Console.WriteLine("Press any key to continue ...");
			System.Console.ReadKey();
		}
	}
}
