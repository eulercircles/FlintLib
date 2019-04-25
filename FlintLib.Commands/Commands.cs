using System;
using System.Windows.Input;

namespace FLib.Commands
{
	public abstract class ActionCommand : IActionCommand
	{
		protected Action _executionDelegate;

		public ActionCommand(Action executionDelegate)
		{
			_executionDelegate = executionDelegate ?? throw new ArgumentNullException(nameof(executionDelegate));
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			throw new NotImplementedException();
		}

		public virtual void Execute()
		{
			_executionDelegate.Invoke();
		}

		public object Execute(object parameter)
		{
			Execute();
			return null;
		}

		void ICommand.Execute(object parameter)
		{
			throw new NotImplementedException();
		}
	}

	public abstract class ActionCommand<P> : IActionCommand<P>
	{
		protected Action<P> _executionDelegate;

		public ActionCommand(Action<P> executionDelegate)
		{
			_executionDelegate = executionDelegate ?? throw new ArgumentNullException(nameof(executionDelegate));
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			throw new NotImplementedException();
		}

		public virtual void Execute(P parameter)
		{
			_executionDelegate.Invoke(parameter);
		}

		public object Execute(object parameter)
		{
			Execute((P)parameter);
			return null;
		}

		void ICommand.Execute(object parameter)
		{
			throw new NotImplementedException();
		}
	}

	public abstract class FunctionCommand<R> : IFunctionCommand<R>
	{
		protected Function<R> _executionDelegate;

		public FunctionCommand(Function<R> executionDelegate)
		{
			_executionDelegate = executionDelegate ?? throw new ArgumentNullException(nameof(executionDelegate));
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			throw new NotImplementedException();
		}

		public virtual R Execute()
		{
			return _executionDelegate.Invoke();
		}

		public object Execute(object parameter)
		{
			return Execute();
		}

		void ICommand.Execute(object parameter)
		{
			throw new NotImplementedException();
		}
	}

	public abstract class FunctionCommand<R, P> : IFunctionCommand<R, P>
	{
		protected Function<R, P> _executionDelegate;

		public FunctionCommand(Function<R, P> executionDelegate)
		{
			_executionDelegate = executionDelegate ?? throw new ArgumentNullException(nameof(executionDelegate));
		}

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			throw new NotImplementedException();
		}

		public virtual R Execute(P parameter)
		{
			return _executionDelegate.Invoke(parameter);
		}

		public object Execute(object parameter)
		{
			return Execute((P)parameter);
		}

		void ICommand.Execute(object parameter)
		{
			throw new NotImplementedException();
		}
	}
}
