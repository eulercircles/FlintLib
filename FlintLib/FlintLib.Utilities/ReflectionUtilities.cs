using System;
using System.Linq.Expressions;

namespace FlintLib.Utilities
{
	public static class ReflectionUtilities
	{
		public static string GetVariableName<T>(Expression<Func<T>> expression)
		{
			var body = (MemberExpression)expression.Body;
			return body.Member.Name;
		}
	}
}
