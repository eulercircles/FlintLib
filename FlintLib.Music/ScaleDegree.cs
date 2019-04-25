using System.Collections.Generic;

namespace FLib.Music
{
	public class ScaleDegree
	{
		public IReadOnlyList<ChordTypes> Chords { get; }
		internal string Signature { get; }

		private readonly uint _signature;

		public ScaleDegree(string signature)
		{
			Signature = signature;
			var binarySignature = Convert.StepStringToBinaryString(signature);
			var bitArray = Convert.BinaryStringToBitArray(binarySignature);
			_signature = bitArray.ToUInt16();

			Chords = GetChords();
		}

		private IReadOnlyList<ChordTypes> GetChords()
		{
			var result = new List<ChordTypes>();

			foreach (var chord in ChordUtilities.ChordValues)
			{
				var chordSignature = (uint)chord.Value;
				if ((_signature & chordSignature) == chordSignature)
				{
					result.Add(chord.Value);
				}
			}

			return result;
		}
	}
}
