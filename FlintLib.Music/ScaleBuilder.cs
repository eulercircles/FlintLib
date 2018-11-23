using System;
using System.Linq;

namespace FlintLib.Music
{
	public class ScaleBuilder
	{
		private readonly Note _root;

		public static ScaleBuilder A => new ScaleBuilder(new Note(NoteLetters.A));
		public static ScaleBuilder B => new ScaleBuilder(new Note(NoteLetters.B));
		public static ScaleBuilder C => new ScaleBuilder(new Note(NoteLetters.C));
		public static ScaleBuilder D => new ScaleBuilder(new Note(NoteLetters.D));
		public static ScaleBuilder E => new ScaleBuilder(new Note(NoteLetters.E));
		public static ScaleBuilder F => new ScaleBuilder(new Note(NoteLetters.F));
		public static ScaleBuilder G => new ScaleBuilder(new Note(NoteLetters.G));

		private ScaleBuilder(Note root) { _root = root; }

		public ScaleBuilder Flat { get { _root.Accidental = Accidentals.Flat; return this; } }
		public ScaleBuilder Sharp { get { _root.Accidental = Accidentals.Sharp; return this; } }

		public HeptatonicScale Heptatonic(string signature, string name = "")
		{
			return new HeptatonicScale(_root, new HeptatonicMode(signature, name));
		}
	}
}
