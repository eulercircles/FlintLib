using System;
using System.Linq;
using System.Diagnostics;
using System.Collections.Generic;

using FLib.Scheduling;

namespace FLib.Accounting
{
	public class RecurringTransaction
	{
		private readonly IAccount _sourceAccount;
		private readonly IAccount _targetAccount;
		private readonly Queue<string> _pendingOccurrences;
		private readonly Dictionary<string, TransactionCorrection> _corrections;
		private readonly RecurrenceRule _recurrence;

		private Date _lastAppliedTransaction;

		string Name { get; }
		string Description { get; }
		decimal Amount { get; }

		public RecurringTransaction(string name, decimal amount, IAccount sourceAccount = null, IAccount targetAccount = null, RecurrenceRule recurrence = null)
		{
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }

			if (sourceAccount == null && targetAccount == null) { throw new Exception("The source and target accounts cannot both be null."); }

			_lastAppliedTransaction = recurrence.StartDate; // TODO: Remove this. It needs to be managed in another way.

			_sourceAccount = sourceAccount;
			_targetAccount = targetAccount;
			_recurrence = recurrence;

			_pendingOccurrences = new Queue<string>();
			_corrections = new Dictionary<string, TransactionCorrection>();

			Name = name;
			Amount = amount;

			CalculatePendingTransactions();
		}

		private void CalculatePendingTransactions()
		{
			var occurrences = _recurrence.GetOccurrencesBetween(_lastAppliedTransaction, Date.Today);
			foreach (var occurrence in occurrences)
			{
				_pendingOccurrences.Enqueue(occurrence.ToString());
			}
		}

		public void CorrectOccurrence(Date occurrenceDate, Date? correctionDate, decimal? correctionAmount)
		{
			Debug.Assert(correctionDate.HasValue || correctionAmount.HasValue);

			// Check if the occurrence is a valid occurrence date.

			_corrections.Add(occurrenceDate.ToString(), new TransactionCorrection(correctionDate, correctionAmount));
		}

		public void BringCurrent()
		{
			while(_pendingOccurrences.Count > 0)
			{
				var key = _pendingOccurrences.Dequeue();

				Debug.Assert(!string.IsNullOrWhiteSpace(key));

				if (_corrections.ContainsKey(key))
				{
					var correction = _corrections[key];
					ApplyTransaction(correction.Amount);
					_corrections.Remove(key);
				}
				else
				{
					ApplyTransaction();
				}

				_lastAppliedTransaction = Date.ParseExact(key);
			}
		}

		private void ApplyTransaction(decimal? overrideAmount = null)
		{
			var amount = overrideAmount ?? Amount;
			_sourceAccount?.Debit(amount);
			_targetAccount?.Credit(amount);
		}
	}
}
