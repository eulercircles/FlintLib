using FlintLib.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		private readonly IReadOnlyList<string> _acceptableCustomaryUnitDesignators;
		public IReadOnlyList<string> AcceptableCustomaryUnitDesignators
		{ get { return _acceptableCustomaryUnitDesignators; } }

		private readonly IReadOnlyList<string> _acceptableMetricUnitDesignators;
		public IReadOnlyList<string> AcceptableMetricUnitDesignators
		{ get { return _acceptableMetricUnitDesignators; } }

		public readonly ushort MaxDecimalResolution = 6;

		private InternalResources()
		{
			List<string> customaryDesignators = new List<string>();
			List<string> customaryUnitDescriptions = EnumUtilities.GetEnumDescriptions<CustomaryUnits>().Keys.ToList();
			customaryUnitDescriptions.ForEach(d => customaryDesignators.AddRange(d.Split(',')));
			_acceptableCustomaryUnitDesignators = customaryDesignators;

			List<string> metricDesignators = new List<string>();
			List<string> metricUnitDescriptions = EnumUtilities.GetEnumDescriptions<MetricUnits>().Keys.ToList();
			metricUnitDescriptions.ForEach(d => metricDesignators.AddRange(d.Split(',')));
			_acceptableMetricUnitDesignators = metricDesignators;
		}
	}
}
