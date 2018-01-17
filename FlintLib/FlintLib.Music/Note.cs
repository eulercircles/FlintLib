using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlintLib.Music
{
	public class Note
	{
		private static readonly string flatSymbol = char.ConvertFromUtf32(utf32: 9837);
		private static readonly string sharpSymbol = char.ConvertFromUtf32(utf32: 9839);

		private readonly Notes _noteName;
		private readonly Accidentals _accidental;
		private readonly string _symbol;

		public Notes NoteName { get { return _noteName; } }
		public Accidentals Accidental { get { return _accidental; } }

		public int ChromaticValue { get { return ((int)_noteName + (int)_accidental); } }

		public Note(Notes noteName, Accidentals accidental)
		{
			_noteName = noteName;
			_accidental = accidental;

			var chromaticValue = ChromaticValue;
			switch (chromaticValue)
			{
				case 0:
					_noteName = Notes.B;
					_accidental = Accidentals.Natural;
					break;
				case 5:
					_noteName = Notes.E;
					_accidental = Accidentals.Natural;
					break;
				case 6:
					_noteName = Notes.F;
					_accidental = Accidentals.Natural;
					break;
				case 13:
					_noteName = Notes.C;
					_accidental = Accidentals.Natural;
					break;
				default: break;
			}

			switch (_accidental)
			{
				case Accidentals.Flat:
					_symbol = flatSymbol;
					break;
				case Accidentals.Sharp:
					_symbol = sharpSymbol;
					break;
			}
		}

		public override string ToString()
		{
			return $"{_noteName}{_symbol}";
		}
	}
}
