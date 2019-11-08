using System;

namespace FLib.Testing.MSTest.Rules
{
	internal class PropertySetRule : Rule
	{
		public PropertySetRule(Mock mock, string description, string propertyName, object value) : base(description)
		{
		}

		internal override void Evaluate()
		{
			throw new NotImplementedException();
		}
	}
}
