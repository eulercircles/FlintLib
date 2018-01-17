using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace FlintLib.Music
{
	public static class Constants
	{
		public static readonly string flatSymbol = char.ConvertFromUtf32(utf32: 9837);
		public static readonly string sharpSymbol = char.ConvertFromUtf32(utf32: 9839);
	}

	internal static class Extensions
	{
		public static UInt32 ToUInt32(this BitArray bitArray)
		{
			if (bitArray.Length > 32) { throw new ArgumentOutOfRangeException(nameof(bitArray)); }

			UInt32 result = 0;
			for (int i = 0; i < bitArray.Length; i++)
			{
				if (bitArray[i]) { result |= (UInt32)(1 << i); }
			}
			return result;
		}

		public static UInt16 ToUInt16(this BitArray bitArray)
		{
			if (bitArray.Length > 16) { throw new ArgumentOutOfRangeException(nameof(bitArray)); }

			UInt16 result = 0;
			for (int i = 0; i < bitArray.Length; i++)
			{
				if (bitArray[i]) { result |= (UInt16)(1 << i); }
			}
			return result;
		}

		public static string RotateLeft(this string value)
		{
			var result = string.Empty;
			for (int i = 0; i < value.Length; i++)
			{
				if (i < value.Length - 1)
				{
					result += value[i + 1];
				}
				else
				{
					result += value[0];
				}
			}
			return result;
		}
	}

	public enum Intervals
	{
		PerfectUnison,
		MinorSecond,
		MajorSecond,
		MinorThird,
		MajorThird,
		PerfectFourth,
		Tritone,
		PerfectFifth,
		MinorSixth,
		MajorSixth,
		MinorSeventh,
		MajorSeventh,
		PerfectOctave
	}

	public enum Notes
	{
		C = 1,
		D = 3,
		E = 5,
		F = 6,
		G = 8,
		A = 10,
		B = 12
	}

	public enum Accidentals
	{
		Flat = -1,
		Natural = 0,
		Sharp = 1
	}

	public enum Chords
	{
		[ChordDefinition("5", "100000010000", "The so-called 'power' chord.")]
		Fifth,
		[ChordDefinition("Maj", "100010010000", "Your basic major triad. Happy, or upbeat.")]
		Major,
		[ChordDefinition("m", "100100010000", "Your basic minor triad. Sad, or serious.")]
		Minor,
		[ChordDefinition("+", "100010001000", "Intriguing, but empty. Can seem dissonant.")]
		Augmented,
		[ChordDefinition("º", "100100100000", "More tense than other triads. Subdued.")]
		Diminished,
		[ChordDefinition("sus2", "101000010000")]
		Suspended2nd,
		[ChordDefinition("sus4", "100001010000")]
		Suspended4th,
		[ChordDefinition("Maj7", "100010010001", "A very peaceful sounding chord.")]
		Major7th,
		[ChordDefinition("7", "100010010010", "The dominant 7th chord. Used in blues.")]
		Dominant7th,
		[ChordDefinition("m7", "100100010010", "The 'Stranger Things' arpeggiated chord. Hints at mystery.")]
		Minor7th,
		[ChordDefinition("m/Maj7", "100100010001", "Tense, suspenseful, or mysterious.")]
		MinorMajor7th,
		[ChordDefinition("Maj7♭5", "100010100001")]
		Major7thFlat5th,
		[ChordDefinition("Maj7♯5", "100010001001")]
		Major7thSharp5th,
		[ChordDefinition("7♭5", "100010100010", "Tense")]
		SeventhFlat5th,
		[ChordDefinition("7♯5", "100010001010")]
		SeventhSharp5th,
		[ChordDefinition("m7♭5", "100100100010")]
		Minor7thFlat5th,
		[ChordDefinition("º7", "100100100100")]
		Diminished7th,
		[ChordDefinition("7sus4", "100001010010")]
		SeventhSuspened4th,
		[ChordDefinition("Maj6", "100010010100")]
		Major6th,
		[ChordDefinition("m6", "100100010100")]
		Minor6th,
		//[ChordDefinition("add9", "1010100100000000", "Outer-Spacey, thicker for soundtracks.")]
		//Add9th,
		//[ChordDefinition("mAdd9", "1011000100000000", "Thicker for soundtracks.")]
		//MinorAdd9th,
		//[ChordDefinition("Maj6/9", "1010100101000000")]
		//Major6th9th,
		//[ChordDefinition("m6/9", "1011000101000000")]
		//Minor6th9th,
		//[ChordDefinition("7♭9", "")]
		//SeventhFlat9th,
		//[ChordDefinition("7♯9", "")]
		//SeventhSharp9th,
		//[ChordDefinition("Maj9", "")]
		//Major9th,
		//[ChordDefinition("9", "")]
		//Ninth,
		//[ChordDefinition("m9", "")]
		//Minor9th,
		//[ChordDefinition("m9Maj7", "")]
		//Minor9thMajor7th,
		//[ChordDefinition("11-3", "")]
		//EleventhNo3rd,
		//[ChordDefinition("Maj7add11", "")]
		//Major7thAdd11th,
		//[ChordDefinition("7add11", "")]
		//SeventhAdd11th,
		//[ChordDefinition("m7add11", "")]
		//Minor7thAdd11th,
		//[ChordDefinition("Maj7add13", "")]
		//Major7thAdd13th,
		//[ChordDefinition("7add13", "")]
		//SeventhAdd13th,
		//[ChordDefinition("min7add13", "")]
		//Minor7thAdd13th,
		//[ChordDefinition("Maj11", "1010110100010000")]
		//Major11th,
		//[ChordDefinition("11", "")]
		//Eleventh,
		//[ChordDefinition("m11", "")]
		//Minor11th,
		//[ChordDefinition("Maj13", "")]
		//Major13th,
		//[ChordDefinition("13", "")]
		//Thirteenth,
		//[ChordDefinition("m13", "")]
		//Minor13th
	}

	internal static class Convert
	{
		public static BitArray BoolStringToBitArray(string boolString)
		{
			if (string.IsNullOrWhiteSpace(boolString))
			{ throw new ArgumentException("The string must not be null or white space.", nameof(boolString)); }

			var chars = boolString.ToUpper().ToCharArray();
			var bits = new bool[chars.Length];

			for (int i = 0; i < chars.Length; i++)
			{
				switch (chars[i])
				{
					case 'T':
						bits[i] = true;
						break;
					case 'F':
						bits[i] = false;
						break;
					default:
						throw new ArgumentException("The input string must consist of only the characters 'T' and 'F'.", nameof(boolString));
				}
			}

			var result = new BitArray(bits);

			return result;
		}

		public static BitArray BinaryStringToBitArray(string binaryString)
		{
			if (string.IsNullOrWhiteSpace(binaryString))
			{ throw new ArgumentException("The string must not be null or white space.", nameof(binaryString)); }

			var chars = binaryString.ToCharArray();
			var bits = new bool[chars.Length];

			for (int i = 0; i < chars.Length; i++)
			{
				switch (chars[i])
				{
					case '1':
						bits[i] = true;
						break;
					case '0':
						bits[i] = false;
						break;
					default:
						throw new ArgumentException("The input string must consist of only the characters '1' and '0'.", nameof(binaryString));
				}
			}

			var result = new BitArray(bits);
			return result;
		}

		public static BitArray StepStringToBitArray(string stepString)
		{
			return BinaryStringToBitArray(StepStringToBinaryString(stepString));
		}

		public static BitArray ToneStringToBitArray(string toneString)
		{
			return BinaryStringToBitArray(ToneStringToBinaryString(toneString));
		}
		
		private static string StepStringToBinaryString(string stepString)
		{
			string result = "1";
			foreach(var step in stepString.ToCharArray())
			{
				switch (step)
				{
					case '1':
						result += "1";
						break;
					case '2':
						result += "01";
						break;
					case '3':
						result += "001";
						break;
					default:
						throw new Exception();
				}
			}
			return result;
		}

		private static string ToneStringToBinaryString(string toneString)
		{
			string result = "1";
			foreach (var tone in toneString.ToCharArray())
			{
				switch (tone)
				{
					case 'T':
						result += "01";
						break;
					case 'S':
						result += "1";
						break;
					default:
						throw new Exception();
				}
			}
			return result;
		}
	}

	internal static class Definitions
	{
		private static readonly Dictionary<string, string> _namedHeptatonicModes = new Dictionary<string, string>()
		{
			// NOTICE! The first seven all have two "1s" and five "2s".
			// Furthermore, it's a rotating pattern of two 2s and three 2s, separated by 1s.
			{ "2212221", "Ionian" },
			{ "2122212", "Dorian" },
			{ "1222122", "Phrygian" },
			{ "2221221", "Lydian" },
			{ "2212212", "Mixolydian" },
			{ "2122122", "Aeolian" },
			{ "1221222", "Locrian" },

			{ "1312131", "Byzantine" },
			{ "2211222", "Arabian" },
			{ "2122131", "Harmonic Minor" },
			{ "1222131", "Neapolitan Minor" },
			{ "1312122", "Spanish Gypsy" },
			{ "1322211", "Enigmatic" },
			{ "2121222", "Half Diminished" },
			{ "2212122", "Hindu" },
			{ "3121212", "Hungarian Major" },
			{ "1222212", "Javanese" },
			{ "2222211", "Leading Whole Tone" },
			{ "2222121", "Lydian Augmented" },
			{ "2221122", "Lydian Minor" },
			{ "2131221", "Lydian Diminished" },
			{ "1222221", "Neapolitan Major" },
			{ "1311222", "Oriental A" },
			{ "1311312", "Oriental B" },
			{ "1311231", "Persian" },
			{ "1321131", "Purvi Theta" },
			{ "2131212", "Romanian Minor" },
			{ "1321221", "Marva" },
			{ "1131132", "Chromatic Mixolydian" },
			{ "1311321", "Chromatic Lydian" },
			{ "3113211", "Chromatic Phrygian" },
			{ "2113113", "Chromatic Hypodorian" },
			{ "1212213", "Ultra Locrian" },
			{ "2121321", "Jeth's Mode" },
			{ "1313211", "Enigmatic Descending" },
			{ "1212222", "Super Locrian" },
			{ "2122221", "Melodic Minor (Ascending)" },
		};

		public static IReadOnlyDictionary<string, string> NamedHeptatonicModes { get { return _namedHeptatonicModes; } }

		private static readonly Dictionary<string, string> _namedPentatonicModes = new Dictionary<string, string>()
		{
			{ "22323", "Major Pentatonic" },
			{ "32232", "Minor Pentatonic" },
			{ "42141", "Chinese" },
			{ "23232", "Egyptian" },
			{ "14232", "Japanese" },
			{ "14142", "Hirajoshi" },
		};

		public static IReadOnlyDictionary<string, string> NamedPentatonicModes { get { return _namedPentatonicModes; } }

		private static readonly Dictionary<string, Chord3> TriadChords = new Dictionary<string, Chord3>()
		{
			{ "Major", new Chord3(Intervals.MajorThird, Intervals.MinorThird) },
			{ "Minor", new Chord3(Intervals.MinorThird, Intervals.MajorThird) },
			{ "Suspended Second", new Chord3(Intervals.MajorSecond, Intervals.PerfectFourth) },
			{ "Suspended Fourth", new Chord3(Intervals.PerfectFourth, Intervals.MajorSecond) },
			{ "Diminished", new Chord3(Intervals.MinorThird, Intervals.MinorThird) },
			{ "Augmented", new Chord3(Intervals.MajorThird, Intervals.MajorThird) }
		};

		private static readonly Dictionary<string, Chord4> SeventhChords = new Dictionary<string, Chord4>()
		{
			{ "Major Seventh", new Chord4(TriadChords["Major"], Intervals.MajorThird) },
			{ "Minor Seventh", new Chord4(TriadChords["Minor"], Intervals.MinorThird) },
			{ "Minor Major Seventh", new Chord4(TriadChords["Minor"], Intervals.MajorThird) },
			{ "Dominant Seventh", new Chord4(TriadChords["Major"], Intervals.MinorThird) },
			{ "Half Diminished", new Chord4(TriadChords["Diminished"], Intervals.MajorThird) }
		};
	}

	internal class Chord3
	{
		private readonly Intervals _interval1;
		private readonly Intervals _interval2;

		public Intervals Interval1 { get { return _interval1; } }
		public Intervals Interval2 { get { return _interval2; } }

		private readonly string _symbol;
		public string Symbol { get { return _symbol; } }

		public Chord3(Intervals interval1, Intervals interval2)
		{
			_interval1 = interval1;
			_interval2 = interval2;

			_symbol = GenerateSymbol();
		}

		private string GenerateSymbol()
		{
			if (_interval1 == Intervals.MajorThird && _interval2 == Intervals.MinorThird) { return "M"; }
			else if (_interval1 == Intervals.MinorThird && _interval2 == Intervals.MajorThird) { return "m"; }
			else if (_interval1 == Intervals.MajorSecond && _interval2 == Intervals.PerfectFourth) { return "sus2"; }
			else if (_interval1 == Intervals.PerfectFourth && _interval2 == Intervals.MajorSecond) { return "sus4"; }
			else if (_interval1 == Intervals.MajorThird && _interval2 == Intervals.MajorThird) { return "aug"; }
			else if (_interval1 == Intervals.MinorThird && _interval2 == Intervals.MinorThird) { return "dim"; }
			else { return string.Empty; }
		}
	}

	internal class Chord4
	{
		private readonly Chord3 _baseChord;
		private readonly Intervals _interval3;

		public Intervals Interval1 { get { return _baseChord.Interval1; } }
		public Intervals Interval2 { get { return _baseChord.Interval2; } }
		public Intervals Interval3 { get { return _interval3; } }

		public Chord4(Chord3 baseChord, Intervals interval3)
		{
			_baseChord = baseChord;
			_interval3 = interval3;
		}
	}

	[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	internal class ChordDefinitionAttribute : Attribute
	{
		public string Symbol { get; private set; }
		public string BinaryPattern { get; private set; }
		public string Description { get; private set; }

		public ChordDefinitionAttribute(string symbol, string binaryPattern, string description = "")
		{
			if (string.IsNullOrWhiteSpace(binaryPattern)) { throw new ArgumentException(nameof(binaryPattern)); }
			if (binaryPattern.Length < 1 || binaryPattern.Length > 32) { throw new ArgumentException(nameof(binaryPattern)); }
			
			Symbol = symbol;
			BinaryPattern = binaryPattern;
			Description = description;
		}
	}

	internal static class ChordUtilities
	{
		private static Dictionary<uint, string> _chordValues;
		public static Dictionary<uint, string> ChordValues
		{
			get
			{
				if (_chordValues == null || _chordValues.Count == 0)
				{
					_chordValues = GetChordValues();
				}
				return _chordValues;
			}
		}

		private static Dictionary<uint, string> GetChordValues()
		{
			var fields = typeof(Chords).GetFields().Where(info => info.FieldType.Equals(typeof(Chords)));

			var result = new Dictionary<uint, string>();

			foreach (var field in fields)
			{
				var definition = (ChordDefinitionAttribute)field.GetCustomAttribute(typeof(ChordDefinitionAttribute));
				result.Add(Convert.BinaryStringToBitArray(definition.BinaryPattern).ToUInt32(), definition.Symbol);
			}

			return result;
		}
	}
}
