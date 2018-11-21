using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Music;

using static FlintLib.Music.Constants;

namespace FlintLib.Tests.Music
{
	[TestClass]
	public class ModeChords_Tester
	{
		[TestMethod]
		public void TestCheckChord()
		{
			var modes = ModeGenerator.GenerateHeptatonics();

			var csv = new List<string> { ",1,2,3,4,5,6,7," };

			foreach (var mode in modes) { csv.Add(GetCSV(mode.Value)); }

			File.WriteAllLines(@"C:\users\Ronal\Desktop\chords.csv", csv.ToArray());
		}

		private string GetCSV(HeptatonicMode mode)
		{
			var csvBuilder = new StringBuilder();
			
			var name = !string.IsNullOrWhiteSpace(mode.Name) ? $"{mode.Name} ({mode.Signature})" : mode.Signature;
			csvBuilder.Append(name).Append(Comma);

			foreach(var c in mode.Degree1LegalChords)
			{
				csvBuilder.Append(c.Value).Append(Pipe);
			}
			csvBuilder.Append(Comma);

			foreach (var c in mode.Degree2LegalChords)
			{
				csvBuilder.Append(c.Value).Append(Pipe);
			}
			csvBuilder.Append(Comma);

			foreach (var c in mode.Degree3LegalChords)
			{
				csvBuilder.Append(c.Value).Append(Pipe);
			}
			csvBuilder.Append(Comma);

			foreach (var c in mode.Degree4LegalChords)
			{
				csvBuilder.Append(c.Value).Append(Pipe);
			}
			csvBuilder.Append(Comma);

			foreach (var c in mode.Degree5LegalChords)
			{
				csvBuilder.Append(c.Value).Append(Pipe);
			}
			csvBuilder.Append(Comma);

			foreach (var c in mode.Degree6LegalChords)
			{
				csvBuilder.Append(c.Value).Append(Pipe);
			}
			csvBuilder.Append(Comma);

			foreach (var c in mode.Degree7LegalChords)
			{
				csvBuilder.Append(c.Value).Append(Pipe);
			}
			csvBuilder.Append(Comma);

			return csvBuilder.ToString();
		}
	}
}
