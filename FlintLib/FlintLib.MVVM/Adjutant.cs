#region Using Statements
using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

using FlintLib.Utilities;
#endregion // Using Statements

namespace FlintLib.MVVM
{
	public class Adjutant : IAdjutant
	{
		private Dictionary<Type, Delegate> _commandRegistry;

		public Adjutant()
		{
			this._commandRegistry = new Dictionary<Type, Delegate>();
		}

		public void RegisterExecutor<T>(Executor<T> executor) where T : Command
		{
			Debug.Assert(executor != null);

			if (executor != null)
			{
				Type commandType = typeof(T);

				lock (this._commandRegistry)
				{
					if (this._commandRegistry.ContainsKey(commandType))
					{
						// Do not allow the same handler to be registered more than once.
						if (this._commandRegistry[commandType] == null
							|| !this._commandRegistry[commandType].GetInvocationList().Contains(executor))
						{
							this._commandRegistry[commandType]
								= (Executor<T>)this._commandRegistry[commandType] + executor;
						}
					}
					else { this._commandRegistry.Add(commandType, executor); }
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

				lock (this._commandRegistry)
				{
					if (this._commandRegistry.ContainsKey(commandType))
					{
						this._commandRegistry[commandType] = (Executor<T>)this._commandRegistry[commandType] - executor;
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

				if (this._commandRegistry.ContainsKey(commandType))
				{
					if (this._commandRegistry[commandType] != null)
					{
						((Executor<T>)this._commandRegistry[commandType])(sender, commandObject);
					}
				}
			}
			else { throw new ArgumentNullException(nameof(commandObject)); }
		}
	}
}
