using System;
using static FLib.Mathematics.Functions;

namespace FLib.Presentation
{
	public static class ColorUtilities
	{
		public static void HsvToRgb(double hue, double saturation, double value,
			out byte red, out byte green, out byte blue)
		{
			double H = hue;
			while (H < 0) { H += 360; }
			while (H >= 360) { H -= 360; }

			double R, G, B;
			if (value <= 0) { R = G = B = 0; }
			else if (saturation <= 0) { R = G = B = 0; }
			else
			{
				double hf = H / 60.0;
				int i = (int)Math.Floor(hf);
				double f = hf - i;
				double pv = value * (1 - saturation);
				double qv = value * (1 - saturation * f);
				double tv = value * (1 - saturation * (1 - f));

				switch (i)
				{
					// Red is the dominant color
					case 0:
						R = value;
						G = tv;
						B = pv;
						break;

					// Green is the dominant color
					case 1:
						R = qv;
						G = value;
						B = pv;
						break;
					case 2:
						R = pv;
						G = value;
						B = tv;
						break;

					// Blue is the dominant color
					case 3:
						R = pv;
						G = qv;
						B = value;
						break;
					case 4:
						R = tv;
						G = pv;
						B = value;
						break;

					// Red is the dominant color
					case 5:
						R = value;
						G = pv;
						B = qv;
						break;

					// Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.
					case 6:
						R = value;
						G = tv;
						B = pv;
						break;
					case -1:
						R = value;
						G = pv;
						B = qv;
						break;

					// The color is not defined, we should throw an error.
					default:
						//LFATAL("i Value error in Pixel conversion, Value is %d", i);
						R = G = B = value; // Just pretend its black/white
						break;
				}
			}

			red = ByteClamp((int)(R * 255.0));
			green = ByteClamp((int)(G * 255.0));
			blue = ByteClamp((int)(B * 255.0));
		}
	}
}
