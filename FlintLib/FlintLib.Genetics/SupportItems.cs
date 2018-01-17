using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Combinatorics;
using Combinatorics.Collections;

namespace FlintLib.Genetics
{
	public enum Expressions
	{
		Recessive = 3,
		Incomplete = 6,
		Codominant = 9,
		Dominant = 12
	}

	public enum Pairs
	{
		AG,
		GA,
		CT,
		TC
	}

	public static class Definitions
	{
		// "Nucleotides"
		// P and Y pair together, Q and T pair together.
		private static readonly Dictionary<string, bool[]> _nucleotides = new Dictionary<string, bool[]>()
		{
			{ "A", new bool[2]{ false, false } },
			{ "C", new bool[2] { false, true } },
			{ "T", new bool[2] { true, false } },
			{ "G", new bool[2] { true, true } }
		};

		public static readonly IReadOnlyDictionary<string, bool[]> Nucleotides = new ReadOnlyDictionary<string, bool[]>(_nucleotides);
	}
		
	public static class Extensions
	{
		public static Pairs ToPair(this Expressions value)
		{
			Pairs result = Pairs.AG;

			switch (value)
			{
				case Expressions.Recessive: result = Pairs.AG; break;
				case Expressions.Incomplete: result = Pairs.CT; break;
				case Expressions.Codominant: result = Pairs.TC; break;
				case Expressions.Dominant: result = Pairs.GA; break;
			}

			return result;
		}

		public static Pairs ToPair(this string value)
		{
			switch (value)
			{
				case "AG":
					return Pairs.AG;
				case "GA":
					return Pairs.GA;
				case "CT":
					return Pairs.CT;
				case "TC":
					return Pairs.TC;
				default:
					throw new ArgumentOutOfRangeException(nameof(value), $"{value} is not a valid pair descriptor");
			}
		}
	}
}
