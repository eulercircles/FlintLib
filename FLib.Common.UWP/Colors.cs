using Windows.UI;

namespace FlintLib.Common
{
	public static class Colors
	{
		public static Color GoodForeground { get { return Color.FromArgb(255, 0, 97, 0); } }
		public static Color GoodBackground { get { return Color.FromArgb(255, 198, 239, 206); } }

		public static Color BadForeground { get { return Color.FromArgb(255, 156, 0, 6); } }
		public static Color BadBackground { get { return Color.FromArgb(255, 255, 199, 206); } }

		public static Color NeutralForeground { get { return Color.FromArgb(255, 156, 101, 0); } }
		public static Color NeutralBackground { get { return Color.FromArgb(255, 255, 235, 156); } }
	}
}
