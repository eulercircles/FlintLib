using System;
using System.Linq;
using System.Text;

namespace FlintLib.Common
{
	public static class StringUtilities
	{
		private static readonly StringBuilder _stringBuilder = new StringBuilder();

		private const int _uniqueIDLengthLowerLimit = 1;
		private const int _uniqueIDLenghtUpperLimit = 32;

		public static string NewLines(ushort count)
		{
			var result = string.Empty;
			for (int i = 0; i < count; i++) { result += Environment.NewLine; }
			return result;
		}

		public static string GenerateUniqueID(int length)
		{
			if (!length.IsInRange(_uniqueIDLengthLowerLimit, _uniqueIDLenghtUpperLimit))
			{ throw new ArgumentOutOfRangeException(nameof(length), $"Must choose a value between {_uniqueIDLengthLowerLimit} and {_uniqueIDLenghtUpperLimit}."); }

			_stringBuilder.Clear();

			Enumerable.Range(65, 26)
			.Select(e => ((char)e).ToString())
			.Concat(Enumerable.Range(97, 26).Select(e => ((char)e).ToString()))
			.Concat(Enumerable.Range(0, 10).Select(e => e.ToString()))
			.OrderBy(e => Guid.NewGuid())
			.Take(length)
			.ToList().ForEach(e => _stringBuilder.Append(e));

			return _stringBuilder.ToString();
		}
	}
}
