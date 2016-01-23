using System;
using System.Windows.Input;

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
		/// <param name="executeDelegate"></param>
		/// <returns></returns>
		public static IExecutedNotifierCommand CreateActionCommand(ExecuteAction executeDelegate) { return new ActionCommand(executeDelegate); }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="executeDelegate"></param>
		/// <param name="canExecuteDelegate"></param>
		/// <returns></returns>
		public static IExecutedNotifierCommand CreateActionCommand(ExecuteAction executeDelegate, Func<bool> canExecuteDelegate) { return new ActionCommand(executeDelegate, canExecuteDelegate); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="P"></typeparam>
		/// <param name="executeDelegate"></param>
		/// <returns></returns>
		public static IExecutedNotifierCommand CreateActionCommand<P>(ExecuteAction<P> executeDelegate) { return new ActionCommand<P>(executeDelegate); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="P">The parameter type</typeparam>
		/// <param name="executeDelegate"></param>
		/// <param name="canExecuteDelegate"></param>
		/// <returns></returns>
		public static IExecutedNotifierCommand CreateActionCommand<P>(ExecuteAction<P> executeDelegate, Func<bool> canExecuteDelegate) { return new ActionCommand<P>(executeDelegate, canExecuteDelegate); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="R">The return type</typeparam>
		/// <param name="executeDelegate"></param>
		/// <returns></returns>
		public static IExecutedNotifierCommand<R> CreateFunctionCommand<R>(ExecuteFunction<R> executeDelegate) { return new FunctionCommand<R>(executeDelegate); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="R">The return type</typeparam>
		/// <param name="executeDelegate"></param>
		/// <param name="canExecuteDelegate"></param>
		/// <returns></returns>
		public static IExecutedNotifierCommand<R> CreateFunctionCommand<R>(ExecuteFunction<R> executeDelegate, Func<bool> canExecuteDelegate) { return new FunctionCommand<R>(executeDelegate, canExecuteDelegate); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="P">The parameter type</typeparam>
		/// <typeparam name="R">The return type</typeparam>
		/// <param name="executeDelegate"></param>
		/// <returns></returns>
		public static IExecutedNotifierCommand<R> CreateFunctionCommand<P, R>(ExecuteFunction<P, R> executeDelegate) { return new FunctionCommand<P, R>(executeDelegate); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="P">The parameter type</typeparam>
		/// <typeparam name="R">The return type</typeparam>
		/// <param name="executeDelegate"></param>
		/// <param name="canExecuteDelegate"></param>
		/// <returns></returns>
		public static IExecutedNotifierCommand<R> CreateFunctionCommand<P, R>(ExecuteFunction<P, R> executeDelegate, Func<bool> canExecuteDelegate) { return new FunctionCommand<P, R>(executeDelegate, canExecuteDelegate); }


		public static ICommand CreateRelayCommand(Action execute) { return new RelayCommand(execute); }


		public static ICommand CreateRelayCommand(Action execute, Func<bool> canExecute) { return new RelayCommand(execute, canExecute); }


		public static ICommand CreateRelayCommand<T>(Action<T> execute) { return new RelayCommand<T>(execute); }


		public static ICommand CreateRelayCommand<T>(Action<T> execute, Func<bool> canExecute) { return new RelayCommand<T>(execute, canExecute); }
	}
}
