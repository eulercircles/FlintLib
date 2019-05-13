using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using static FLib.Testing.Messages;

namespace FLib.Testing
{
	public abstract class Tester
	{
		public void RunPositive(Action testMethod, MockLogger logger = null)
		{
			var writeLogEntryCalled = false;
			try
			{
				logger?.MethodCalled.Subscribe((s, a) => {
					writeLogEntryCalled = (a.MethodName == nameof(logger.WriteEntry) && a.Parameters.Count > 0);
				});

				testMethod();
			}
			catch (Exception exception)
			{
				var message = string.Format(fExpectedNoException, exception.GetType(), exception.ToString());
			}

			if (logger != null) { Assert.IsTrue(writeLogEntryCalled, LogEntryNotWriten); }
		}

		public void RunPositive<P>(Action<P> testMethod, P parameter, MockLogger logger = null)
		{
			var writeLogEntryCalled = false;
			try
			{
				logger?.MethodCalled.Subscribe((s, a) => {
					writeLogEntryCalled = (a.MethodName == nameof(logger.WriteEntry) && a.Parameters.Count > 0);
				});

				testMethod(parameter);
			}
			catch (Exception exception)
			{
				var message = string.Format(fExpectedNoException, exception.GetType(), exception.ToString());
			}

			if (logger != null) { Assert.IsTrue(writeLogEntryCalled, LogEntryNotWriten); }
		}

		public void RunPositive<P1, P2>(Action<P1, P2> testMethod, P1 parameter1, P2 parameter2, MockLogger logger = null)
		{
			var writeLogEntryCalled = false;
			try
			{
				logger?.MethodCalled.Subscribe((s, a) => {
					writeLogEntryCalled = (a.MethodName == nameof(logger.WriteEntry) && a.Parameters.Count > 0);
				});

				testMethod(parameter1, parameter2);
			}
			catch (Exception exception)
			{
				var message = string.Format(fExpectedNoException, exception.GetType(), exception.ToString());
			}

			if (logger != null) { Assert.IsTrue(writeLogEntryCalled, LogEntryNotWriten); }
		}

		/// <summary>
		/// Runs a negative test with the expectation that an exception of a particular type will be thrown by the code under test, given the negative conditions.
		/// </summary>
		/// <typeparam name="E">The type of exception that is expected to be caught as a result of the negative test.</typeparam>
		/// <param name="testMethod">The method to invoke to begin the test.</param>
		/// <param name="exceptionEvaluator">A delegate that will evaluate the caught exception of the expected type for completeness.</param>
		/// <param name="logger">If not null, the method will check whether the code under test makes a call to the logger.</param>
		public void RunNegative<E>(Action testMethod, Action<E> exceptionEvaluator, MockLogger logger = null) where E : Exception
		{
			var writeLogEntryCalled = false;
			try
			{
				logger?.MethodCalled.Subscribe((s, a) => {
					writeLogEntryCalled = (a.MethodName == nameof(logger.WriteEntry) && a.Parameters.Count > 0);
				});

				testMethod();
			}
			catch (Exception exception)
			{
				if (exception.GetType() != typeof(E))
				{
					var catchMessage = string.Format(fUnexpectedException, typeof(E), exception.GetType(), exception.ToString());
					Assert.Fail(catchMessage);
				}
				else
				{
					exceptionEvaluator.Invoke((E)exception);
				}
			}

			var message = string.Format(fExpectedException, typeof(E));
			Assert.Fail(message);
		}

		/// <summary>
		/// Runs a negative test with the expectation that an exception of a particular type will be thrown by the code under test, given the negative conditions.
		/// </summary>
		/// <typeparam name="E">The type of exception that is expected to be caught as a result of the negative test.</typeparam>
		/// <typeparam name="P">The type of the parameter to pass to the method under test.</typeparam>
		/// <param name="testMethod">The method to invoke to begin the test.</param>
		/// <param name="parameter">The parameter to pass to the method under test.</param>
		/// <param name="exceptionEvaluator">A delegate that will evaluate the caught exception of the expected type for completeness.</param>
		/// <param name="logger">If not null, the method will check whether the code under test makes a call to the logger.</param>
		public void RunNegative<E, P>(Action<P> testMethod, P parameter, Action<E> exceptionEvaluator, MockLogger logger = null) where E : Exception
		{
			var writeLogEntryCalled = false;
			try
			{
				logger?.MethodCalled.Subscribe((s, a) => {
					writeLogEntryCalled = (a.MethodName == nameof(logger.WriteEntry) && a.Parameters.Count > 0);
				});

				testMethod(parameter);
			}
			catch (Exception exception)
			{
				if (exception.GetType() != typeof(E))
				{
					var catchMessage = string.Format(fUnexpectedException, typeof(E), exception.GetType(), exception.ToString());
					Assert.Fail(catchMessage);
				}
				else
				{
					exceptionEvaluator.Invoke((E)exception);
				}
			}

			var message = string.Format(fExpectedException, typeof(E));
			Assert.Fail(message);
		}

		/// <summary>
		/// Runs a negative test with the expectation that an exception of a particular type will be thrown by the code under test, given the negative conditions.
		/// </summary>
		/// <typeparam name="E">The type of exception that is expected to be caught as a result of the negative test.</typeparam>
		/// <typeparam name="P1">The type of the first parameter to pass to the method under test.</typeparam>
		/// <typeparam name="P2">The type of the second parameter to pass to the method under test.</typeparam>
		/// <param name="testMethod">The method to invoke to begin the test.</param>
		/// <param name="parameter1">The first parameter to pass to the method under test.</param>
		/// <param name="parameter2">The second parameter to pass to the method under test.</param>
		/// <param name="exceptionEvaluator">A delegate that will evaluate the caught exception of the expected type for completeness.</param>
		/// <param name="logger">If not null, the method will check whether the code under test makes a call to the logger.</param>
		public void RunNegative<E, P1, P2>(Action<P1, P2> testMethod, P1 parameter1, P2 parameter2, Action<E> exceptionEvaluator, MockLogger logger = null) where E : Exception
		{
			var writeLogEntryCalled = false;
			try
			{
				logger?.MethodCalled.Subscribe((s, a) => {
					writeLogEntryCalled = (a.MethodName == nameof(logger.WriteEntry) && a.Parameters.Count > 0);
				});

				testMethod(parameter1, parameter2);
			}
			catch (Exception exception)
			{
				if (exception.GetType() != typeof(E))
				{
					var catchMessage = string.Format(fUnexpectedException, typeof(E), exception.GetType(), exception.ToString());
					Assert.Fail(catchMessage);
				}
				else
				{
					exceptionEvaluator.Invoke((E)exception);
				}
			}

			var message = string.Format(fExpectedException, typeof(E));
			Assert.Fail(message);
		}
	}
}
