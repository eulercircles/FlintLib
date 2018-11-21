using System;
using System.Collections.Generic;

namespace FlintLib.Music
{
	public class HeptatonicMode
	{
		public string Name { get; private set; }
		public string Signature { get; private set; }

		public IReadOnlyDictionary<uint, string> Degree1LegalChords { get; private set; }
		public IReadOnlyDictionary<uint, string> Degree2LegalChords { get; private set; }
		public IReadOnlyDictionary<uint, string> Degree3LegalChords { get; private set; }
		public IReadOnlyDictionary<uint, string> Degree4LegalChords { get; private set; }
		public IReadOnlyDictionary<uint, string> Degree5LegalChords { get; private set; }
		public IReadOnlyDictionary<uint, string> Degree6LegalChords { get; private set; }
		public IReadOnlyDictionary<uint, string> Degree7LegalChords { get; private set; }

		public HeptatonicMode(string stepSignature, string name = "")
		{
			if (stepSignature.Length != 7) { throw new ArgumentException("", nameof(stepSignature)); }

			Name = name;
			Signature = stepSignature;
			var _degree2Signature = Signature.RotateLeft();
			var _degree3Signature = _degree2Signature.RotateLeft();
			var _degree4Signature = _degree3Signature.RotateLeft();
			var _degree5Signature = _degree4Signature.RotateLeft();
			var _degree6Signature = _degree5Signature.RotateLeft();
			var _degree7Signature = _degree6Signature.RotateLeft();

			Degree1LegalChords = GetDegreeChords(Signature);
			Degree2LegalChords = GetDegreeChords(_degree2Signature);
			Degree3LegalChords = GetDegreeChords(_degree3Signature);
			Degree4LegalChords = GetDegreeChords(_degree4Signature);
			Degree5LegalChords = GetDegreeChords(_degree5Signature);
			Degree6LegalChords = GetDegreeChords(_degree6Signature);
			Degree7LegalChords = GetDegreeChords(_degree7Signature);
		}

		private IReadOnlyDictionary<uint, string> GetDegreeChords(string stepSignature)
		{
			var result = new Dictionary<uint, string>();
			var signatureValue = Convert.StepStringToBitArray(stepSignature).ToUInt32();

			foreach (var chord in ChordUtilities.ChordValues)
			{
				if ((signatureValue & chord.Key) == chord.Key) { result.Add(chord.Key, chord.Value); }
			}

			return result;
		}
	}

	public class HeptatonicScale
	{
		private readonly Note _root;
		private readonly HeptatonicMode _mode;
	}
}
