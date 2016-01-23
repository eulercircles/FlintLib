#region Using Statements
using System;
using System.Linq;
using System.Windows.Input;

using FlintLib.MVVM.Resources;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public class RelayCommand : ICommand
	{
		#region Private Members
		private Action _execute;
		private Func<bool> _canExecute;
		#endregion // Private Members

		#region Constructors
		public RelayCommand(Action execute)
			: this(execute, null) { }

		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			if (execute == null) { throw new ArgumentNullException(nameof(execute)); }

			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors

		private EventHandler _canExecuteChanged;

		public void TriggerCanExecuteChangedEvent()
		{
			if (_canExecuteChanged != null) { _canExecuteChanged(this, null); }
		}

		#region ICommand Implementation
		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecuteChanged == null || !_canExecuteChanged.GetInvocationList().Contains(value))
				{
					_canExecuteChanged += value;
				}
			}
			remove { _canExecuteChanged -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}

		public void Execute(object parameter)
		{
			_execute();
		}
		#endregion // ICommand Implementation
	}

	public class RelayCommand<T> : ICommand
	{
		#region Private Members
		private Action<T> _execute;
		private Func<bool> _canExecute;
		#endregion // Private Members

		#region Constructors
		public RelayCommand(Action<T> execute)
			: this(execute, null) { }

		public RelayCommand(Action<T> execute, Func<bool> canExecute)
		{
			if (execute == null) { throw new ArgumentNullException(nameof(execute)); }

			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors

		private EventHandler _canExecuteChanged;

		public void TriggerCanExecuteChanged()
		{
			if (_canExecuteChanged != null) { _canExecuteChanged(this, null); }
		}

		#region ICommand Implementation
		public event EventHandler CanExecuteChanged
		{
			add
			{
				if (_canExecuteChanged == null || !_canExecuteChanged.GetInvocationList().Contains(value))
				{
					_canExecuteChanged += value;
				}
			}
			remove { _canExecuteChanged -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}

		public void Execute(object parameter)
		{
			if (parameter is T)
			{
				_execute((T)parameter);
			}
			else { throw new ArgumentException(string.Format(ErrorStrings.ParameterIsNotAValidType, typeof(T), parameter.GetType())); }
		}
		#endregion // ICommand Implementation
	}
}
