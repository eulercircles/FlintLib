using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

namespace FlintLib.MVVM.Mediator
{
	/// <summary>
	/// 
	/// </summary>
	public sealed class Mediator : IMediator
	{
		private Dictionary<Type, Delegate> _registry;

		/// <summary>
		/// 
		/// </summary>
		public Mediator()
		{
			this._registry = new Dictionary<Type, Delegate>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <param name="executor"></param>
		public void Register<R>(RequestExecutor<R> executor) where R : Request
		{
			Debug.Assert(executor != null);

			if (executor != null)
			{
				lock (this._registry)
				{
					if (this._registry.ContainsKey(typeof(R)))
					{
						// Do not allow the same respondent to be registered more than once.
						if (this._registry[typeof(R)] == null
							|| !this._registry[typeof(R)].GetInvocationList().Contains(executor))
						{
							this._registry[typeof(R)]
								= (RequestExecutor<R>)this._registry[typeof(R)] + executor;
						}
					}
					else { this._registry.Add(typeof(R), executor); }
				}
			}
			else { throw new ArgumentNullException(nameof(executor)); }
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <param name="executor"></param>
		public void Unregister<R>(RequestExecutor<R> executor) where R : Request
		{
			Debug.Assert(executor != null);

			if (executor != null)
			{
				lock (this._registry)
				{
					if (this._registry.ContainsKey(typeof(R)))
					{
						this._registry[typeof(R)] = (RequestExecutor<R>)this._registry[typeof(R)] - executor;
					}
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <param name="request"></param>
		public void IssueRequest<R>(R request) where R : Request
		{
			Debug.Assert(request != null);

			if (request != null)
			{
				if (this._registry.ContainsKey(typeof(R)))
				{
					if (this._registry[typeof(R)] != null)
					{
						((RequestExecutor<R>)this._registry[typeof(R)])(request);
					}
				}
			}
			else { throw new ArgumentNullException(nameof(request)); }
		}
	}
}
