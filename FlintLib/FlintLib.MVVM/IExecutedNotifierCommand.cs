using System;
using System.Windows.Input;

namespace FlintLib.MVVM
{
	public interface IExecutedNotifierCommand : ICommand
	{
		event CommandExecutedHandler Executed;
	}

	/// <summary>
	/// An interface to a command object that notifies when it has been executed.
	/// </summary>
	/// <typeparam name="R">The return type</typeparam>
	public interface IExecutedNotifierCommand<R> : ICommand
	{
		/// <summary>
		/// An event that fires after the command has been executed.
		/// </summary>
		/// <remarks>
		/// Be sure to unsubscribe delegates from this event before the subscriber is sent to garbage collection.
		/// </remarks>
		event CommandExecutedHandler<R> Executed;
	}
}
