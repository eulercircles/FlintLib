using System;

namespace FLib.Testing.MSTest.Rules
{
	internal abstract class Rule
	{
		protected readonly string _description;

		internal Rule(string description)
		{
			_description = (!string.IsNullOrWhiteSpace(description)) ? description : throw new ArgumentNullException(nameof(description));
		}

		internal abstract void Evaluate();
	}
}
