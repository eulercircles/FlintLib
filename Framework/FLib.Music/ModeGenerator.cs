using System;
using System.Linq;
using System.Collections.Generic;

using Combinatorics.Collections;

using static FLib.Music.Values;

namespace FLib.Music
{
	public static class ModeGenerator
	{
		public static Dictionary<string, PentatonicMode> GenerateAllPentatonics()
		{
			var values = new List<int>() { (int)Intervals.MinorSecond, (int)Intervals.MajorSecond, (int)Intervals.MinorThird, (int)Intervals.MajorThird };
			var variations = new Variations<int>(values, PENTATONIC_COUNT, GenerateOption.WithRepetition).ToList();
			var stepLists = variations.Where(steps => steps.Sum() == CHROMATIC_COUNT).ToList();

			var results = new Dictionary<string, PentatonicMode>();

			stepLists.ForEach(steps => {
				var mode = new PentatonicMode(steps.ToArray());
				if (Definitions.NamedPentatonicModes.ContainsKey(mode.IntervalSignature))
				{ mode.Name = Definitions.NamedPentatonicModes[mode.IntervalSignature]; }
				results.Add(mode.IntervalSignature, mode);
			});

			return results;
		}

		public static Dictionary<string, HeptatonicMode> GenerateAllHeptatonics()
		{
			var values = new List<int>() { (int)Intervals.MinorSecond, (int)Intervals.MajorSecond, (int)Intervals.MinorThird };
			var variations = new Variations<int>(values, HEPTATONIC_COUNT, GenerateOption.WithRepetition).ToList();
			var stepLists = variations.Where(steps => steps.Sum() == CHROMATIC_COUNT).ToList();

			var results = new Dictionary<string, HeptatonicMode>();

			foreach (var stepList in stepLists)
			{
				var signature = string.Empty;
				stepList.ToList().ForEach(s => signature += s.ToString());

				var modeName = Definitions.NamedHeptatonicModes.ContainsKey(signature) ?
					Definitions.NamedHeptatonicModes[signature] : signature;

				var mode = new HeptatonicMode(signature);
				
				results.Add(modeName, mode);
			}

			return results;
		}
	}
}
