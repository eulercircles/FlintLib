using System;

namespace FLib.MVVM
{
	public interface IMediator
	{
		void Register<T>(MediatorRespondent<T> respondent) where T : MediatorArgs;
		void Unregister<T>(MediatorRespondent<T> respondent) where T : MediatorArgs;
		void NotifyColleagues<T>(T message) where T : MediatorArgs;
	}

	public delegate void MediatorRespondent<T>(T args) where T : MediatorArgs;
}
