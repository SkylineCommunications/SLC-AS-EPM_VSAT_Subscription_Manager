// Ignore Spelling: EPM VSAT

namespace EPM_VSAT_Subscription_Manager_1.HelperClasses
{
	using System.Collections.Generic;

	public static class Constants
	{
		public static readonly Dictionary<TableType, string> TableProtocolNames = new Dictionary<TableType, string>
		{
			// Skyline EPM VSAT DSM SO
			{ TableType.EPM_DSM_SO_SUBSCRIBERS, "Skyline EPM Platform VSAT DSM SO" },
			{ TableType.EPM_DSM_SO_SATELLITES, "Skyline EPM Platform VSAT DSM SO" },
		};

		public static readonly Dictionary<TableType, string> TableFiles = new Dictionary<TableType, string>
		{
			// Skyline EPM VSAT DSM SO
			{ TableType.EPM_DSM_SO_SUBSCRIBERS, "EPM_DSM_SO_SUBSCRIBERS.csv" },
			{ TableType.EPM_DSM_SO_SATELLITES, "EPM_DSM_SO_SATELLITES.csv" },
		};
	}
}
