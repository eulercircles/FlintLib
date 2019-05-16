using System;

namespace FLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	public delegate void ExecuteAction();

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="P"></typeparam>
	/// <param name="parameter"></param>
	public delegate void ExecuteAction<P>(P parameter);

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="P"></typeparam>
	/// <typeparam name="R"></typeparam>
	/// <param name="parameter"></param>
	/// <returns></returns>
	public delegate R ExecuteFunction<P, R>(P parameter);

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="R"></typeparam>
	/// <returns></returns>
	public delegate R ExecuteFunction<R>();

	/// <summary>
	/// 
	/// </summary>
	public delegate void CommandExecutedHandler();

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="R"></typeparam>
	/// <param name="result"></param>
	public delegate void CommandExecutedHandler<R>(R result);
}
