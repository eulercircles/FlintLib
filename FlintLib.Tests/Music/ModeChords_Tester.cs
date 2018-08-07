using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Music;

namespace FlintLib.Tests.Intelligence
{
	[TestClass]
	public class ModeChords_Tester
	{
		[TestMethod]
		public void TestCheckChord()
		{
			var modes = ModeGenerator.GenerateHeptatonics();

			var csv = new List<string>
			{
				",1,2,3,4,5,6,7,"
			};

			foreach (var mode in modes) { csv.Add(GetCSV(mode.Value)); }

			File.WriteAllLines(@"C:\users\Ronal\Desktop\chords.csv", csv.ToArray());
		}

		private string GetCSV(HeptatonicMode mode)
		{
			var csvBuilder = new StringBuilder();

			var comma = ",";
			var pipe = " | ";

			var name = !string.IsNullOrWhiteSpace(mode.Name) ? $"{mode.Name} ({mode.Signature})" : mode.Signature;
			csvBuilder.Append(name).Append(comma);

			foreach(var c in mode.Degree1LegalChords)
			{
				csvBuilder.Append(c.Value).Append(pipe);
			}
			csvBuilder.Append(comma);

			foreach (var c in mode.Degree2LegalChords)
			{
				csvBuilder.Append(c.Value).Append(pipe);
			}
			csvBuilder.Append(comma);

			foreach (var c in mode.Degree3LegalChords)
			{
				csvBuilder.Append(c.Value).Append(pipe);
			}
			csvBuilder.Append(comma);

			foreach (var c in mode.Degree4LegalChords)
			{
				csvBuilder.Append(c.Value).Append(pipe);
			}
			csvBuilder.Append(comma);

			foreach (var c in mode.Degree5LegalChords)
			{
				csvBuilder.Append(c.Value).Append(pipe);
			}
			csvBuilder.Append(comma);

			foreach (var c in mode.Degree6LegalChords)
			{
				csvBuilder.Append(c.Value).Append(pipe);
			}
			csvBuilder.Append(comma);

			foreach (var c in mode.Degree7LegalChords)
			{
				csvBuilder.Append(c.Value).Append(pipe);
			}
			csvBuilder.Append(comma);

			return csvBuilder.ToString();
		}
	}
}
