using System.Collections.Generic;
using System.Diagnostics;

namespace FLib.Genetics
{
	public class Gamete
	{
		public IReadOnlyList<string> Sequence { get; private set; }

		public Gamete(List<string> sequence)
		{
			Debug.Assert(sequence != null && sequence.Count > 0);

			Sequence = sequence;
		}
	}
}
