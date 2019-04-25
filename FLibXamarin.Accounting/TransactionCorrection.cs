using FLibXamarin.Scheduling;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace FLibXamarin.Accounting
{
	public class TransactionCorrection
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
