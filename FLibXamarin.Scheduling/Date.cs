using System;

using FLibXamarin.Common;

namespace FLibXamarin.Scheduling
{
	public struct Date : IEquatable<Date>
	{
		public int Year { get; }
		public Months Month { get; }
		public int Day { get; }

		#region Operator Overloads
		public static bool operator <(Date left, Date right)
		{
			if (left.Year < right.Year) { return true; }
			else if (left.Year == right.Year)
			{
				if (left.Month < right.Month) { return true; }
				else if (left.Month == right.Month)
				{
					if (left.Day < right.Day) { return true; }
				}
			}

			return false;
		}

		public static bool operator >(Date left, Date right)
		{
			if (left.Year > right.Year) { return true; }
			else if (left.Year == right.Year)
			{
				if (left.Month > right.Month) { return true; }
				else if (left.Month == right.Month)
				{
					if (left.Day > right.Day) { return true; }
				}
			}

			return false;
		}

		public static bool operator <=(Date left, Date right)
		{
			if (left.Year < right.Year) { return true; }
			else if (left.Year > right.Year) { return false; }
			else
			{
				if (left.Month < right.Month) { return true; }
				else if (left.Month > right.Month) { return false; }
				else
				{
					if (left.Day < right.Day) { return true; }
					else if (left.Day > right.Day) { return false; }
				}
			}

			return true;
		}

		public static bool operator >=(Date left, Date right)
		{
			if (left.Year > right.Year) { return true; }
			else if (left.Year < right.Year) { return false; }
			else
			{
				if (left.Month > right.Month) { return true; }
				else if (left.Month < right.Month) { return false; }
				else
				{
					if (left.Day > right.Day) { return true; }
					else if (left.Day < right.Day) { return false; }
				}
			}

			return true;
		}

		public static bool operator ==(Date left, Date right) => (left.Year == right.Year && left.Month == right.Month && left.Day == right.Day);

		public static bool operator !=(Date left, Date right) => (left.Year != right.Year || left.Month != right.Month || left.Day != right.Day);

		public static implicit operator DateTime(Date date) => new DateTime(date.Year, (int)date.Month, date.Day);

		public static implicit operator Date(DateTime dateTime) => new Date(dateTime);
		#endregion Operator Overloads

		public Date(int year, Months month, int day)
		{
			if (year < 1 || year > DateTime.MaxValue.Year)
			{ throw new ArgumentOutOfRangeException(nameof(year)); }

			if (day < 1 || day > DateTime.DaysInMonth(year, (int)month))
			{ throw new ArgumentOutOfRangeException(nameof(day)); }

			Year = year;
			Month = month;
			Day = day;
		}

		public Date(DateTime dateTime) : this(dateTime.Year, (Months)dateTime.Month, dateTime.Day) { }

		public DateTime ToDateTime()
		{
			return new DateTime(Year, (int)Month, Day);
		}

		public DayOfWeek DayOfWeek => ((DateTime)this).DayOfWeek;

		public int DayOfYear => ((DateTime)this).DayOfYear;

		public static Date Today => DateTime.Today;

		public Date AddYears(int years) => ((DateTime)this).AddYears(years);

		public Date AddMonths(int months) => ((DateTime)this).AddMonths(months);

		public Date AddDays(int days) => ((DateTime)this).AddDays(days);

		public override bool Equals(object obj) => (obj is Date) ? Equals((Date)obj) : throw new ArgumentException($"Argument must be of type '{typeof(Date)}'.", nameof(obj));

		public override int GetHashCode() => new { Year, Month, Day }.GetHashCode();

		public override string ToString()
		{
			return $"{Year.ToString().PadLeft(4, '0')}-{((int)Month).ToString().PadLeft(2, '0')}-{Day.ToString().PadLeft(2, '0')}";
		}

		/// <summary>
		/// Assumes the exact format that was generated in Date.ToString().
		/// </summary>
		/// <param name="value">A string with the format 'yyyy-MM-dd'.</param>
		/// <returns></returns>
		public static Date ParseExact(string value)
		{
			var parts = value.Split('-');
			return new Date(int.Parse(parts[0]), (Months)int.Parse(parts[1]), int.Parse(parts[2]));
		}

		public bool Equals(Date other) => (other.Year == Year && other.Month == Month && other.Day == Day);
	}
}
