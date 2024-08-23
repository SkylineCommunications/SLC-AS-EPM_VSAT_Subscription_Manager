// Ignore Spelling: EPM VSAT

namespace EPM_VSAT_Subscription_Manager_1.HelperClasses
{
	using System.Collections.Generic;

	public static class Constants
	{
		public static readonly Dictionary<TableType, string> TableProtocolNames = new Dictionary<TableType, string>
		{
			// RDS
			{ TableType.RDS_ENTRIES, "Verizon Reports and Dashboards Solution" },
			{ TableType.RDS_KPI_ENTRIES, "Verizon Reports and Dashboards Solution" },
			{ TableType.RDS_CONFIG_ENTRIES, "Verizon Reports and Dashboards Solution" },
			{ TableType.RDS_DCAT_PROFILES, "Verizon Reports and Dashboards Solution" },
			{ TableType.RDS_DCAT_FUW, "Verizon Reports and Dashboards Solution" },
			{ TableType.RDS_DCAT_METRICS, "Verizon Reports and Dashboards Solution" },
			{ TableType.RDS_DCAT_FAULTS, "Verizon Reports and Dashboards Solution" },

			// DSM SO
			{ TableType.DSM_SO_ES_SATELLITES, "Verizon DSM SO" },
			{ TableType.DSM_SO_ES_SUBSCRIBERS, "Verizon DSM SO" },

			// WM TICKETING
			{ TableType.WM_TICKETING_KPI_CALLBACK, "Verizon WM Ticketing" },
			{ TableType.WM_TICKETING_HETS, "Verizon WM Ticketing" },
			{ TableType.WM_TICKETING_TELEPORT_INFORMATION, "Verizon WM Ticketing" },
			{ TableType.WM_TICKETING_SLA_OVERVIEW, "Verizon WM Ticketing" },
			{ TableType.WM_TICKETING_SLA_EXCEPTIONS, "Verizon WM Ticketing" },
			{ TableType.WM_TICKETING_EVENT_EXCEPTIONS, "Verizon WM Ticketing" },
			{ TableType.WM_TICKETING_FAULT_EXCEPTIONS, "Verizon WM Ticketing" },

			// Skyline EPM VSAT DSM SO
			{ TableType.EPM_DSM_SO_SUBSCRIBERS, "Skyline EPM Platform VSAT DSM SO" },
			{ TableType.EPM_DSM_SO_SATELLITES, "Skyline EPM Platform VSAT DSM SO" },
		};

		public static readonly Dictionary<TableType, string> TableFiles = new Dictionary<TableType, string>
		{
			// RDS
			{ TableType.RDS_ENTRIES, "RDS_ENTRIES.csv" },
			{ TableType.RDS_KPI_ENTRIES, "RDS_KPI_ENTRIES.csv" },
			{ TableType.RDS_CONFIG_ENTRIES, "RDS_CONFIG_ENTRIES.csv" },
			{ TableType.RDS_DCAT_PROFILES, "RDS_DCAT_PROFILES.csv" },
			{ TableType.RDS_DCAT_FUW, "RDS_DCAT_FUW.csv" },
			{ TableType.RDS_DCAT_METRICS, "RDS_DCAT_METRICS.csv" },
			{ TableType.RDS_DCAT_FAULTS, "RDS_DCAT_FAULTS.csv" },

			// DSM SO
			{ TableType.DSM_SO_ES_SATELLITES, "DSM_SO_ES_SATELLITES.csv" },
			{ TableType.DSM_SO_ES_SUBSCRIBERS, "DSM_SO_ES_SUBSCRIBERS.csv" },

			// WM TICKETING
			{ TableType.WM_TICKETING_KPI_CALLBACK, "WM_TICKETING_KPI_CALLBACK.csv" },
			{ TableType.WM_TICKETING_HETS, "WM_TICKETING_HETS.csv" },
			{ TableType.WM_TICKETING_TELEPORT_INFORMATION, "WM_TICKETING_TELEPORT_INFORMATION.csv" },
			{ TableType.WM_TICKETING_SLA_OVERVIEW, "WM_TICKETING_SLA_OVERVIEW.csv" },
			{ TableType.WM_TICKETING_SLA_EXCEPTIONS, "WM_TICKETING_SLA_EXCEPTIONS.csv" },
			{ TableType.WM_TICKETING_EVENT_EXCEPTIONS, "WM_TICKETING_EVENT_EXCEPTIONS.csv" },
			{ TableType.WM_TICKETING_FAULT_EXCEPTIONS, "WM_TICKETING_FAULT_EXCEPTIONS.csv" },

			// Skyline EPM VSAT DSM SO
			{ TableType.EPM_DSM_SO_SUBSCRIBERS, "EPM_DSM_SO_SUBSCRIBERS.csv" },
			{ TableType.EPM_DSM_SO_SATELLITES, "EPM_DSM_SO_SATELLITES.csv" },
		};
	}
}
