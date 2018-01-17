using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Music
{
	public class PentatonicMode
	{
		private readonly int[] _intervals;

		public string Name { get; set; }
		public string IntervalSignature { get { return string.Concat(_intervals); } }

		public PentatonicMode(int[] intervals, string name = "")
		{
			if (intervals.Length != 5) { throw new ArgumentException("", nameof(intervals)); }

			_intervals = intervals;
			Name = name;
		}
	}

	public class PentatonicScale
	{
		private readonly PentatonicMode _mode;
		private readonly Notes _root;
		private readonly Accidentals _rootAccidental;
	}
}
