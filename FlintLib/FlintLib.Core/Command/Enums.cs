using System;

namespace FlintLib.Core.Command
{
	/// <summary>
	/// 
	/// </summary>
	public enum CommandStatuses
	{
		/// <summary>
		/// The command has not yet been executed.
		/// </summary>
		NotExecuted,

		/// <summary>
		/// The command has been executed successfully.
		/// </summary>
		ExecuteSucceeded,

		/// <summary>
		/// The command was attempted to be executed, but failed.
		/// </summary>
		ExecuteFailed,

		/// <summary>
		/// The command has been undone successfully.
		/// </summary>
		UndoSucceeded,

		/// <summary>
		/// The command was attempted to be undone, but failed.
		/// </summary>
		UndoFailed
	}
}
