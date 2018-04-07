using System;

namespace FlintLib.Accounting
{
	public interface IAccount
	{
		double Balance { get; }

		void Debit(IAccount target);
		void Credit(IAccount source);
	}
}
