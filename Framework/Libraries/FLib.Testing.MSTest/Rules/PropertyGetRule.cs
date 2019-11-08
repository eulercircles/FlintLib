using System;

namespace FLib.Testing.MSTest.Rules
{
	internal class PropertyGetRule : Rule
	{
		public PropertyGetRule(Mock mock, string description, string propertyName) : base(description)
		{

		}

		internal override void Evaluate()
		{
			throw new NotImplementedException();
		}
	}
}
