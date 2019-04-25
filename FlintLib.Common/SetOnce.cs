using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Common
{
	/// <summary>
	/// 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class SetOnce<T>
	{
		private bool _isSet = false;

		private T _value;
		public T Value
		{
			get { return _value; }
			set
			{
				if (!_isSet)
				{
					_value = value;
					_isSet = true;
				}
			}
		}
	}
}
