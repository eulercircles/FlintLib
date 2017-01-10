using System;
using System.Collections.Generic;

namespace FlintLib.MVVM
{
	using Internals;
	/// <summary>
	/// 
	/// </summary>
	public static class BindablesFactory
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static IBindable<T> Create<T>()
		{ return new Bindable<T>(); }

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="initialValue"></param>
		/// <returns></returns>
		public static IBindable<T> Create<T>(T initialValue)
		{ return new Bindable<T>(initialValue); }
	}
}
