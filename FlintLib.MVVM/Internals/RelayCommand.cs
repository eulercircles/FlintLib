#region Using Statements
using System;
using System.Linq;
using System.Windows.Input;

using static FlintLib.MVVM.Properties.PublicResources;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	public class RelayCommand : ICommand
	{
		#region Private Members
		private readonly Action _execute;
		private readonly Func<bool> _canExecute;
		#endregion // Private Members

		#region Constructors
		public RelayCommand(Action execute)
			: this(execute, null) { }

		public RelayCommand(Action execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}
		#endregion // Constructors

		private EventHandler _canExecuteChanged;

		/// <summary>
		/// 
		/// </summary>
		public void TriggerCanExecuteChangedEvent()
		{
			_canExecuteChanged?.Invoke(this, null);
		}

		#region ICommand Implementation
		/// <summary>
		/// 
		/// </summary>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			_execute();
		}
		#endregion // ICommand Implementation
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class RelayCommand<T> : ICommand
	{
		#region Private Members
		private readonly Action<T> _execute;
		private readonly Func<bool> _canExecute;
		#endregion // Private Members

		#region Constructors
		public RelayCommand(Action<T> execute)
			: this(execute, null) { }

		public RelayCommand(Action<T> execute, Func<bool> canExecute)
		{
			_execute = execute ?? throw new ArgumentNullException(nameof(execute));
			_canExecute = canExecute;
		}
		#endregion // Constructors

		private EventHandler _canExecuteChanged;

		/// <summary>
		/// 
		/// </summary>
		public void TriggerCanExecuteChanged()
		{
			_canExecuteChanged?.Invoke(this, null);
		}

		#region ICommand Implementation
		/// <summary>
		/// 
		/// </summary>
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
		/// <returns></returns>
		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			if (parameter is T)
			{
				_execute((T)parameter);
			}
			else { throw new ArgumentException(string.Format(ParameterIsNotAValidType, typeof(T), parameter.GetType())); }
		}
		#endregion // ICommand Implementation
	}
}
