using System;
using System.Diagnostics;

using FlintLib.Scheduling;

namespace FlintLib.Accounting
{
	internal class TransactionCorrection
	{
		internal Date? Date { get; }
		internal decimal? Amount { get; }

		internal TransactionCorrection(Date? date, decimal? amount)
		{
			Debug.Assert(date.HasValue || amount.HasValue);

			Date = date;
			Amount = amount;
		}
	}
}
