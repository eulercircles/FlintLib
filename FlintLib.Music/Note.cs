using System;
using System.Linq;
using FLib.Common;

using static FLib.Music.Symbols;

namespace FLib.Music
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
