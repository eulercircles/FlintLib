using System;

namespace FlintLib.Commands
{
    public abstract class ActionCommand : IActionCommand
    {
        protected Action _executionDelegate;

        public ActionCommand(Action executionDelegate)
        {
            if (executionDelegate == null) { throw new ArgumentNullException(nameof(executionDelegate)); }
            _executionDelegate = executionDelegate;
        }

        public virtual void Execute()
        {
            _executionDelegate.Invoke();
        }

        public object Execute(object parameter)
        {
            Execute();
            return null;
        }
    }

    public abstract class ActionCommand<P> : IActionCommand<P>
    {
        protected Action<P> _executionDelegate;

        public ActionCommand(Action<P> executionDelegate)
        {
            if (executionDelegate == null) { throw new ArgumentNullException(nameof(executionDelegate)); }
            _executionDelegate = executionDelegate;
        }

        public virtual void Execute(P parameter)
        {
            _executionDelegate.Invoke(parameter);
        }

        public object Execute(object parameter)
        {
            Execute((P)parameter);
            return null;
        }
    }

    public abstract class FunctionCommand<R> : IFunctionCommand<R>
    {
        protected Function<R> _executionDelegate;

        public FunctionCommand(Function<R> executionDelegate)
        {
            if (executionDelegate == null) { throw new ArgumentNullException(nameof(executionDelegate)); }
            _executionDelegate = executionDelegate;
        }

        public virtual R Execute()
        {
            return _executionDelegate.Invoke();
        }

        public object Execute(object parameter)
        {
            return Execute();
        }
    }

    public abstract class FunctionCommand<R, P> : IFunctionCommand<R, P>
    {
        protected Function<R, P> _executionDelegate;

        public FunctionCommand(Function<R, P> executionDelegate)
        {
            if (executionDelegate == null) { throw new ArgumentNullException(nameof(executionDelegate)); }
            _executionDelegate = executionDelegate;
        }

        public virtual R Execute(P parameter)
        {
            return _executionDelegate.Invoke(parameter);
        }

        public object Execute(object parameter)
        {
            return Execute((P)parameter);
        }
    }
}
