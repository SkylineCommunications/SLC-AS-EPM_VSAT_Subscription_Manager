﻿// Ignore Spelling: EPM VSAT

namespace EPM_VSAT_Subscription_Manager_1.HelperClasses
{
    public enum TableType
    {
        // DSM SO
        DSM_SO_ES_SUBSCRIBERS,
        DSM_SO_ES_SATELLITES,

        // RDS
        RDS_ENTRIES,
        RDS_KPI_ENTRIES,
        RDS_CONFIG_ENTRIES,
        RDS_DCAT_PROFILES,
        RDS_DCAT_FUW,
        RDS_DCAT_METRICS,
        RDS_DCAT_FAULTS,

        // WM TICKETING
        WM_TICKETING_KPI_CALLBACK,
        WM_TICKETING_HETS,
        WM_TICKETING_TELEPORT_INFORMATION,
        WM_TICKETING_SLA_OVERVIEW,
        WM_TICKETING_SLA_EXCEPTIONS,
        WM_TICKETING_FAULT_EXCEPTIONS,
        WM_TICKETING_EVENT_EXCEPTIONS,

        // Skyline EPM VSAT DSM SO
        EPM_DSM_SO_SUBSCRIBERS,
        EPM_DSM_SO_SATELLITES,

        // CA Interface
        CA_DATA_SUBSCRIPTION,
        CA_PROCESS_PROFILE,
        CA_SUBSCRIPTION_EXCEPTIONS,
    }
}
