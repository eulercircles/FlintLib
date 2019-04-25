using System;
using System.Diagnostics;

namespace FLib.Accounting
{
	public interface IAccount
	{
		string Name { get; }
		decimal? Balance { get; }

		void SetBalanceTo(decimal amount);
		void Debit(decimal amount);
		void Credit(decimal amount);
	}

	public class Account : IAccount
	{
		public string Name { get; set; }
		public decimal? Balance { get; private set; }

		public Account(string name, decimal amount)
		{
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }
			Balance = amount;
		}

		public void Credit(decimal amount)
		{
			if (amount < 0) { amount = -amount; }
			Balance += amount;
		}

		public void Debit(decimal amount)
		{
			if (amount < 0) { amount = -amount; }
			Balance -= amount;
		}

		public void SetBalanceTo(decimal amount)
		{
			Balance = amount;
		}
	}
}
