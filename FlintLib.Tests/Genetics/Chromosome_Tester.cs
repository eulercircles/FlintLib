using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using FlintLib.Genetics;
using System.Collections.Generic;

namespace FlintLib.Tests.Genetics
{
	[TestClass]
	public class Chromosome_Tester
	{
		[TestMethod]
		public void TestChromosome()
		{
			var chromosome = Chromosome.GenerateNew(1024);

			var values = chromosome.DecodeTraits();

			List<Gamete> gametes = new List<Gamete>();
			for (int i = 0; i < 1024; i++)
			{
				gametes.AddRange(chromosome.Meiosis());
			}

			var count = gametes.Count;
		}
	}
}
