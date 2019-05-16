using System;
using System.Collections;

namespace FLib.Music
{
	public static class Extensions
	{
		public static string Symbol(this Accidentals value)
		{
			switch (value)
			{
				case Accidentals.Flat: return Symbols.Flat.ToString();
				case Accidentals.Natural: return string.Empty;
				case Accidentals.Sharp: return Symbols.Sharp.ToString();
				default: throw new Exception();
			}
		}

		public static string DefaultSymbol(this ChordTypes value)
		{
			switch (value)
			{
				case ChordTypes.Fifth: return "5";
				case ChordTypes.Major: return "Maj";
				case ChordTypes.Minor: return "min";
				case ChordTypes.Augmented: return "aug";
				case ChordTypes.Diminished: return $"dim";
				case ChordTypes.Suspended2nd: return "sus2";
				case ChordTypes.Suspended4th: return "sus4";
				case ChordTypes.Major7th: return "Maj7";
				case ChordTypes.Dominant7th: return "7";
				case ChordTypes.Minor7th: return "min7";
				case ChordTypes.MinorMajor7th: return "min/Maj7";
				case ChordTypes.Major7thFlat5th: return $"Maj7{Symbols.Flat}5";
				case ChordTypes.Major7thSharp5th: return $"Maj7{Symbols.Sharp}5";
				case ChordTypes.SeventhFlat5th: return $"7{Symbols.Flat}5";
				case ChordTypes.SeventhSharp5th: return $"7{Symbols.Sharp}5";
				case ChordTypes.Minor7thFlat5th: return $"min7{Symbols.Flat}5";
				case ChordTypes.Diminished7th: return $"dim7";
				case ChordTypes.SeventhSuspened4th: return "7sus4";
				case ChordTypes.Major6th: return "Maj6";
				case ChordTypes.Minor6th: return "min6";
				case ChordTypes.Add9th: return "add9";
				case ChordTypes.MinorAdd9th: return "min/add9";
				case ChordTypes.Major6th9th: return "Maj6/9";
				case ChordTypes.Minor6th9th: return "min6/9";
				case ChordTypes.SeventhFlat9th: return $"7{Symbols.Flat}9";
				case ChordTypes.SeventhSharp9th: return $"7{Symbols.Sharp}9";
				case ChordTypes.Major9th: return "Maj9";
				case ChordTypes.Ninth: return "9";
				case ChordTypes.Minor9th: return "min9";
				case ChordTypes.Minor9thMajor7th: return "min9Maj7";
				case ChordTypes.Major7thAdd11th: return "Maj7add11";
				case ChordTypes.SeventhAdd11th: return "7add11";
				case ChordTypes.Minor7thAdd11th: return "min7add11";
				case ChordTypes.Major7thAdd13th: return "Maj7add13";
				case ChordTypes.SeventhAdd13th: return "7add13";
				case ChordTypes.Minor7thAdd13th: return "min7add13";
				case ChordTypes.Major11th: return "Maj11";
				case ChordTypes.Eleventh: return "11";
				case ChordTypes.Minor11th: return "min11";
				case ChordTypes.Major13th: return "Maj13";
				case ChordTypes.Thirteenth: return "13";
				case ChordTypes.Minor13th: return "min13";
				default: throw new Exception();
			}
		}

		public static string ShortSymbol(this ChordTypes value)
		{
			switch (value)
			{
				case ChordTypes.Fifth: return "5";
				case ChordTypes.Major: return "M";
				case ChordTypes.Minor: return "m";
				case ChordTypes.Augmented: return "+";
				case ChordTypes.Diminished: return Symbols.Diminished.ToString();
				case ChordTypes.Suspended2nd: return "~2";
				case ChordTypes.Suspended4th: return "~4";
				case ChordTypes.Major7th: return "M7";
				case ChordTypes.Dominant7th: return "7";
				case ChordTypes.Minor7th: return "m7";
				case ChordTypes.MinorMajor7th: return "mM7";
				case ChordTypes.Major7thFlat5th: return $"M7{Symbols.Flat}5";
				case ChordTypes.Major7thSharp5th: return $"M7{Symbols.Sharp}5";
				case ChordTypes.SeventhFlat5th: return $"7{Symbols.Flat}5";
				case ChordTypes.SeventhSharp5th: return $"7{Symbols.Sharp}5";
				case ChordTypes.Minor7thFlat5th: return $"m7{Symbols.Flat}5";
				case ChordTypes.Diminished7th: return $"{Symbols.Diminished}7";
				case ChordTypes.SeventhSuspened4th: return "7~4";
				case ChordTypes.Major6th: return "M6";
				case ChordTypes.Minor6th: return "m6";
				case ChordTypes.Add9th: return "^9";
				case ChordTypes.MinorAdd9th: return "m^9";
				case ChordTypes.Major6th9th: return "M69";
				case ChordTypes.Minor6th9th: return "m69";
				case ChordTypes.SeventhFlat9th: return $"7{Symbols.Flat}9";
				case ChordTypes.SeventhSharp9th: return $"7{Symbols.Sharp}9";
				case ChordTypes.Major9th: return "M9";
				case ChordTypes.Ninth: return "9";
				case ChordTypes.Minor9th: return "m9";
				case ChordTypes.Minor9thMajor7th: return "m9M7";
				case ChordTypes.Major7thAdd11th: return "M7^11";
				case ChordTypes.SeventhAdd11th: return "7^11";
				case ChordTypes.Minor7thAdd11th: return "m7^11";
				case ChordTypes.Major7thAdd13th: return "M7^13";
				case ChordTypes.SeventhAdd13th: return "7^13";
				case ChordTypes.Minor7thAdd13th: return "m7^13";
				case ChordTypes.Major11th: return "M11";
				case ChordTypes.Eleventh: return "11";
				case ChordTypes.Minor11th: return "m11";
				case ChordTypes.Major13th: return "M13";
				case ChordTypes.Thirteenth: return "13";
				case ChordTypes.Minor13th: return "m13";
				default: throw new Exception();
			}
		}

		public static ushort ToUInt16(this BitArray bitArray)
		{
			if (bitArray.Length > 16) { throw new ArgumentOutOfRangeException(nameof(bitArray)); }

			ushort result = 0;
			for (int i = 0; i < bitArray.Length; i++)
			{
				if (bitArray[i]) { result |= (ushort)(1 << i); }
			}
			return result;
		}

		public static string RotateLeft(this string value)
		{
			var result = string.Empty;
			for (int i = 0; i < value.Length; i++)
			{
				result = (i < value.Length - 1) ? result += value[i + 1] : result += value[0];
			}
			return result;
		}
	}
}
