using System;
using System.Linq;
using System.Collections.Generic;

using Combinatorics.Collections;

namespace FlintLib.Music
{
	public static class ModeGenerator
	{
		public static Dictionary<string, PentatonicMode> GeneratePentatonics()
		{
			var minorSecond = (int)Intervals.MinorSecond;
			var majorSecond = (int)Intervals.MajorSecond;
			var minorThird = (int)Intervals.MinorThird;
			var majorThird = (int)Intervals.MajorThird;

			var values = new List<int>() { minorSecond, majorSecond, minorThird, majorThird };

			var variations = new Variations<int>(values, 5, GenerateOption.WithRepetition).ToList();

			var stepLists = variations.Where(s => (s.Sum() == 12)).ToList();

			var results = new Dictionary<string, PentatonicMode>();

			foreach (var stepList in stepLists)
			{
				var mode = new PentatonicMode(stepList.ToArray());

				if (Definitions.NamedPentatonicModes.ContainsKey(mode.IntervalSignature))
				{ mode.Name = Definitions.NamedPentatonicModes[mode.IntervalSignature]; }

				results.Add(mode.IntervalSignature, mode);
			}

			return results;
		}

		public static Dictionary<string, HeptatonicMode> GenerateHeptatonics()
		{
			var minorSecond = (int)Intervals.MinorSecond;
			var majorSecond = (int)Intervals.MajorSecond;
			var minorThird = (int)Intervals.MinorThird;

			var values = new List<int>() { minorSecond, majorSecond, minorThird };

			var variations = new Variations<int>(values, 7, GenerateOption.WithRepetition).ToList();

			var stepLists = variations.Where(s => (s.Sum() == 12)).ToList();

			var results = new Dictionary<string, HeptatonicMode>();

			foreach (var stepList in stepLists)
			{
				var signature = string.Empty;
				stepList.ToList().ForEach(s => signature += s.ToString());

				var modeName = Definitions.NamedHeptatonicModes.ContainsKey(signature) ?
					Definitions.NamedHeptatonicModes[signature] : signature;

				var mode = new HeptatonicMode(signature, modeName);
				
				results.Add(modeName, mode);
			}

			return results;
		}
	}
}
