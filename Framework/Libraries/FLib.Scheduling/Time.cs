using System;

using static FLib.Common.Messages;

namespace FLib.Scheduling
{
	public struct Time
	{
		private const int MIN_VALUE = 0;
		private const int MAX_HOURS = 23;
		private const int MAX_MINUTES = 59;
		private const int MAX_SECONDS = 59;

		private const int TOTAL_HOURS = 24;
		private const int TOTAL_MINUTES = 60;
		private const int TOTAL_SECONDS = 60;

		public int Hour { get; }
		public int Minute { get; }
		public int Second { get; }

		public static Time Now => DateTime.Now;

		public static bool operator <(Time left, Time right)
		{
			if (left.Hour < right.Hour) { return true; }
			else if (left.Hour == right.Hour)
			{
				if (left.Minute < right.Minute) { return true; }
				else if (left.Minute == right.Minute)
				{
					if (left.Second < right.Second) { return true; }
				}
			}

			return false;
		}

		public static bool operator >(Time left, Time right)
		{
			if (left.Hour > right.Hour) { return true; }
			else if (left.Hour == right.Hour)
			{
				if (left.Minute > right.Minute) { return true; }
				else if (left.Minute == right.Minute)
				{
					if (left.Second > right.Second) { return true; }
				}
			}

			return false;
		}

		public static bool operator <=(Time left, Time right)
		{
			if (left.Hour < right.Hour) { return true; }
			else if (left.Hour > right.Hour) { return false; }
			else
			{
				if (left.Minute < right.Minute) { return true; }
				else if (left.Minute > right.Minute) { return false; }
				else
				{
					if (left.Second < right.Second) { return true; }
					else if (left.Second > right.Second) { return false; }
				}
			}
			return true;
		}

		public static bool operator >=(Time left, Time right)
		{
			if (left.Hour > right.Hour) { return true; }
			else if (left.Hour < right.Hour) { return false; }
			else
			{
				if (left.Minute > right.Minute) { return true; }
				else if (left.Minute < right.Minute) { return false; }
				else
				{
					if (left.Second > right.Second) { return true; }
					else if (left.Second < right.Second) { return false; }
				}
			}
			return true;
		}

		public static bool operator ==(Time left, Time right) => (left.Hour == right.Hour && left.Minute == right.Minute && left.Second == right.Second);

		public static bool operator !=(Time left, Time right) => (left.Hour != right.Hour || left.Minute != right.Minute || left.Second != right.Second);

		public static implicit operator Time(DateTime value) => new Time(value.Hour, value.Minute, value.Second);

		public Time(int hour, int minute, int second)
		{
			if (hour < MIN_VALUE || hour > MAX_HOURS)
			{ throw new ArgumentOutOfRangeException(nameof(hour), string.Format(fValueMustBeBetween, MIN_VALUE, MAX_HOURS)); }
			if (minute < MIN_VALUE || minute > MAX_MINUTES)
			{ throw new ArgumentOutOfRangeException(nameof(minute), string.Format(fValueMustBeBetween, MIN_VALUE, MAX_MINUTES)); }
			if (second < MIN_VALUE || second > MAX_SECONDS)
			{ throw new ArgumentOutOfRangeException(nameof(hour), string.Format(fValueMustBeBetween, MIN_VALUE, MAX_SECONDS)); }

			Hour = hour;
			Minute = minute;
			Second = second;
		}

		public Time AddHours(int hours) { throw new NotImplementedException(); }

		public Time AddMinutes(int minutes) { throw new NotImplementedException(); }

		public Time AddSecond(int seconds) { throw new NotImplementedException(); }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">A string formatted as 'hh:mm:ss'</param>
		/// <returns></returns>
		public static Time Parse(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{ throw new ArgumentOutOfRangeException(nameof(value), "The value must be a non-null string of the format 'hh:mm:ss'"); }

			var parts = value.Split();
			return new Time(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
		}

		public override bool Equals(object obj)
		{
			var other = (Time)obj;
			return (Hour == other.Hour && Minute == other.Minute && Second == other.Second);
		}

		public override int GetHashCode()
		{
			int hash = 13;
			hash = (hash * 7) + Hour.GetHashCode();
			hash = (hash * 7) + Minute.GetHashCode();
			hash = (hash * 7) + Second.GetHashCode();
			return hash;
		}

		public override string ToString()
		{
			var hour = Hour.ToString().PadLeft(2, '0');
			var minute = Minute.ToString().PadLeft(2, '0');
			var second = Second.ToString().PadLeft(2, '0');
			return $"{hour}:{minute}:{second}";
		}
	}
}
