using System.Linq;
using System.Collections.Generic;

using FLib.Common;

namespace FLib.Geometrics
{
	internal class InternalResources
	{
		private static InternalResources _instance;
		internal static InternalResources Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new InternalResources();
				}

				return _instance;
			}
		}

		public IReadOnlyList<string> AcceptableCustomaryUnitDesignators { get; }
		public IReadOnlyList<string> AcceptableMetricUnitDesignators { get; }

		public readonly ushort MaxDecimalResolution = 6;

		private InternalResources()
		{
			List<string> customaryDesignators = new List<string>();
			List<string> customaryUnitDescriptions = EnumUtilities.GetEnumDescriptions<CustomaryUnits>().Keys.ToList();
			customaryUnitDescriptions.ForEach(d => customaryDesignators.AddRange(d.Split(',')));
			AcceptableCustomaryUnitDesignators = customaryDesignators;

			List<string> metricDesignators = new List<string>();
			List<string> metricUnitDescriptions = EnumUtilities.GetEnumDescriptions<MetricUnits>().Keys.ToList();
			metricUnitDescriptions.ForEach(d => metricDesignators.AddRange(d.Split(',')));
			AcceptableMetricUnitDesignators = metricDesignators;
		}
	}
}
