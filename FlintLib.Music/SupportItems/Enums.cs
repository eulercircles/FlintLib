using System;

namespace FlintLib.Music
{
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

	public enum NoteLetters
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

	/// <summary>
	/// Chord values are defined by key on-or-off, starting from the right.
	/// The far right digit is the root of the chord, so it's always a 1.
	/// Each value defines a 16-bit number, but only 12 bits are used since
	/// there are only 12 keys on a keyboard.
	/// </summary>
	public enum ChordTypes : ushort
	{
													//       Mm     Mm
													//UNUSED 776 5 4332 1
		Fifth									= 0b0000_000010000001,
		Major									= 0b0000_000010010001,
		Minor									= 0b0000_000010001001,
		Augmented							= 0b0000_000100010001,
		Diminished						= 0b0000_000001001001,
		Suspended2nd					= 0b0000_000010000101,
		Suspended4th					= 0b0000_000010100001,
		Major7th							= 0b0000_100010010001,
		Dominant7th						= 0b0000_010010010001,
		Minor7th							= 0b0000_010010001001,
		MinorMajor7th					= 0b0000_100010001001,
		Major7thFlat5th				= 0b0000_100001010001,
		Major7thSharp5th			= 0b0000_100100010001,
		SeventhFlat5th				= 0b0000_010001010001,
		SeventhSharp5th				= 0b0000_010100010001,
		Minor7thFlat5th				= 0b0000_010001001001,
		Diminished7th					= 0b0000_001001001001,
		SeventhSuspened4th		= 0b0000_010010100001,
		Major6th							= 0b0000_001010010001,
		Minor6th							= 0b0000_001010001001,
		Add9th								= 0b0000_000010010101,
		MinorAdd9th						= 0b0000_000010001101,
		Major6th9th						= 0b0000_001010010101,
		Minor6th9th						= 0b0000_001010001101,
		//SeventhFlat9th				=	0b0000_000000000000,
		//SeventhSharp9th				=	0b0000_000000000000,
		//Major9th							=	0b0000_000000000000,
		//Ninth									=	0b0000_000000000000,
		//Minor9th							=	0b0000_000000000000,
		//Minor9thMajor7th			=	0b0000_000000000000,
		//EleventhNo3rd					=	0b0000_000000000000,
		//Major7thAdd11th				=	0b0000_000000000000,
		//SeventhAdd11th				=	0b0000_000000000000,
		//Minor7thAdd11th				=	0b0000_000000000000,
		//Major7thAdd13th				=	0b0000_000000000000,
		//SeventhAdd13th				=	0b0000_000000000000,
		//Minor7thAdd13th				=	0b0000_000000000000,
		Major11th							= 0b0000_100010110101,
		//Eleventh							=	0b0000_000000000000,
		//Minor11th							=	0b0000_000000000000,
		//Major13th							=	0b0000_000000000000,
		//Thirteenth						=	0b0000_000000000000,
		//Minor13th							=	0b0000_000000000000
	}
}
