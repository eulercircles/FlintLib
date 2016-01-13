using System;
using System.Windows.Input;

namespace FlintLib.Experimental
{
	public class TestVM
	{
		public TestVM()
		{
			CommandHub.PerformMethod = new ActionCommand(DoRoutine, CanDoRoutine);
			CommandHub.SetSomeValue = new ActionCommand<int>(SetMyValue, CanSetMyValue);

		}

		public void Initialize()
		{
			if (CommandHub.PerformMethod != null) { CommandHub.PerformMethod.Executed += PerformMethod_Executed; }
			if (CommandHub.SetSomeValue != null) { CommandHub.SetSomeValue.Executed += SetSomeValue_Executed; }
			if (CommandHub.GetName != null) { CommandHub.GetName.Executed += GetName_Executed; }
			if (CommandHub.GetValueByKey != null) { CommandHub.GetValueByKey.Executed += GetValueByKey_Executed; }
		}

		private void GetValueByKey_Executed(int result)
		{
			throw new NotImplementedException();
		}

		private void GetName_Executed(string result)
		{
			throw new NotImplementedException();
		}

		private void SetSomeValue_Executed()
		{
			throw new NotImplementedException();
		}

		private void PerformMethod_Executed()
		{
			throw new NotImplementedException();
		}

		private bool CanSetMyValue()
		{
			throw new NotImplementedException();
		}

		private void SetMyValue(int parameter)
		{
			throw new NotImplementedException();
		}

		private bool CanDoRoutine()
		{
			throw new NotImplementedException();
		}

		private void DoRoutine()
		{
			throw new NotImplementedException();
		}
	}
}
