using System;
using System.Linq;

namespace FLib.Music
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

		public HeptatonicScale Ionian => Heptatonic(Definitions.NamedHeptatonicModes.Where(kvp => kvp.Value == nameof(Ionian)).FirstOrDefault().Key);
		public HeptatonicScale Dorian => Heptatonic(Definitions.NamedHeptatonicModes.Where(kvp => kvp.Value == nameof(Dorian)).FirstOrDefault().Key);
		public HeptatonicScale Phrygian => Heptatonic(Definitions.NamedHeptatonicModes.Where(kvp => kvp.Value == nameof(Phrygian)).FirstOrDefault().Key);
		public HeptatonicScale Lydian => Heptatonic(Definitions.NamedHeptatonicModes.Where(kvp => kvp.Value == nameof(Lydian)).FirstOrDefault().Key);
		public HeptatonicScale Mixolydian => Heptatonic(Definitions.NamedHeptatonicModes.Where(kvp => kvp.Value == nameof(Mixolydian)).FirstOrDefault().Key);
		public HeptatonicScale Aeolian => Heptatonic(Definitions.NamedHeptatonicModes.Where(kvp => kvp.Value == nameof(Aeolian)).FirstOrDefault().Key);
		public HeptatonicScale Locrian => Heptatonic(Definitions.NamedHeptatonicModes.Where(kvp => kvp.Value == nameof(Locrian)).FirstOrDefault().Key);

		public HeptatonicScale Heptatonic(string signature)
		{
			return new HeptatonicScale(_root, signature);
		}
	}
}
