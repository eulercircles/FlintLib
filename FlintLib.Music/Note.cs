using System;

using static FlintLib.Music.Constants;

namespace FlintLib.Music
{
	public class Note
	{
		public Notes NoteName { get; set; }
		public Accidentals Accidental { get; set; }

		public int ChromaticValue { get { return ((int)NoteName + (int)Accidental); } }

		public Note(Notes noteName, Accidentals accidental)
		{
			NoteName = noteName;
			Accidental = accidental;

			var chromaticValue = ChromaticValue;
			switch (chromaticValue)
			{
				case 0:
					NoteName = Notes.B;
					Accidental = Accidentals.Natural;
					break;
				case 5:
					NoteName = Notes.E;
					Accidental = Accidentals.Natural;
					break;
				case 6:
					NoteName = Notes.F;
					Accidental = Accidentals.Natural;
					break;
				case 13:
					NoteName = Notes.C;
					Accidental = Accidentals.Natural;
					break;
				default: break;
			}
		}

		public override string ToString() => $"{NoteName}{Accidental.Symbol()}";
	}
}
