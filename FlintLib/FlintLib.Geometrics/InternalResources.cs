using System.Linq;
using System.Collections.Generic;

using FlintLib.Common;

namespace FlintLib.Geometrics
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

		private readonly IReadOnlyList<string> _acceptableImperialUnitDesignators;
		public IReadOnlyList<string> AcceptableImperialUnitDesignators
		{ get { return _acceptableImperialUnitDesignators; } }

		private readonly IReadOnlyList<string> _acceptableMetricUnitDesignators;
		public IReadOnlyList<string> AcceptableMetricUnitDesignators
		{ get { return _acceptableMetricUnitDesignators; } }

		public readonly ushort MaxDecimalResolution = 6;

		private InternalResources()
		{
			List<string> imperialDesignators = new List<string>();
			List<string> imperialUnitDescriptions = EnumUtilities.GetEnumDescriptions<ImperialUnits>().Keys.ToList();
			imperialUnitDescriptions.ForEach(d => imperialDesignators.AddRange(d.Split(',')));
			_acceptableImperialUnitDesignators = imperialDesignators;

			List<string> metricDesignators = new List<string>();
			List<string> metricUnitDescriptions = EnumUtilities.GetEnumDescriptions<MetricUnits>().Keys.ToList();
			metricUnitDescriptions.ForEach(d => metricDesignators.AddRange(d.Split(',')));
			_acceptableMetricUnitDesignators = metricDesignators;
		}
	}
}
