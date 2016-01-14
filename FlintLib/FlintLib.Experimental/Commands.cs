using System;
using System.Linq;
using System.Windows.Input;

using FlintLib.Experimental.Resources;

namespace FlintLib.Experimental
{
	public delegate void ExecuteAction();
	public delegate void ExecuteAction<P>(P parameter);
	public delegate R ExecuteFunction<P, R>(P parameter);
	public delegate R ExecuteFunction<R>();
	public delegate void CommandExecutedHandler();
	public delegate void CommandExecutedHandler<R>(R result);

	/// <summary>
	/// 
	/// </summary>
	public class ActionCommand : ICommand
	{
		private ExecuteAction _execute;
		private Func<bool> _canExecute;

		private CommandExecutedHandler _executed;
		public event CommandExecutedHandler Executed
		{
			add
			{
				if (_executed == null || !_executed.GetInvocationList().Contains(value))
				{ _executed += value; }
			}
			remove { _executed -= value; }
		}

		public ActionCommand(ExecuteAction executeDelegate) : this(executeDelegate, null) { }

		public ActionCommand(ExecuteAction executeDelegate, Func<bool> canExecuteDelegate)
		{
			_execute = executeDelegate;
			_canExecute = canExecuteDelegate;
		}

		private EventHandler _canExecuteChanged;

		#region ICommand Implementation
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

		public void Execute(object parameter)
		{
			if (CanExecute(null))
			{
				if (_execute != null) { _execute(); }
				if (_executed != null) { _executed(); }
			}
		}
		#endregion // ICommand Implementation
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="P">Parameter type</typeparam>
	public class ActionCommand<P> : ICommand
	{
		private ExecuteAction<P> _execute;
		private Func<bool> _canExecute;

		private CommandExecutedHandler _executed;
		public event CommandExecutedHandler Executed
		{
			add
			{
				if (_executed == null || !_executed.GetInvocationList().Contains(value))
				{ _executed += value; }
			}
			remove { _executed -= value; }
		}

		public ActionCommand(ExecuteAction<P> executeDelegate) : this(executeDelegate, null) { }

		public ActionCommand(ExecuteAction<P> executeDelegate, Func<bool> canExecuteDelegate)
		{
			_execute = executeDelegate;
			_canExecute = canExecuteDelegate;
		}

		private EventHandler _canExecuteChanged;

		#region ICommand Implementation
		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}

		public void Execute(object parameter)
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
					else { throw new ArgumentException(ErrorStrings.ParameterIsNotAValidType); }
				}
			}
		}
		#endregion // ICommand Implementation
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="R">Return type</typeparam>
	public class FunctionCommand<R> : ICommand
	{
		private ExecuteFunction<R> _execute;
		private Func<bool> _canExecute;

		private CommandExecutedHandler<R> _executed;
		public event CommandExecutedHandler<R> Executed
		{
			add
			{
				if (_executed == null || !_executed.GetInvocationList().Contains(value))
				{ _executed += value; }
			}
			remove { _executed -= value; }
		}

		public FunctionCommand(ExecuteFunction<R> executeDelegate) : this(executeDelegate, null) { }

		public FunctionCommand(ExecuteFunction<R> executeDelegate, Func<bool> canExecuteDelegate)
		{
			_execute = executeDelegate;
			_canExecute = canExecuteDelegate;
		}

		private EventHandler _canExecuteChanged;

		#region ICommand Implementation
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

		public void Execute(object parameter)
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
		#endregion // ICommand Implementation
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="P">Parameter type</typeparam>
	/// <typeparam name="R">Return type</typeparam>
	public class FunctionCommand<P, R> : ICommand
	{
		#region Private Members
		private ExecuteFunction<P, R> _execute;
		private Func<bool> _canExecute;
		#endregion // Private Members

		private CommandExecutedHandler<R> _executed;
		public event CommandExecutedHandler<R> Executed
		{
			add
			{
				if (_executed == null || !_executed.GetInvocationList().Contains(value))
				{ _executed += value; }
			}
			remove { _executed -= value; }
		}

		public FunctionCommand(ExecuteFunction<P, R> executor) { }

		public FunctionCommand(ExecuteFunction<P, R> executor, Func<bool> canExecute) { }

		private EventHandler _canExecuteChanged;

		#region ICommand Implementation
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

		public void Execute(object parameter)
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
				else { throw new ArgumentException(ErrorStrings.ParameterIsNotAValidType); }
			}
		}
		#endregion // ICommand Implementation
	}
}
