using System;

using FLibXamarin.Common;

namespace FLibXamarin.Scheduling
{
	public struct Date
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

		public Date(DateTime dateTime)
		{
			Year = dateTime.Year;
			Month = (Months)dateTime.Month;
			Day = dateTime.Day;
		}

		public DateTime ToDateTime()
		{
			return new DateTime(Year, (int)Month, Day);
		}

		public DayOfWeek DayOfWeek => ((DateTime)this).DayOfWeek;

		public int DayOfYear => ((DateTime)this).DayOfYear;

		public static Date Today => DateTime.Today;

		public Date BeginningOfMonth => ((DateTime)this).BeginningOfMonth();

		public Date BeginningOfWeek => ((DateTime)this).BeginningOfWeek();

		public Date EndOfMonth => ((DateTime)this).EndOfMonth();

		public Date EndOfWeek => ((DateTime)this).EndOfWeek();

		public bool IsHoliday => ((DateTime)this).IsHoliday();

		public bool IsChristmasDay => ((DateTime)this).IsChristmasDay();

		public bool IsChristmasEve => ((DateTime)this).IsChristmasEve();

		public bool IsDayAfterThanksgiving => ((DateTime)this).IsDayAfterThanksgiving();

		public bool IsFourthOfJuly => ((DateTime)this).IsFourthOfJuly();

		public bool IsLaborDay => ((DateTime)this).IsLaborDay();

		public bool IsMemorialDay => ((DateTime)this).IsMemorialDay();

		public bool IsNewYearsDay => ((DateTime)this).IsNewYearsDay();

		public bool IsNewYearsEve => ((DateTime)this).IsNewYearsEve();

		public bool IsThanksgivingDay => ((DateTime)this).IsThanksgivingDay();

		public Date AddYears(int years) => ((DateTime)this).AddYears(years);

		public Date AddMonths(int months) => ((DateTime)this).AddMonths(months);

		public Date AddDays(int days) => ((DateTime)this).AddDays(days);

		public override bool Equals(object obj)
		{
			if (!(obj is Date)) { }

			return ((Date)obj) == this;
		}

		public override int GetHashCode()
		{
			int hash = 13;
			hash = (hash * 7) + Year.GetHashCode();
			hash = (hash * 7) + ((int)Month).GetHashCode();
			hash = (hash * 7) + Day.GetHashCode();
			return hash;
		}

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
	}
}
