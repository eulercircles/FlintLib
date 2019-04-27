using System;

namespace FlintLib.Structures
{
	public interface IBounded3D
	{
		float XMin { get; }
		float XMax { get; }

		float YMin { get; }
		float YMax { get; }
		
		float ZMin { get; }
		float ZMax { get; }
	}
}
