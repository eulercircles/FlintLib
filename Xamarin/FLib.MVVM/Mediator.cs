using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace FLibXamarin.MVVM
{
	public delegate void Respondent<T>(T args) where T : MediatorArgs;

	public abstract class MediatorArgs
	{
		public string SenderType { get; }

		public MediatorArgs(object sender)
		{
			SenderType = sender.GetType().ToString();
		}
	}

	public sealed class Mediator
	{
		private readonly Dictionary<Type, Delegate> _registry = new Dictionary<Type, Delegate>();

		public void Notify<T>(T args) where T : MediatorArgs
		{
			Debug.Assert(args != null);

			if (args != null)
			{
				var argsType = typeof(T);
				if (_registry[argsType] != null)
				{
					((Respondent<T>)_registry[argsType])(args);
				}
			}
		}

		public void Register<T>(Respondent<T> respondent) where T : MediatorArgs
		{
			Debug.Assert(respondent != null);

			if (respondent != null)
			{
				lock (_registry)
				{
					var argsType = typeof(T);
					if (_registry.ContainsKey(argsType))
					{
						if (_registry[argsType] == null || !_registry[argsType].GetInvocationList().Contains(respondent))
						{
							_registry[argsType] = ((Respondent<T>)_registry[argsType]) + respondent;
						}
					}
					else { _registry.Add(typeof(T), respondent); }
				}
			}
		}

		public void Unregister<T>(Respondent<T> respondent) where T : MediatorArgs
		{
			Debug.Assert(respondent != null);

			if (respondent != null)
			{
				lock(_registry)
				{
					var argsType = typeof(T);
					if (_registry.ContainsKey(argsType))
					{
						_registry[argsType] = ((Respondent<T>)_registry[argsType]) - respondent;
					}
				}
			}
		}
	}
}
