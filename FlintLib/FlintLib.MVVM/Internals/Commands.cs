using System;
using System.Linq;
using System.Windows.Input;

using FlintLib.MVVM.Resources;

namespace FlintLib.MVVM
{
	public delegate void ExecuteAction();
	public delegate void ExecuteAction<P>(P parameter);
	public delegate R ExecuteFunction<P, R>(P parameter);
	public delegate R ExecuteFunction<R>();
	public delegate void CommandExecutedHandler();
	public delegate void CommandExecutedHandler<R>(R result);

	internal abstract class ExecutedNotifierCommand : IExecutedNotifierCommand
	{
		protected CommandExecutedHandler _executed;
		protected Func<bool> _canExecute;
		protected EventHandler _canExecuteChanged;

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecuteChanged == null || !_canExecuteChanged.GetInvocationList().Contains(value))
				{ _canExecuteChanged += value; }
			}
			remove { _canExecuteChanged -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}

		public event CommandExecutedHandler Executed
		{
			add
			{
				if (_executed == null || !_executed.GetInvocationList().Contains(value))
				{ _executed += value; }
			}
			remove { _executed -= value; }
		}

		public abstract void Execute(object parameter);
	}

	internal abstract class ExecutedNotifierCommand<R> : IExecutedNotifierCommand<R>
	{
		protected CommandExecutedHandler<R> _executed;
		protected Func<bool> _canExecute;
		protected EventHandler _canExecuteChanged;

		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecuteChanged == null || !_canExecuteChanged.GetInvocationList().Contains(value))
				{ _canExecuteChanged += value; }
			}
			remove { _canExecuteChanged -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}

		public event CommandExecutedHandler<R> Executed
		{
			add
			{
				if (_executed == null || !_executed.GetInvocationList().Contains(value))
				{ _executed += value; }
			}
			remove { _executed -= value; }
		}

		public abstract void Execute(object parameter);
	}

	/// <summary>
	/// 
	/// </summary>
	internal class ActionCommand : ExecutedNotifierCommand
	{
		private ExecuteAction _execute;

		internal ActionCommand(ExecuteAction executeDelegate) : this(executeDelegate, null) { }

		internal ActionCommand(ExecuteAction executeDelegate, Func<bool> canExecuteDelegate)
		{
			_execute = executeDelegate;
			_canExecute = canExecuteDelegate;
		}

		#region ExecutedNotifierCommand Implementation
		public override void Execute(object parameter)
		{
			if (CanExecute(null))
			{
				if (_execute != null) { _execute(); }
				if (_executed != null) { _executed(); }
			}
		}
		#endregion // ExecutedNotifierCommand Implementation
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="P">Parameter type</typeparam>
	internal class ActionCommand<P> : ExecutedNotifierCommand
	{
		#region Private Members
		private ExecuteAction<P> _execute;
		#endregion // Private Members

		internal ActionCommand(ExecuteAction<P> executeDelegate) : this(executeDelegate, null) { }

		internal ActionCommand(ExecuteAction<P> executeDelegate, Func<bool> canExecuteDelegate)
		{
			_execute = executeDelegate;
			_canExecute = canExecuteDelegate;
		}

		#region ExecutedNotifierCommand Implementation
		public override void Execute(object parameter)
		{
			if (CanExecute(null))
			{
				if (_execute != null)
				{
					if (parameter is P)
					{
						_execute((P)parameter);
						if (_executed != null) { _executed(); }
					}
					else { throw new ArgumentException(
						string.Format(ErrorStrings.ParameterIsNotAValidType, typeof(P), parameter.GetType())); }
				}
			}
		}
		#endregion // ExecutedNotifierCommand Implementation
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="R">Return type</typeparam>
	internal class FunctionCommand<R> : ExecutedNotifierCommand<R>
	{
		private ExecuteFunction<R> _execute;

		internal FunctionCommand(ExecuteFunction<R> executeDelegate) : this(executeDelegate, null) { }

		internal FunctionCommand(ExecuteFunction<R> executeDelegate, Func<bool> canExecuteDelegate)
		{
			_execute = executeDelegate;
			_canExecute = canExecuteDelegate;
		}

		#region ExecutedNotifierCommand Implementation
		public override void Execute(object parameter)
		{
			if (CanExecute(null))
			{
				if (_execute != null)
				{
					R result = _execute();
					if (_executed != null) { _executed(result); }
				}
			}
		}
		#endregion // ExecutedNotifierCommand Implementation
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="P">Parameter type</typeparam>
	/// <typeparam name="R">Return type</typeparam>
	internal class FunctionCommand<P, R> : ExecutedNotifierCommand<R>
	{
		private ExecuteFunction<P, R> _execute;

		internal FunctionCommand(ExecuteFunction<P, R> executeDelegate) { }

		internal FunctionCommand(ExecuteFunction<P, R> executeDelegate, Func<bool> canExecuteDelegate) { }

		#region ExecutedNotifierCommand Implementation
		public override void Execute(object parameter)
		{
			if (CanExecute(null))
			{
				if (parameter is P)
				{
					if (_execute != null)
					{
						R result = _execute((P)parameter);
						if (_executed != null) { _executed(result); }
					}
				}
				else { throw new ArgumentException(string.Format(ErrorStrings.ParameterIsNotAValidType, typeof(P), parameter.GetType())); }
			}
		}
		#endregion // ExecutedNotifierCommand Implementation
	}
}
