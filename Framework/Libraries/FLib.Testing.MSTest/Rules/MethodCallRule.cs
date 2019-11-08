using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace FLib.Testing.MSTest.Rules
{
	internal class MethodCallRule : Rule
	{
		private readonly string _methodName;
		private readonly Lazy<Dictionary<string, object>> _paramValueMatches;

		private bool _methodCalled;
		private bool _parametersMatched;

		public MethodCallRule(Mock mock, string methodName, string description, params ValueTuple<string, object>[] paramValueMatches) : base(description)
		{
			if (mock == null) { throw new ArgumentNullException(nameof(mock)); }
			_methodName = (!string.IsNullOrWhiteSpace(methodName)) ? methodName : throw new ArgumentNullException(nameof(methodName));

			mock.MethodCalled.Subscribe(MethodCalled);

			paramValueMatches?.ToList().ForEach(m => {
				_paramValueMatches.Value[m.Item1] = m.Item2;
			});
		}

		private void MethodCalled(object sender, MethodCalledEventArgs e)
		{
			if (e.MethodName == _methodName)
			{
				_methodCalled = true;

				if (_paramValueMatches.IsValueCreated)
				{
					e.Parameters.Keys.ToList().ForEach(k =>
					{
						if (_paramValueMatches.Value.ContainsKey(k))
						{

						}
					});
				}
			}
		}

		internal override void Evaluate()
		{
			Assert.IsTrue(_methodCalled, _description);
			Assert.IsTrue(_parametersMatched, _description);
		}
	}
}
