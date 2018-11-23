using System;

using static FlintLib.Music.Symbols;

namespace FlintLib.Music
{
	public class Note
	{
		public NoteLetters Letter { get; }
		public Accidentals Accidental { get; internal set; }

		public string Name => $"{Letter}{Accidental.Symbol()}";
		public uint Chroma => ((uint)Letter + (uint)Accidental);

		public Note(NoteLetters letter, Accidentals accidental = Accidentals.Natural)
		{
			Letter = letter;
			Accidental = accidental;
		}

		public override string ToString() => Name;
	}
}
