#region Using Directives
using System;
using System.Linq;
using System.Windows.Input;

using FlintLib.MVVM.Resources;
#endregion Using Directives

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	internal class RelayCommand : ICommand
	{
		#region Private Members
		private Action _execute;
		private Func<bool> _canExecute;
		#endregion // Private Members

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		public RelayCommand(Action execute, Func<bool> canExecute = null)
		{
			if (execute == null) { throw new ArgumentNullException(nameof(execute)); }

			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors

		private EventHandler _canExecuteChanged;

		/// <summary>
		/// 
		/// </summary>
		protected void TriggerCanExecuteChangedEvent()
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
		private Action<T> _execute;
		private Func<bool> _canExecute;
		#endregion // Private Members

		#region Constructors
		/// <summary>
		/// 
		/// </summary>
		/// <param name="execute"></param>
		/// <param name="canExecute"></param>
		public RelayCommand(Action<T> execute, Func<bool> canExecute = null)
		{
			if (execute == null) { throw new ArgumentNullException(nameof(execute)); }

			_execute = execute;
			_canExecute = canExecute;
		}
		#endregion // Constructors

		private EventHandler _canExecuteChanged;

		/// <summary>
		/// 
		/// </summary>
		protected void TriggerCanExecuteChanged()
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
			else { throw new ArgumentException(string.Format(ErrorStrings.ParameterIsNotAValidType, typeof(T), parameter.GetType())); }
		}
		#endregion // ICommand Implementation
	}
}
