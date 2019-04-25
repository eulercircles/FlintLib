using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

using static FLib.Common.EnumUtilities;

namespace FLib.Music
{
	public static class Convert
	{
		public static BitArray BinaryStringToBitArray(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{ throw new ArgumentException("The string must not be null or white space.", nameof(value)); }

			if (value.Any(c => (c != '0' && c != '1')))
			{ throw new ArgumentException("The input string must consist of only the characters '1' and '0'.", nameof(value)); }

			var result = new BitArray(value.Length, false);

			for (int i = 0; i < value.Length; i++) { result[i] = (value[i] == '1') ? true : false; }

			return result;
		}

		public static string ToBinaryString(this BitArray value)
		{
			var result = string.Empty;
			value.Cast<bool>().ToList().ForEach(bit => {
				result += bit ? "1" : "0";
			});
			return result;
		}

		public static string StepStringToBinaryString(string stepString)
		{
			string result = "1";
			foreach (var step in stepString.ToCharArray())
			{
				switch (step)
				{
					case '1': // Half-Step
						result += "1";
						break;
					case '2': // Whole Step
						result += "01";
						break;
					case '3': // Step and a Half
						result += "001";
						break;
					default:
						throw new Exception();
				}
			}
			return result.PadRight(16, '0');
		}

		public static string ToneStringToBinaryString(string toneString)
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

	public static class Definitions
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
			{ "1312122", "Phrygian Dominant" },
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
		public static IReadOnlyDictionary<string, string> NamedHeptatonicModes => _namedHeptatonicModes;

		private static readonly Dictionary<string, string> _namedPentatonicModes = new Dictionary<string, string>()
		{
			{ "22323", "Major Pentatonic" },
			{ "32232", "Minor Pentatonic" },
			{ "42141", "Chinese" },
			{ "23232", "Egyptian" },
			{ "14232", "Japanese" },
			{ "14142", "Hirajoshi" },
		};
		public static IReadOnlyDictionary<string, string> NamedPentatonicModes => _namedPentatonicModes;

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

	public class Chord3
	{
		public Intervals Interval1 { get; }
		public Intervals Interval2 { get; }
		public string Symbol { get; }

		public Chord3(Intervals interval1, Intervals interval2)
		{
			Interval1 = interval1;
			Interval2 = interval2;

			Symbol = GenerateSymbol();
		}

		private string GenerateSymbol()
		{
			if (Interval1 == Intervals.MajorThird && Interval2 == Intervals.MinorThird) { return "M"; }
			else if (Interval1 == Intervals.MinorThird && Interval2 == Intervals.MajorThird) { return "m"; }
			else if (Interval1 == Intervals.MajorSecond && Interval2 == Intervals.PerfectFourth) { return "sus2"; }
			else if (Interval1 == Intervals.PerfectFourth && Interval2 == Intervals.MajorSecond) { return "sus4"; }
			else if (Interval1 == Intervals.MajorThird && Interval2 == Intervals.MajorThird) { return "aug"; }
			else if (Interval1 == Intervals.MinorThird && Interval2 == Intervals.MinorThird) { return "dim"; }
			else { return string.Empty; }
		}
	}

	public class Chord4
	{
		private readonly Chord3 _baseChord;

		public Intervals Interval1 { get { return _baseChord.Interval1; } }
		public Intervals Interval2 { get { return _baseChord.Interval2; } }
		public Intervals Interval3 { get; }

		public Chord4(Chord3 baseChord, Intervals interval3)
		{
			_baseChord = baseChord;
			Interval3 = interval3;
		}
	}

	public static class ChordUtilities
	{
		private static IReadOnlyDictionary<string, ChordTypes> _chordValues;
		public static IReadOnlyDictionary<string, ChordTypes> ChordValues
		{
			get
			{
				if (_chordValues == null || _chordValues.Count == 0)
				{
					_chordValues = GetEnumDescriptions<ChordTypes>();
				}
				return _chordValues;
			}
		}
	}
}