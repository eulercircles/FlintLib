using System;

namespace FLib.Structures.Generic
{
	public interface IBounded2D
	{
		float XMin { get; }
		float XMax { get; }

		float YMin { get; }
		float YMax { get; }
	}
}
