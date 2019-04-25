using System;

namespace FLibXamarin.Common
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SetOnce<T>
	{
		public bool IsSet { get; private set; }

		private T _value;
		public T Value
		{
			get { return _value; }
			set
			{
				if (!IsSet)
				{
					_value = value;
					IsSet = true;
				}
				else { throw new MemberAccessException("The value is already set."); }
			}
		}
	}
}
