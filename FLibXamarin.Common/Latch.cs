using System;

namespace FLibXamarin.Common
{
	public class TripSwitch
	{
		public bool IsTripped { get; private set; }
		public void Trip() => IsTripped = true;
	}
}
