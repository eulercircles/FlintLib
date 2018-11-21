using System;

namespace FlintLib.Music
{
	public class Chord
	{
		public Notes Note { get; }
		public Accidentals Accidental { get; private set; } = Accidentals.Natural;
		public ChordTypes? ChordType { get; private set; }

		public static Chord A { get { return new Chord(Notes.A); } }
		public static Chord B { get { return new Chord(Notes.B); } }
		public static Chord C { get { return new Chord(Notes.C); } }
		public static Chord D { get { return new Chord(Notes.D); } }
		public static Chord E { get { return new Chord(Notes.E); } }
		public static Chord F { get { return new Chord(Notes.F); } }
		public static Chord G { get { return new Chord(Notes.G); } }
		
		public Chord Flat { get { Accidental = Accidentals.Flat; return this; } }
		public Chord Sharp { get { Accidental = Accidentals.Sharp; return this; } }

		public Chord Fifth { get { ChordType = ChordTypes.Fifth; return this; } }
		public Chord Major { get { ChordType = ChordTypes.Major; return this; } }
		public Chord Minor { get { ChordType = ChordTypes.Minor; return this; } }
		public Chord Augmented { get { ChordType = ChordTypes.Augmented; return this; } }
		public Chord Diminished { get { ChordType = ChordTypes.Diminished; return this; } }
		public Chord Suspended2nd { get { ChordType = ChordTypes.Suspended2nd; return this; } }
		public Chord Suspended4th { get { ChordType = ChordTypes.Suspended4th; return this; } }
		public Chord Major7th { get { ChordType = ChordTypes.Major7th; return this; } }
		public Chord Dominant7th { get { ChordType = ChordTypes.Dominant7th; return this; } }
		public Chord Minor7th { get { ChordType = ChordTypes.Minor7th; return this; } }
		public Chord MinorMajor7th { get { ChordType = ChordTypes.MinorMajor7th; return this; } }
		public Chord Major7thFlat5th { get { ChordType = ChordTypes.Major7thFlat5th; return this; } }
		public Chord Major7thSharp5th { get { ChordType = ChordTypes.Major7thSharp5th; return this; } }
		public Chord SeventhFlat5th { get { ChordType = ChordTypes.SeventhFlat5th; return this; } }
		public Chord SeventhSharp5th { get { ChordType = ChordTypes.SeventhSharp5th; return this; } }
		public Chord Minor7thFlat5th { get { ChordType = ChordTypes.Minor7thFlat5th; return this; } }
		public Chord Diminished7th { get { ChordType = ChordTypes.Diminished7th; return this; } }
		public Chord SeventhSuspened4th { get { ChordType = ChordTypes.SeventhSuspened4th; return this; } }
		public Chord Major6th { get { ChordType = ChordTypes.Major6th; return this; } }
		public Chord Minor6th { get { ChordType = ChordTypes.Minor6th; return this; } }

		private Chord(Notes note, Accidentals accidental = Accidentals.Natural, ChordTypes? chordType = null)
		{
			Note = note;
			Accidental = accidental;
			ChordType = chordType;
		}

		private Chord(Notes note, ChordTypes chordType)
		{
			Note = note;
			ChordType = chordType;
		}

		public string Symbol() => ToString();

		public override string ToString() => $"{Note}{Accidental.Symbol()}{ChordType?.Symbol()}";
	}
}
