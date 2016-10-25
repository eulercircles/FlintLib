using System;

namespace FlintLib.Utilities
{
	/// <summary>
	/// 
	/// </summary>
	public static class Preconditions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="item"></param>
		/// <returns></returns>
		public static T CheckNotNull<T>(T item) where T : class
		{
			if (item != null) { return item; }
			else { throw new ArgumentNullException(); }
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueString"></param>
        /// <returns></returns>
        public static bool IsInteger(this string valueString)
        {
            double parsedValue;
            if (double.TryParse(valueString, out parsedValue))
            {
                if (parsedValue - Math.Truncate(parsedValue) == 0)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueString"></param>
        /// <returns></returns>
        public static bool IsNumericValue(this string valueString)
        {
            double parsedValue;
            return double.TryParse(valueString, out parsedValue);
        }
	}
}
