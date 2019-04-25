using System;
using System.Diagnostics;

namespace FLibXamarin.Accounting
{
	public interface IAccount
	{
		string Name { get; }
		decimal? Balance { get; }

		void Debit(decimal amount);
		void Credit(decimal amount);
	}

	public class Account : IAccount
	{
		public string Name { get; set; }
		public decimal? Balance { get; set; }

		public Account(string name, decimal balance)
		{
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }
			Name = name;
			Balance = balance;
		}

		/// <summary>
		/// Increases the account's balance by the specified amount. The sign is ignored.
		/// </summary>
		/// <param name="amount"></param>
		public void Credit(decimal amount)
		{
			// While crediting 0 to the account will not be problematic, it could indicate that something isn't right somewhere else.
			Debug.Assert(amount != 0);

			if (amount < 0) { amount = -amount; }
			Balance += amount;
		}

		/// <summary>
		/// Decreases the account's balance by the specified amount. The sign is ignored.
		/// </summary>
		/// <param name="amount"></param>
		public void Debit(decimal amount)
		{
			// While crediting 0 to the account will not be problematic, it could indicate that something isn't right somewhere else.
			Debug.Assert(amount != 0);

			if (amount < 0) { amount = -amount; }
			Balance -= amount;
		}
	}
}
