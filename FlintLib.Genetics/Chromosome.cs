using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Genetics
{
	public class Chromosome : IComparable<Chromosome>
	{
		private const string _separator = ".";

		private List<string> _parent1Pairs;
		private List<string> _parent2Pairs;

		private string _p1Sequence;
		public string P1
		{
			get
			{
				if (_p1Sequence == null || _p1Sequence == string.Empty)
				{
					_p1Sequence = WriteSequence(_parent1Pairs);
				}

				return _p1Sequence;
			}
		}

		private string _p2Sequence;
		public string P2
		{
			get
			{
				if (_p2Sequence == null || _p2Sequence == string.Empty)
				{
					_p2Sequence = WriteSequence(_parent2Pairs);
				}

				return _p2Sequence;
			}
		}

		public Chromosome(List<string> parent1Sequence, List<string> parent2Sequence)
		{
			_parent1Pairs = parent1Sequence;
			_parent2Pairs = parent2Sequence;
		}

		#region IComparable Implementation
		public int CompareTo(Chromosome other)
		{
			throw new NotImplementedException();
		}
		#endregion IComparable Implementation

		#region Public Methods
		/// <summary>
		/// Recombination and, perhaps, mutations occur here. Recombinations and mutations are randomized
		/// each time this method is called.
		/// </summary>
		/// <returns></returns>
		public Gamete[] Meiosis()
		{
			/*
			 * What kinds of things can happen here?
			 *  - Swap dominant/recessive
			 *  - Change values if both are dominant or both are recessive
			 *  - Change one or both values if both are either incomplete or codominant
			 *  - 
			 *  
			 *  To cope with errors that can be made here, probability of mutation here should be fairly low
			 *  and probability of fixing the mutation should be fairly high.
			 */
			
			var result = new Gamete[4];

			var gamete1 = new List<string>();
			var gamete2 = new List<string>();
			var gamete3 = new List<string>();
			var gamete4 = new List<string>();

			// Split every group of 3 into 2 segments from each parent (total of 4 segments).
			// Use combinatorics to decide which of the 4 new segments gets the information from which split segment.

			// For now, this takes care of the splitting, but does not yet recombine or mutate.
			for (int i = 0; i < _parent1Pairs.Count; i += 3)
			{
				gamete1.Add(_parent1Pairs[i][0].ToString());
				gamete1.Add(_parent1Pairs[i + 1][0].ToString());
				gamete1.Add(_parent1Pairs[i + 2][0].ToString());

				gamete2.Add(_parent1Pairs[i][1].ToString());
				gamete2.Add(_parent1Pairs[i + 1][1].ToString());
				gamete2.Add(_parent1Pairs[i + 2][1].ToString());

				gamete3.Add(_parent2Pairs[i][0].ToString());
				gamete3.Add(_parent2Pairs[i + 1][0].ToString());
				gamete3.Add(_parent2Pairs[i + 2][0].ToString());

				gamete4.Add(_parent2Pairs[i][1].ToString());
				gamete4.Add(_parent2Pairs[i + 1][1].ToString());
				gamete4.Add(_parent2Pairs[i + 2][1].ToString());
			}

			result[0] = new Gamete(gamete1);
			result[1] = new Gamete(gamete2);
			result[2] = new Gamete(gamete3);
			result[3] = new Gamete(gamete4);

			return result;
		}

		public Chromosome[] Combine(Gamete[] externalGametes)
		{
			// This "Chromosome" needs some of its own gametes in order to attempt to combine with the gametes that are passed in.
			// An interesting idea is to have organism generate gametes periodically - as a pool of available gametes.
			// The rate at which these are generated, max capacity, etc... can also be encoded values.

			var internalGametes = Meiosis();

			var results = new Chromosome[4];

			for (int i = 0; i < externalGametes.Length; i++)
			{
				var p1Sequence = ComplementStrand(internalGametes[i].Sequence);
				var p2Sequence = ComplementStrand(externalGametes[i].Sequence);

				results[i] = new Chromosome(p1Sequence, p2Sequence);
			}

			return results;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="length">Number of codons - encoded values - in the chromosome.</param>
		/// <returns></returns>
		public static Chromosome GenerateNew(int length)
		{
			var result = new Chromosome(new List<string>(), new List<string>());
			var random = new Random((int)DateTime.Now.Ticks);

			for (int i = 0; i < length; i++)
			{
				var e1 = ((random.Next(0, 3) + 1) * 3);
				var e2 = 0;

				switch (e1)
				{
					case 3: // Recessive
						{
							var other = random.Next(0, 1);
							if (other == 0) { e2 = 3; }
							else { e2 = 12; }
						}
						break;
					case 6: // Incomplete
						e2 = 6;
						break;
					case 9: // Codominant
						e2 = 9;
						break;
					case 12: // Dominant
						{
							var other = random.Next(0, 1);
							if (other == 0) { e2 = 3; }
							else { e2 = 12; }
						}
						break;
				}

				var expression1 = (Expressions)e1;
				var expression2 = (Expressions)e2;

				switch (expression1)
				{
					case Expressions.Recessive:
						if (expression2 == Expressions.Recessive)
						{
							var v1 = ((Pairs)random.Next(0, 3)).ToString();
							var v2 = ((Pairs)random.Next(0, 3)).ToString();

							result._parent1Pairs.Add(v1);
							result._parent1Pairs.Add(v2);
							result._parent2Pairs.Add(v1);
							result._parent2Pairs.Add(v2);
						}
						else if (expression2 == Expressions.Dominant)
						{
							var p1_v1 = ((Pairs)random.Next(0, 3)).ToString();
							var p1_v2 = ((Pairs)random.Next(0, 3)).ToString();
							var p2_v1 = ((Pairs)random.Next(0, 3)).ToString();
							var p2_v2 = ((Pairs)random.Next(0, 3)).ToString();

							result._parent1Pairs.Add(p1_v1);
							result._parent1Pairs.Add(p1_v2);
							result._parent1Pairs.Add(p2_v1);
							result._parent1Pairs.Add(p2_v2);
						}
						break;
					case Expressions.Incomplete:
						{
							result._parent1Pairs.Add(((Pairs)random.Next(0, 3)).ToString());
							result._parent1Pairs.Add(((Pairs)random.Next(0, 3)).ToString());
							result._parent2Pairs.Add(((Pairs)random.Next(0, 3)).ToString());
							result._parent2Pairs.Add(((Pairs)random.Next(0, 3)).ToString());
						}
						break;
					case Expressions.Codominant:
						{
							result._parent1Pairs.Add(((Pairs)random.Next(0, 3)).ToString());
							result._parent1Pairs.Add(((Pairs)random.Next(0, 3)).ToString());
							result._parent2Pairs.Add(((Pairs)random.Next(0, 3)).ToString());
							result._parent2Pairs.Add(((Pairs)random.Next(0, 3)).ToString());
						}
						break;
					case Expressions.Dominant:
						if (expression2 == Expressions.Dominant)
						{
							var v1 = ((Pairs)random.Next(0, 3)).ToString();
							var v2 = ((Pairs)random.Next(0, 3)).ToString();

							result._parent1Pairs.Add(v1);
							result._parent1Pairs.Add(v2);
							result._parent2Pairs.Add(v1);
							result._parent2Pairs.Add(v2);
						}
						else if (expression2 == Expressions.Recessive)
						{
							var p1_v1 = ((Pairs)random.Next(0, 3)).ToString();
							var p1_v2 = ((Pairs)random.Next(0, 3)).ToString();
							var p2_v1 = ((Pairs)random.Next(0, 3)).ToString();
							var p2_v2 = ((Pairs)random.Next(0, 3)).ToString();

							result._parent1Pairs.Add(p1_v1);
							result._parent1Pairs.Add(p1_v2);
							result._parent1Pairs.Add(p2_v1);
							result._parent1Pairs.Add(p2_v2);
						}
						break;
				}

				result._parent1Pairs.Add(expression1.ToPair().ToString());
				result._parent2Pairs.Add(expression2.ToPair().ToString());
			}

			return result;
		}

		public Chromosome GenerateRelated()
		{
			var gametes = Meiosis();

			var random = new Random((int)DateTime.Now.Ticks);
			var index = random.Next(0,3);

			var combined = Combine(gametes);

			return combined[index];
		}

		public List<byte> DecodeTraits()
		{
			var results = new List<byte>();
			for (int i = 0; i < _parent1Pairs.Count; i += 3)
			{
				var allele1 = new Allele(_parent1Pairs[i].ToPair(), _parent1Pairs[i + 1].ToPair(), _parent1Pairs[i + 2].ToPair());
				var allele2 = new Allele(_parent2Pairs[i].ToPair(), _parent2Pairs[i + 1].ToPair(), _parent2Pairs[i + 2].ToPair());

				results.Add(DecodeTrait(allele1, allele2));
			}
			return results;
		}
		#endregion Public Methods

		#region Private Methods
		private string WriteSequence(List<string> pairs)
		{
			var result = string.Empty;
			for (int i = 0; i < pairs.Count; i += 3)
			{
				result += $"{pairs[i]}{pairs[i + 1]}{pairs[i + 2]}{_separator}";
			}
			return result;
		}
		
		private byte DecodeTrait(Allele p1, Allele p2)
		{
			byte result = 0;

			switch (p1.Expression)
			{
				case Expressions.Recessive:
					if (p2.Expression != Expressions.Dominant && p2.Expression != Expressions.Recessive)
					{ throw new Exception($"Parent 2 expression must be either dominant or recessive (p1: {p1.Value} {p1.Expression} p2: {p2.Value} {p2.Expression})"); }
					if (p2.Expression == Expressions.Recessive && !(p1.Value == p2.Value))
					{ throw new Exception($"If Parent 2 expression is also recessive, p1 and p2 must have the same value. (p1: {p1.Value} {p1.Expression} p2: {p2.Value} {p2.Expression})"); }
					result = p2.Expression == Expressions.Recessive ? p1.Value : p2.Value;
					break;
				case Expressions.Incomplete:
					if (p2.Expression != Expressions.Incomplete)
					{ throw new Exception($"Parent 2 expression must match. (p1: {p1.Value} {p1.Expression} p2: {p2.Value} {p2.Expression})"); }
					result = (byte)(p1.Value & p2.Value);
					break;
				case Expressions.Codominant:
					if (p2.Expression != Expressions.Codominant)
					{ throw new Exception($"Parent 2 expression must match. (p1: {p1.Value} {p1.Expression} p2: {p2.Value} {p2.Expression})"); }
					result = (byte)(p1.Value | p2.Value);
					break;
				case Expressions.Dominant:
					if (p2.Expression != Expressions.Dominant && p2.Expression != Expressions.Recessive)
					{ throw new Exception($"Parent 2 expression must be either dominant or recessive (p1: {p1.Value} {p1.Expression} p2: {p2.Value} {p2.Expression})"); }
					if (p2.Expression == Expressions.Dominant && !(p1.Value == p2.Value))
					{ throw new Exception($"If Parent 2 expression is also dominant, p1 and p2 must have the same value. (p1: {p1.Value} {p1.Expression} p2: {p2.Value} {p2.Expression})"); }
					result = p1.Value;
					break;
			}

			return result;
		}
		
		private List<string> ComplementStrand(IReadOnlyList<string> gamete)
		{
			var results = new List<string>();
			foreach (var nucleotide in gamete)
			{
				switch (nucleotide)
				{
					case "A":
						results.Add(Pairs.AG.ToString());
						break;
					case "T":
						results.Add(Pairs.TC.ToString());
						break;
					case "C":
						results.Add(Pairs.CT.ToString());
						break;
					case "G":
						results.Add(Pairs.GA.ToString());
						break;
				}
			}
			return results;
		}
		#endregion Private Methods
	}
}
