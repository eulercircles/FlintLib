using System;

namespace FlintLib.Music
{
	public class PentatonicMode
	{
		private readonly int[] _intervals;

		public string Name { get; set; }
		public string IntervalSignature { get { return string.Concat(_intervals); } }

		public PentatonicMode(int[] intervals, string name = "")
		{
			_intervals = (intervals.Length == 5) ? intervals : throw new ArgumentException("", nameof(intervals));

			Name = name;
		}
	}

	public class PentatonicScale
	{
		private readonly PentatonicMode _mode;
		private readonly Note _root;

		internal PentatonicScale(Note root, PentatonicMode mode)
		{
			_root = root;
			_mode = mode;
		}
	}
}
