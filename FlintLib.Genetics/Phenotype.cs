using System;
using System.Linq;
using System.Collections.Generic;

namespace FLib.Genetics
{
	/// <summary>
	/// Describes the mapping between Alleles and their expressed attributes.
	/// This will also handle expression mutation - values that are changed from their encoded value only in expression.
	/// The original, not the acquired, value will be retained and passed on.
	/// </summary>
	public class Phenotype : Dictionary<string, byte>
	{

		public Phenotype(int genotypeLength) : base(genotypeLength)
		{

		}
	}
}
