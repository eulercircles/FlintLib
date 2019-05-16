using System;

namespace FLib.Music
{
	public struct Chord
	{
		public Note Root { get; }
		public ChordTypes Type { get; }
		public string DefaultName => $"{Root.Name} {Type.DefaultSymbol()}";
		public string ShortName => $"{Root.Name}{Type.ShortSymbol()}";
		internal Chord(Note root, ChordTypes type)
		{
			Root = root;
			Type = type;
		}
	}
}
