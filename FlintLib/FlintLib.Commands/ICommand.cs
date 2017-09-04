using System;

namespace FlintLib.Commands
{
	public interface ICommand
	{
		object Execute(object parameter);
	}

	public interface IActionCommand : ICommand
	{
		void Execute();
	}

	public interface IActionCommand<P> : ICommand
	{
		void Execute(P parameter);
	}

	public interface IFunctionCommand<R> : ICommand
	{
		R Execute();
	}

	public interface IFunctionCommand<R, P> : ICommand
	{
		R Execute(P parameter);
	}
}
