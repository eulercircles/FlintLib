using System;

namespace FlintLib.Forms
{
	public enum TextBoxValidityStates
	{
		Default,
		Neutral,
		Valid,
		Invalid
	}

	public enum ValidationTriggers
	{
		FocusLost,
		TextChanged
	}
}
