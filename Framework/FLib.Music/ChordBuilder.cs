using System;

namespace FLib.Music
{
	public class ChordBuilder
	{
		private readonly Note _root;

		public static ChordBuilder A => new ChordBuilder(new Note(NoteLetters.A));
		public static ChordBuilder B => new ChordBuilder(new Note(NoteLetters.B));
		public static ChordBuilder C => new ChordBuilder(new Note(NoteLetters.C));
		public static ChordBuilder D => new ChordBuilder(new Note(NoteLetters.D));
		public static ChordBuilder E => new ChordBuilder(new Note(NoteLetters.E));
		public static ChordBuilder F => new ChordBuilder(new Note(NoteLetters.F));
		public static ChordBuilder G => new ChordBuilder(new Note(NoteLetters.G));

		private ChordBuilder(Note root) { _root = root; }

		public ChordBuilder Flat { get { _root.Accidental = Accidentals.Flat; return this; } }
		public ChordBuilder Sharp { get { _root.Accidental = Accidentals.Sharp; return this; } }

		public Chord Fifth => Build(ChordTypes.Fifth);
		public Chord Major => Build(ChordTypes.Major);
		public Chord Minor => Build(ChordTypes.Minor);
		public Chord Augmented => Build(ChordTypes.Augmented);
		public Chord Diminished => Build(ChordTypes.Diminished);
		public Chord Suspended2nd => Build(ChordTypes.Suspended2nd);
		public Chord Suspended4th => Build(ChordTypes.Suspended4th);
		public Chord Major7th => Build(ChordTypes.Major7th);
		public Chord Dominant7th => Build(ChordTypes.Dominant7th);
		public Chord Minor7th => Build(ChordTypes.Minor7th);
		public Chord MinorMajor7th => Build(ChordTypes.MinorMajor7th);
		public Chord Major7thFlat5th => Build(ChordTypes.Major7thFlat5th);
		public Chord Major7thSharp5th => Build(ChordTypes.Major7thSharp5th);
		public Chord SeventhFlat5th => Build(ChordTypes.SeventhFlat5th);
		public Chord SeventhSharp5th => Build(ChordTypes.SeventhSharp5th);
		public Chord Minor7thFlat5th => Build(ChordTypes.Minor7thFlat5th);
		public Chord Diminished7th => Build(ChordTypes.Diminished7th);
		public Chord SeventhSuspened4th => Build(ChordTypes.SeventhSuspened4th);
		public Chord Major6th => Build(ChordTypes.Major6th);
		public Chord Minor6th => Build(ChordTypes.Minor6th);
		public Chord Add9th => Build(ChordTypes.Add9th);
		public Chord MinorAdd9th => Build(ChordTypes.MinorAdd9th);
		public Chord Major6th9th => Build(ChordTypes.Major6th9th);
		public Chord Minor6th9th => Build(ChordTypes.Minor6th9th);

		private Chord Build(ChordTypes type) => new Chord(_root, type);
	}
}
