using System;
using System.Collections.Generic;
using System.Diagnostics;

using FLib.Common;

namespace FLib.Testing.MSTest
{
	/// <summary>
	/// Provides a base class for creating mock dependencies for testing purposes.
	/// </summary>
	public abstract class Mock
	{
		private readonly Lazy<Dictionary<string, Exception>> _methodCallExceptions;
		private readonly Lazy<Dictionary<string, object>> _methodCallReturns;

		private readonly SafeEvent<PropertyAccessedEventArgs> _propertyAccessed;
		internal Event<PropertyAccessedEventArgs> PropertyAccessed { get; }

		private readonly SafeEvent<MethodCalledEventArgs> _methodCalled;
		internal Event<MethodCalledEventArgs> MethodCalled { get; }

		public Mock()
		{
			_methodCallExceptions = new Lazy<Dictionary<string, Exception>>();

			_methodCallReturns = new Lazy<Dictionary<string, object>>();

			_propertyAccessed = new SafeEvent<PropertyAccessedEventArgs>();
			PropertyAccessed = new Event<PropertyAccessedEventArgs>(_propertyAccessed);

			_methodCalled = new SafeEvent<MethodCalledEventArgs>();
			MethodCalled = new Event<MethodCalledEventArgs>(_methodCalled);
		}

		protected void SetExceptionForMethodCall(string methodName, Exception exception)
		{
			Debug.Assert(exception != null);

			if (string.IsNullOrWhiteSpace(methodName)) { throw new ArgumentNullException(nameof(methodName)); }
			_methodCallExceptions.Value[methodName] = exception;
		}

		protected void SetReturnForMethodCall(string methodName, object value)
		{
			if (string.IsNullOrWhiteSpace(methodName)) { throw new ArgumentNullException(nameof(methodName)); }
			_methodCallReturns.Value[methodName] = value;

		}

		protected void OnPropertyAccessed(Accessors accessor, string propertyName, object value)
		{
			_propertyAccessed.Invoke(this, new PropertyAccessedEventArgs(accessor, propertyName, value));
		}

		protected object OnMethodCalled(params KeyValuePair<string, object>[] parameters)
		{
			var methodName = new StackFrame(1).GetMethod().Name;
			_methodCalled.Invoke(this, new MethodCalledEventArgs(methodName, parameters));

			if (_methodCallExceptions.IsValueCreated && _methodCallExceptions.Value.ContainsKey(methodName))
			{ throw _methodCallExceptions.Value[methodName]; }

			return _methodCallReturns.IsValueCreated ? _methodCallReturns.Value.ContainsKey(methodName) ? _methodCallReturns.Value[methodName] : null : null;
		}
	}
}
