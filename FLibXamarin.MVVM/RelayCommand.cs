using System;
using System.Linq;
using System.Windows.Input;

using static FLibXamarin.MVVM.Properties.InternalStrings;

namespace FLibXamarin.MVVM
{
	public class RelayCommand : ICommand
	{
		private readonly Action _execute;
		private readonly Func<bool> _canExecute;

		public RelayCommand(Action execute) : this(execute, null) { }

		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}

		private EventHandler _canExecuteChanged;
		public event EventHandler CanExecuteChanged
		{
			add { if (_canExecuteChanged == null || !_canExecuteChanged.GetInvocationList().Contains(value)) { _canExecuteChanged += value; } }
			remove { if (_canExecuteChanged != null && _canExecuteChanged.GetInvocationList().Contains(value)) { _canExecuteChanged -= value; } }
		}

		public void TriggerCanExecuteChanged() => _canExecuteChanged?.Invoke(this, null);

		public bool CanExecute(object parameter) => _canExecute == null ? true : _canExecute();

		public void Execute(object parameter) => _execute();
	}

	public class RelayCommand<T> : ICommand
	{
		private readonly Action<T> _execute;
		private readonly Func<bool> _canExecute;

		public RelayCommand(Action<T> execute) : this(execute, null) { }

		public RelayCommand(Action<T> execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}

		private EventHandler _canExecuteChanged;
		public event EventHandler CanExecuteChanged
		{
			add { if (_canExecuteChanged == null || !_canExecuteChanged.GetInvocationList().Contains(value)) { _canExecuteChanged += value; } }
			remove { if (_canExecuteChanged != null && _canExecuteChanged.GetInvocationList().Contains(value)) { _canExecuteChanged -= value; } }
		}

		public void TriggerCanExecuteChanged() => _canExecuteChanged?.Invoke(this, null);

		public bool CanExecute(object parameter) =>  _canExecute == null ? true : _canExecute();

		public void Execute(object parameter)
		{
			if (parameter is T) { _execute?.Invoke((T)parameter); }
			else { throw new ArgumentException(string.Format(fMessage_ParameterIsNotAValidType, typeof(T), parameter.GetType())); }
		}
	}
}
