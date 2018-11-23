using System;
using System.Collections;

namespace FlintLib.Music
{
	public static class Extensions
	{
		public static uint ToUInt32(this BitArray bitArray)
		{
			if (bitArray.Length > 32) { throw new ArgumentOutOfRangeException(nameof(bitArray)); }

			uint result = 0;
			for (int i = 0; i < bitArray.Length; i++)
			{
				if (bitArray[i]) { result |= (uint)(1 << i); }
			}
			return result;
		}

		public static uint ReverseBits(this uint value)
		{
			uint result = 0;
			for (int i = 0; i < 32; ++i)
			{
				result <<= 1;
				result |= (value & 1);
				value >>= 1;
			}
			return result;
		}

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
				//case ChordTypes.SeventhFlat9th,
				//case ChordTypes.SeventhSharp9th,
				//case ChordTypes.Major9th,
				//case ChordTypes.Ninth,
				//case ChordTypes.Minor9th,
				//case ChordTypes.Minor9thMajor7th,
				//case ChordTypes.EleventhNo3rd,
				//case ChordTypes.Major7thAdd11th,
				//case ChordTypes.SeventhAdd11th,
				//case ChordTypes.Minor7thAdd11th,
				//case ChordTypes.Major7thAdd13th,
				//case ChordTypes.SeventhAdd13th,
				//case ChordTypes.Minor7thAdd13th,
				case ChordTypes.Major11th: return "Maj11";
				//case ChordTypes.Eleventh,
				//case ChordTypes.Minor11th,
				//case ChordTypes.Major13th,
				//case ChordTypes.Thirteenth,
				//case ChordTypes.Minor13th
				default: throw new Exception();
			}
		}

		public static string ShortSymbol(this ChordTypes value)
		{
			switch (value)
			{
				case ChordTypes.Major: return string.Empty;
				case ChordTypes.Minor: return "m";
				case ChordTypes.Augmented: return "+";
				case ChordTypes.Major7th: return "M7";
				case ChordTypes.Minor7th: return "m7";
				default: return value.DefaultSymbol();
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
