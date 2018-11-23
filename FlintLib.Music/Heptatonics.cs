using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FlintLib.Music
{
	public class HeptatonicMode
	{
		public string Name { get; private set; }
		public string Signature { get; private set; }

		public IReadOnlyList<ChordTypes> Degree1Chords { get; private set; }
		public IReadOnlyList<ChordTypes> Degree2Chords { get; private set; }
		public IReadOnlyList<ChordTypes> Degree3Chords { get; private set; }
		public IReadOnlyList<ChordTypes> Degree4Chords { get; private set; }
		public IReadOnlyList<ChordTypes> Degree5Chords { get; private set; }
		public IReadOnlyList<ChordTypes> Degree6Chords { get; private set; }
		public IReadOnlyList<ChordTypes> Degree7Chords { get; private set; }

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

			Degree1Chords = GetDegreeChords(Signature);
			Degree2Chords = GetDegreeChords(_degree2Signature);
			Degree3Chords = GetDegreeChords(_degree3Signature);
			Degree4Chords = GetDegreeChords(_degree4Signature);
			Degree5Chords = GetDegreeChords(_degree5Signature);
			Degree6Chords = GetDegreeChords(_degree6Signature);
			Degree7Chords = GetDegreeChords(_degree7Signature);
		}

		private IReadOnlyList<ChordTypes> GetDegreeChords(string stepSignature)
		{
			var result = new List<ChordTypes>();

			var bitArray = Convert.StepStringToBitArray(stepSignature);
			var scaleSignature = bitArray.ToUInt16();

			foreach (var chord in ChordUtilities.ChordValues)
			{
				var chordSignature = (uint)chord.Value;
				if ((scaleSignature & chordSignature) == chordSignature)
				{
					result.Add(chord.Value);
				}
			}

			return result;
		}
	}

	public class HeptatonicScale
	{
		private readonly Note _root;
		private readonly HeptatonicMode _mode;

		internal HeptatonicScale(Note root, HeptatonicMode mode)
		{
			_root = root;
			_mode = mode;
		}
	}
}
