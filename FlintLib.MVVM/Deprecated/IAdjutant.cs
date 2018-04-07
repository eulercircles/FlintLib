#region Using Statements
using System;
#endregion // Using Statements

namespace FlintLib.MVVM
{
    [Obsolete("Do not use.", true)]
    public interface IAdjutant
	{
		void RegisterExecutor<T>(Executor<T> handler) where T : Command;
		void UnregisterExecutor<T>(Executor<T> handler) where T : Command;
		void IssueCommand<T>(object sender, T commandObject) where T : Command;
	}

	public delegate void Executor<T>(object sender, T commandObject) where T : Command;

	public abstract class Command {}

	public abstract class Command<T> : Command
	{
		public T Parameter { get; private set; }

		public Command(T parameter)
		{
			Parameter = parameter;
		}
	}
}
