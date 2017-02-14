using System;

namespace FlintLib.Core.State
{
	public interface IStateContext
	{
		State CurrentState { get; set; }
	}
}
