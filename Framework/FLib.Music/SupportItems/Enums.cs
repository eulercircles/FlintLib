using System;

namespace FLib.Music
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
	/// Each value defines a 16-bit unsigned integer, but only 12 bits are 
	/// used since there are only 12 music notes.
	/// </summary>
	public enum ChordTypes : ushort
	{
													//        m m    m m
													//UNUSED 77665T433221
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
		SeventhFlat9th				=	0b0000_010010010011,
		SeventhSharp9th				=	0b0000_010010011001,
		Major9th							=	0b0000_100010010101,
		Ninth									=	0b0000_010010010101,
		Minor9th							=	0b0000_010010001101,
		Minor9thMajor7th			=	0b0000_100010001101,
		Major7thAdd11th				=	0b0000_100010110001,
		SeventhAdd11th				=	0b0000_010010110001,
		Minor7thAdd11th				=	0b0000_010010101001,
		Major7thAdd13th				=	0b0000_101010010001,
		SeventhAdd13th				=	0b0000_011010010001,
		Minor7thAdd13th				=	0b0000_011010001001,
		Major11th							= 0b0000_100010110101,
		Eleventh							=	0b0000_010010110101,
		Minor11th							=	0b0000_010010101101,
		Major13th							=	0b0000_101010110101,
		Thirteenth						=	0b0000_011010110101,
		Minor13th							=	0b0000_011010101101
	}
}
