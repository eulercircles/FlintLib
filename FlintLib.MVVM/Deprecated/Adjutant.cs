#region Using Statements
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	[Obsolete("Do not use.", true)]
	public class Adjutant : IAdjutant
	{
		private readonly Dictionary<Type, Delegate> _commandRegistry;

		public Adjutant()
		{
			_commandRegistry = new Dictionary<Type, Delegate>();
		}

		public void RegisterExecutor<T>(Executor<T> executor) where T : Command
		{
			Debug.Assert(executor != null);

			if (executor != null)
			{
				Type commandType = typeof(T);

				lock (_commandRegistry)
				{
					if (_commandRegistry.ContainsKey(commandType))
					{
						// Do not allow the same handler to be registered more than once.
						if (_commandRegistry[commandType] == null
							|| !_commandRegistry[commandType].GetInvocationList().Contains(executor))
						{
							_commandRegistry[commandType] = (Executor<T>)_commandRegistry[commandType] + executor;
						}
						else { /* Do nothing. */ }
					}
					else { _commandRegistry.Add(commandType, executor); }
				}
			}
			else { throw new ArgumentNullException(nameof(executor)); }
		}

		public void UnregisterExecutor<T>(Executor<T> executor) where T : Command
		{
			Debug.Assert(executor != null);

			if (executor != null)
			{
				Type commandType = typeof(T);

				lock (_commandRegistry)
				{
					if (_commandRegistry.ContainsKey(commandType))
					{
						_commandRegistry[commandType] = (Executor<T>)_commandRegistry[commandType] - executor;
					}
				}
			}
			else { throw new ArgumentNullException(nameof(executor)); }
		}

		public void IssueCommand<T>(object sender, T commandObject) where T : Command
		{
			Debug.Assert(commandObject != null);

			if (commandObject != null)
			{
				Type commandType = typeof(T);

				if (_commandRegistry.ContainsKey(commandType))
				{
					if (_commandRegistry[commandType] != null)
					{
						((Executor<T>)_commandRegistry[commandType])(sender, commandObject);
					}
				}
			}
			else { throw new ArgumentNullException(nameof(commandObject)); }
		}
	}
}
