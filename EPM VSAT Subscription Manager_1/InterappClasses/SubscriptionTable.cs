// Ignore Spelling: EPM VSAT Interapp

namespace EPM_VSAT_Subscription_Manager_1.InterappClasses
{
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;

	public class SubscriptionTable : Message
	{
		public string SubscriptionTableCsv { get; set; }

		public string SubscriptionTableEnum { get; set; }
	}

	public class Flag : Message
	{
		public string FlagMessage { get; set; }

		public string TableEnum { get; set; }
	}
}
