using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLib.Genetics
{
	public class Allele
	{
		private readonly byte _value;
		private readonly Expressions _expression;

		public Expressions Expression => _expression;

		public byte Value => _value;

		public Allele(Pairs valuePair1, Pairs valuePair2, Pairs expressionPair)
		{
			_value = GetValue(valuePair1.ToString(), valuePair2.ToString());
			_expression = GetExpression(expressionPair.ToString());
		}

		private byte GetValue(string pair1, string pair2)
		{
			var p1_1 = Definitions.Nucleotides[pair1[0].ToString()];
			var p1_2 = Definitions.Nucleotides[pair1[1].ToString()];
			var p2_1 = Definitions.Nucleotides[pair2[0].ToString()];
			var p2_2 = Definitions.Nucleotides[pair2[1].ToString()];

			var b = new bool[8];

			b[0] = p1_1[0];
			b[1] = p1_1[1];
			b[2] = p1_2[0];
			b[3] = p1_2[1];
			b[4] = p2_1[0];
			b[5] = p2_1[1];
			b[6] = p2_2[0];
			b[7] = p2_2[1];

			byte result = 0;

			foreach (var value in b)
			{
				result <<= 1;
				if (value) { result |= 1; }
			}

			return result;
		}

		private Expressions GetExpression(string expressionPair)
		{
			var p1 = Definitions.Nucleotides[expressionPair[0].ToString()];
			var p2 = Definitions.Nucleotides[expressionPair[1].ToString()];

			var b = new bool[8];

			b[0] = false;
			b[1] = false;
			b[2] = false;
			b[3] = false;
			b[4] = p1[0];
			b[5] = p1[1];
			b[6] = p2[0];
			b[7] = p2[1];

			byte result = 0;

			foreach (var value in b)
			{
				result <<= 1;
				if (value) { result |= 1; }
			}

			return (Expressions)result;
		}
	}
}
