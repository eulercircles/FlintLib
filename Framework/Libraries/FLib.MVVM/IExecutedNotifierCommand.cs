using System.Windows.Input;

namespace FLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	public interface IExecutedNotifierCommand : ICommand
	{
		/// <summary>
		/// 
		/// </summary>
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
