using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace FlintLib.MVVM
{
	public class Mediator : IMediator
	{
		private Dictionary<Type, Delegate> _registry;

		public Mediator()
		{
			_registry = new Dictionary<Type, Delegate>();
		}

		public void Register<T>(MediatorRespondent<T> respondent) where T : MediatorArgs
		{
			Debug.Assert(respondent != null);

			if (respondent != null)
			{
				lock (_registry)
				{
					if (_registry.ContainsKey(typeof(T)))
					{
						// Do not allow the same respondent to be registered more than once.
						if (_registry[typeof(T)] == null || !_registry[typeof(T)].GetInvocationList().Contains(respondent))
						{
							_registry[typeof(T)] = (MediatorRespondent<T>)_registry[typeof(T)] + respondent;
						}
					}
					else { _registry.Add(typeof(T), respondent); }
				}
			}
			else { throw new ArgumentNullException(nameof(respondent)); }
		}

		public void Unregister<T>(MediatorRespondent<T> respondent) where T : MediatorArgs
		{
			Debug.Assert(respondent != null);

			if (respondent != null)
			{
				lock (_registry)
				{
					if (_registry.ContainsKey(typeof(T)))
					{
						_registry[typeof(T)] = (MediatorRespondent<T>)_registry[typeof(T)] - respondent;
					}
				}
			}
		}

		public void NotifyColleagues<T>(T args) where T : MediatorArgs
		{
			Debug.Assert(args != null);

			if (args != null)
			{
				if (_registry.ContainsKey(typeof(T)))
				{
					if (_registry[typeof(T)] != null)
					{
						((MediatorRespondent<T>)_registry[typeof(T)])(args);
					}
				}
			}
			else { throw new ArgumentNullException(nameof(args)); }
		}
	}
}
