using System;

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
	}
}
