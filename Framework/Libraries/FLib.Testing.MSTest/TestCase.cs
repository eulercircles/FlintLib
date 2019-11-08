using System;
using System.Linq;
using System.Collections.Generic;

using static FLib.Testing.Messages;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using FLib.Testing.MSTest.Rules;

namespace FLib.Testing.MSTest
{
	public class TestCase
	{
		private readonly Lazy<List<Rule>> _rules = new Lazy<List<Rule>>();

		public TestCase RequireMethodCall(Mock mock, string description, string methodName, params ValueTuple<string, object>[] parameterValues)
		{
			_rules.Value.Add(new MethodCallRule(mock, methodName, description, parameterValues));
			return this;
		}

		public TestCase RequirePropertyGet(Mock mock, string description, string propertyName)
		{
			_rules.Value.Add(new PropertyGetRule(mock, description, propertyName));
			return this;
		}

		public TestCase RequirePropertySet(Mock mock, string description, string propertyName, object value)
		{
			_rules.Value.Add(new PropertySetRule(mock, description, propertyName, value));
			return this;
		}

		public void Run(Action m, Predicate<Exception> e = null)
		{
			Assert.IsNotNull(m);
			try
			{
				m();
				if (_rules.IsValueCreated) { _rules.Value.ForEach(r => r.Evaluate()); }
			}
			catch (Exception exception)
			{
				if (e != null)
				{
					Assert.IsTrue(e(exception));
				}
				else
				{
					Assert.Fail(fExpectedNoException, exception.GetType(), exception.ToString());
				}
			}
		}

		public void Run<P>(Action<P> m, P p, Predicate<Exception> e = null)
		{
			Assert.IsNotNull(m);
			try
			{
				m(p);
				if (_rules.IsValueCreated) { _rules.Value.ForEach(rule => rule.Evaluate()); }
			}
			catch (Exception exception)
			{
				if (e != null)
				{
					Assert.IsTrue(e(exception));
				}
				else
				{
					Assert.Fail(fExpectedNoException, exception.GetType(), exception.ToString());
				}
			}
		}

		public void Run<P1, P2>(Action<P1, P2> m, P1 p1, P2 p2, Predicate<Exception> e = null)
		{
			Assert.IsNotNull(m);
			try
			{
				m(p1, p2);
				if (_rules.IsValueCreated) { _rules.Value.ForEach(rule => rule.Evaluate()); }
			}
			catch (Exception exception)
			{
				if (e != null)
				{
					Assert.IsTrue(e(exception));
				}
				else
				{
					Assert.Fail(fExpectedNoException, exception.GetType(), exception.ToString());
				}
			}
		}

		public void Run<R>(Func<R> m, Predicate<R> r = null, Predicate<Exception> e = null)
		{
			Assert.IsNotNull(m);
			try
			{
				R result = m();
				if (_rules.IsValueCreated) { _rules.Value.ForEach(rule => rule.Evaluate()); }
				if (r != null) { Assert.IsTrue(r(result)); }
			}
			catch (Exception exception)
			{
				if (e != null)
				{
					Assert.IsTrue(e(exception));
				}
				else
				{
					Assert.Fail(fExpectedNoException, exception.GetType(), exception.ToString());
				}
			}
		}

		public void Run<R, P>(Func<P, R> m, P p, Predicate<R> r = null, Predicate<Exception> e = null)
		{

		}

		public void Run<R, P1, P2>(Func<P1, P2, R> m, P1 p1, P2 p2)
		{

		}
	}
}
