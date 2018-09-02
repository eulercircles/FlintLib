using System;
using System.Diagnostics;

namespace FlintLib.Accounting
{
	public interface IAccount
	{
		string Name { get; }
		decimal? Balance { get; }

		void SetBalanceTo(decimal amount);
		void Debit(decimal amount);
		void Credit(decimal amount);
	}

	public class ExternalAccount : IAccount
	{
		public string Name { get; }
		public decimal? Balance { get; }

		public ExternalAccount(string name)
		{
			Name = name;
			Balance = null;
		}

		public void SetBalanceTo(decimal amount) {}

		public void Debit(decimal amount) {}

		public void Credit(decimal amount) {}
	}

	public class InternalAccount : IAccount
	{
		public string Name { get; }

		public decimal? Balance { get; private set; }

		public InternalAccount(string name, decimal amount)
		{
			if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }
			Balance = amount;
		}

		public void Credit(decimal amount)
		{
			Debug.Assert(amount > 0.0m);
			Balance += amount;
		}

		public void Debit(decimal amount)
		{
			Debug.Assert(amount > 0.0m);
			Balance -= amount;
		}

		public void SetBalanceTo(decimal amount)
		{
			Balance = amount;
		}
	}

}
