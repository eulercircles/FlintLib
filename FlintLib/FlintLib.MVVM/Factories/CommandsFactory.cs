#region Using Directives
using System;
using System.Windows.Input;
#endregion Using Directives

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	public static class CommandsFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		/// <returns></returns>
		public static ICommand CreateRelayCommand(Action execute, Func<bool> canExecute = null) { return new RelayCommand(execute, canExecute); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		/// <returns></returns>
		public static ICommand CreateRelayCommand<T>(Action<T> execute, Func<bool> canExecute = null) { return new RelayCommand<T>(execute, canExecute); }
	}
}
