using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FLib.Music;

namespace FLib.Tests.Music
{
	[TestClass]
	public class ModeChords_Tester
	{
		[TestMethod]
		public void TestCheckChord()
		{
			var stringBuilder = new StringBuilder();

			var modes = ModeGenerator.GenerateAllHeptatonics();

			var text = GetCSV(modes.Values.ToList());

			File.WriteAllText(@"C:\users\Ronal\Desktop\chords.csv", text, Encoding.UTF8);
		}

		[TestMethod]
		public void TestHeptatonicMode()
		{
			var scale = ScaleBuilder.C.Ionian;
			var chords = scale.GetDelimitedChords();
			File.WriteAllText(@"C:\users\Ronal\Desktop\C_Ionian.csv", chords, Encoding.UTF8);
		}

		private string GetCSV(IReadOnlyList<HeptatonicMode> modes)
		{
			var csvBuilder = new StringBuilder();
			csvBuilder.AppendLine(",1,2,3,4,5,6,7");

			foreach (var mode in modes)
			{
				var name = !string.IsNullOrWhiteSpace(mode.Name) ? $"{mode.Name} ({mode.Signature})" : mode.Signature;
				var groupList = new List<string>
				{
					GetChordGroup(mode.TonicChords),
					GetChordGroup(mode.SupertonicChords),
					GetChordGroup(mode.MediantChords),
					GetChordGroup(mode.SubdominantChords),
					GetChordGroup(mode.DominantChords),
					GetChordGroup(mode.SubmediantChords),
					GetChordGroup(mode.SubtonicChords)
				};

				var line = $"{name},{string.Join(",", groupList)}";

				csvBuilder.AppendLine(line);
			}

			return csvBuilder.ToString();
		}

		private string GetChordGroup(IReadOnlyList<ChordTypes> chords)
		{
			var chordNames = new List<string>();
			chords.ToList().ForEach(chord => { chordNames.Add(chord.DefaultSymbol()); });
			return $"{string.Join(" | ", chordNames)}";
		}
	}
}
