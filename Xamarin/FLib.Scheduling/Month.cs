using System;

namespace FLibXamarin.Scheduling
{
	public struct Month : IEquatable<Month>
	{
		public int Year { get; }

		public Months Name { get; }

		public static bool operator ==(Month l, Month r) => l.Equals(r);
		public static bool operator !=(Month l, Month r) => !l.Equals(r);

		public static bool operator <(Month l, Month r) => throw new NotImplementedException();
		public static bool operator >(Month l, Month r) => throw new NotImplementedException();

		public static bool operator <=(Month l, Month r) => throw new NotImplementedException();
		public static bool operator >=(Month l, Month r) => throw new NotImplementedException();

		public static implicit operator Month(DateTime value) => new Month(value.Year, (Months)value.Month);
		public static implicit operator Month(Date value) => new Month(value.Year, value.Month);

		public Month(int year, Months name)
		{
			if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year) { throw new ArgumentOutOfRangeException(nameof(year)); }
			if (name == Months.UNDEFINED) { throw new ArgumentOutOfRangeException(nameof(name)); }

			Year = year;
			Name = name;
		}

		public Month AddMonths(int months) => new DateTime(Year, (int)Name, 1).AddMonths(months);
		public Month AddYears(int years) => new DateTime(Year, (int)Name, 1).AddYears(years);

		public bool Equals(Month other) => (other.Year == Year && other.Name == Name);

		public override bool Equals(object obj)
		{
			if (obj == null) { throw new ArgumentNullException(nameof(obj)); }
			if (!(obj is Month)) { throw new ArgumentException(nameof(obj)); }
			return Equals((Month)obj);
		}

		public override int GetHashCode() => new { Year, Name }.GetHashCode();

		public override string ToString() => $"{Name} {Year}";
	}
}
