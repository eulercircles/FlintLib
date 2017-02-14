using System;

namespace FlintLib.Core.Command
{
	/// <summary>
	/// 
	/// </summary>
	public interface ICommand
	{
		/// <summary>
		/// 
		/// </summary>
		bool CanExecute { get; }

		/// <summary>
		/// 
		/// </summary>
		CommandStatuses Status { get; }

		/// <summary>
		/// 
		/// </summary>
		void Execute();

		/// <summary>
		/// 
		/// </summary>
		void Undo();
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="P">The type of the parameter that gets passed to the Execute() method.</typeparam>
	public interface ICommand<P>
	{
		/// <summary>
		/// 
		/// </summary>
		bool CanExecute { get; }

		/// <summary>
		/// 
		/// </summary>
		CommandStatuses Status { get; }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
		void Execute(P parameter);

		/// <summary>
		/// 
		/// </summary>
		void Undo();
	}
}
