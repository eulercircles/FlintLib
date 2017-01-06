using System;
using System.Collections.Generic;

namespace FlintLib.MVVM.Mediator
{
	/// <summary>
	/// 
	/// </summary>
	public interface IMediator
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <param name="executor"></param>
		void Register<R>(RequestExecutor<R> executor) where R : Request;

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <param name="executor"></param>
		void Unregister<R>(RequestExecutor<R> executor) where R : Request;

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="R"></typeparam>
		/// <param name="request"></param>
		void IssueRequest<R>(R request) where R : Request;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="R"></typeparam>
	/// <param name="request"></param>
	public delegate void RequestExecutor<R>(R request) where R : Request;
}
