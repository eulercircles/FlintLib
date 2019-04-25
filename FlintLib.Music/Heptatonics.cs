using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace FlintLib.Music
{
	public class HeptatonicMode
	{
		public string Signature => _degrees[0].Signature;
		public string Name => Definitions.NamedHeptatonicModes.ContainsKey(Signature) ? Definitions.NamedHeptatonicModes[Signature] : Signature;

		private readonly ScaleDegree[] _degrees = new ScaleDegree[7];

		public virtual IReadOnlyList<ChordTypes> TonicChords => _degrees[0].Chords;
		public virtual IReadOnlyList<ChordTypes> SupertonicChords => _degrees[1].Chords;
		public virtual IReadOnlyList<ChordTypes> MediantChords => _degrees[2].Chords;
		public virtual IReadOnlyList<ChordTypes> SubdominantChords => _degrees[3].Chords;
		public virtual IReadOnlyList<ChordTypes> DominantChords => _degrees[4].Chords;
		public virtual IReadOnlyList<ChordTypes> SubmediantChords => _degrees[5].Chords;
		public virtual IReadOnlyList<ChordTypes> SubtonicChords => _degrees[6].Chords;

		internal HeptatonicMode(string stepSignature)
		{
			if (stepSignature.Length != 7) { throw new ArgumentOutOfRangeException(nameof(stepSignature)); }

			var signature = stepSignature;
			for (int i = 0; i < _degrees.Length; i++)
			{
				_degrees[i] = new ScaleDegree(signature);
				signature = signature.RotateLeft();
			}
		}
	}

	public class HeptatonicScale : HeptatonicMode
	{
		private readonly Note _root;

		public Note Tonic { get; }
		public Note Supertonic { get; }
		public Note Mediant { get; }
		public Note Subdominant { get; }
		public Note Dominant { get; }
		public Note Submediant { get; }
		public Note Subtonic { get; }

		internal HeptatonicScale(Note root, string signature) : base(signature)
		{
			_root = root;
		}

		public string GetDelimitedChords()
		{
			var stringBuilder = new StringBuilder();

			return stringBuilder.ToString();
		}

		private string GetDelimitedChordList(IReadOnlyList<ChordTypes> chords)
		{
			var symbols = new List<string>();
			chords.ToList().ForEach(chord => { symbols.Add(chord.DefaultSymbol()); });
			return string.Join(",", symbols);
		}

		private IReadOnlyList<Note> GetNotesOfScale()
		{
			var result = new List<Note>();

			return result;
		}
	}
}
