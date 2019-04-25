using System;

using static FLibXamarin.Common.Properties.PublicResources;

namespace FLibXamarin.Scheduling
{
	public struct TimeOfDay
	{
		public int Hour { get; }
		public int Minute { get; }
		public int Second { get; }

		public static TimeOfDay Now => DateTime.Now;

		public static bool operator <(TimeOfDay left, TimeOfDay right)
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

		public static bool operator >(TimeOfDay left, TimeOfDay right)
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

		public static bool operator <=(TimeOfDay left, TimeOfDay right)
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

		public static bool operator >=(TimeOfDay left, TimeOfDay right)
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

		public static bool operator ==(TimeOfDay left, TimeOfDay right) => (left.Hour == right.Hour && left.Minute == right.Minute && left.Second == right.Second);

		public static bool operator !=(TimeOfDay left, TimeOfDay right) => (left.Hour != right.Hour || left.Minute != right.Minute || left.Second != right.Second);

		public static implicit operator TimeOfDay(DateTime value) => new TimeOfDay(value.Hour, value.Minute, value.Second);

		public TimeOfDay(int hour, int minute, int second)
		{
			if (hour < Constants.MIN_VALUE || hour > Constants.MAX_HOURS)
			{ throw new ArgumentOutOfRangeException(nameof(hour), string.Format(fMessage_ValueMustBeBetween, Constants.MIN_VALUE, Constants.MAX_HOURS)); }
			if (minute < Constants.MIN_VALUE || minute > Constants.MAX_MINUTES)
			{ throw new ArgumentOutOfRangeException(nameof(minute), string.Format(fMessage_ValueMustBeBetween, Constants.MIN_VALUE, Constants.MAX_MINUTES)); }
			if (second < Constants.MIN_VALUE || second > Constants.MAX_SECONDS)
			{ throw new ArgumentOutOfRangeException(nameof(hour), string.Format(fMessage_ValueMustBeBetween, Constants.MIN_VALUE, Constants.MAX_SECONDS)); }

			Hour = hour;
			Minute = minute;
			Second = second;
		}

		public TimeOfDay AddHours(int hours) { throw new NotImplementedException(); }

		public TimeOfDay AddMinutes(int minutes) { throw new NotImplementedException(); }

		public TimeOfDay AddSecond(int seconds) { throw new NotImplementedException(); }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value">A string formatted as 'hh:mm:ss'</param>
		/// <returns></returns>
		public static TimeOfDay Parse(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{ throw new ArgumentOutOfRangeException(nameof(value), "The value must be a non-null string of the format 'hh:mm:ss'"); }

			var parts = value.Split();
			return new TimeOfDay(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
		}

		public override bool Equals(object obj)
		{
			var other = (TimeOfDay)obj;
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
