using System;
using System.Linq;
using System.Windows.Input;

using static FLib.Common.Messages;

namespace FLib.Commands
{
	public class RelayCommand : ICommand
	{
		private readonly Action _execute;
		private readonly Func<bool> _canExecute;
		private readonly EventHandler _canExecuteChanged;

		public RelayCommand(Action execute) : this(execute, null) { }

		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}
		
		public void TriggerCanExecuteChangedEvent() => _canExecuteChanged?.Invoke(this, null);

		public event EventHandler CanExecuteChanged
		{
			add { Subscribe(_canExecuteChanged, value); }
			remove { Unsubscribe(_canExecuteChanged, value); }
		}

		public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute();

		public void Execute(object parameter) => _execute();
	}

	public class RelayCommand<T> : ICommand
	{
		private readonly Action<T> _execute;
		private readonly Func<bool> _canExecute;

		public RelayCommand(Action<T> execute)
			: this(execute, null) { }

		public RelayCommand(Action<T> execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}

		private readonly EventHandler _canExecuteChanged;

		public void TriggerCanExecuteChanged() => _canExecuteChanged?.Invoke(this, null);

		public event EventHandler CanExecuteChanged
		{
			add { Subscribe(_canExecuteChanged, value); }
			remove { Unsubscribe(_canExecuteChanged, value); }
		}

		public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute();

		public void Execute(object parameter)
		{
			if (parameter is T) { _execute((T)parameter); }
			else { throw new ArgumentException(string.Format(fMessage_ParameterIsNotAValidType, typeof(T), parameter.GetType())); }
		}
	}
}
