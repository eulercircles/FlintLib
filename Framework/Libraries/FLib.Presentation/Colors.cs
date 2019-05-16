using System.Drawing;

namespace FLib.Presentation
{
	public static class Colors
	{
		public static Color GoodForeground { get; } = Color.FromArgb(255, 0, 97, 0); 
		public static Color GoodBackground { get; } = Color.FromArgb(255, 198, 239, 206);

		public static Color BadForeground { get; } = Color.FromArgb(255, 156, 0, 6);
		public static Color BadBackground { get; } = Color.FromArgb(255, 255, 199, 206);

		public static Color NeutralForeground { get; } = Color.FromArgb(255, 156, 101, 0);
		public static Color NeutralBackground { get; } = Color.FromArgb(255, 255, 235, 156);
	}
}
