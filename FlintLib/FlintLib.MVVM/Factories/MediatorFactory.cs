using System;

using FlintLib.MVVM.Mediator;

namespace FlintLib.MVVM
{
	/// <summary>
	/// 
	/// </summary>
	public static class MediatorFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public static IMediator Create()
		{
			return new Mediator.Mediator();
		}
	}
}
