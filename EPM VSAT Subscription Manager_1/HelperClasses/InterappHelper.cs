// Ignore Spelling: EPM VSAT Interapp Pid

namespace EPM_VSAT_Subscription_Manager_1.HelperClasses
{
	using System;
	using System.Collections.Generic;
	using EPM_VSAT_Subscription_Manager_1.InterappClasses;
	using Skyline.DataMiner.Core.DataMinerSystem.Common;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallBulk;
	using Skyline.DataMiner.Core.InterAppCalls.Common.CallSingle;
	using Skyline.DataMiner.Core.InterAppCalls.Common.Shared;
	using SLEngine = Skyline.DataMiner.Automation.Engine;

	public static class InterappHelper
	{
		private const int InterappReceiverPid = 9000000;
		private const int InterappReturnPid = 9000001;

		private static readonly List<Type> KnownTypes = new List<Type>
		{
			typeof(SubscriptionTable),
			typeof(Flag),
		};

		public static void DistributeInterappMessage<T>(T message, List<IDmsElement> elements) where T : Message
		{
			foreach(var element in elements)
			{
				SendInterappMessage(message, element);
			}
		}

		private static void SendInterappMessage<T>(T message, IDmsElement element) where T : Message
		{
			IInterAppCall command = InterAppCallFactory.CreateNew();

			command.Messages.Add(message);
			command.Source = new Source("EPM VSAT Subscriber Manager");
			command.ReturnAddress = new ReturnAddress(element.Host.Id, element.Id, InterappReturnPid);
			command.Send(SLEngine.SLNetRaw, element.Host.Id, element.Id, InterappReceiverPid, KnownTypes);
		}
	}
}
