using System;

namespace FlintLib.Core.State
{
	public abstract class State
	{
		protected IStateContext _context;

		public State(IStateContext context)
		{
			if (context == null) { throw new ArgumentNullException(nameof(context)); }

			_context = context;
		}

		public virtual void TransitionToState(State state)
		{
			_context.CurrentState = state;
		}
	}
}
