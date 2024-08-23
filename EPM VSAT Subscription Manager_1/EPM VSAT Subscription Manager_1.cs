/*
****************************************************************************
*  Copyright (c) 2024,  Skyline Communications NV  All Rights Reserved.    *
****************************************************************************

By using this script, you expressly agree with the usage terms and
conditions set out below.
This script and all related materials are protected by copyrights and
other intellectual property rights that exclusively belong
to Skyline Communications.

A user license granted for this script is strictly for personal use only.
This script may not be used in any way by anyone without the prior
written consent of Skyline Communications. Any sublicensing of this
script is forbidden.

Any modifications to this script by the user are only allowed for
personal use and within the intended purpose of the script,
and will remain the sole responsibility of the user.
Skyline Communications will not be responsible for any damages or
malfunctions whatsoever of the script resulting from a modification
or adaptation by the user.

The content of this script is confidential information.
The user hereby agrees to keep this confidential information strictly
secret and confidential and not to disclose or reveal it, in whole
or in part, directly or indirectly to any person, entity, organization
or administration without the prior written consent of
Skyline Communications.

Any inquiries can be addressed to:

	Skyline Communications NV
	Ambachtenstraat 33
	B-8870 Izegem
	Belgium
	Tel.	: +32 51 31 35 69
	Fax.	: +32 51 31 01 29
	E-mail	: info@skyline.be
	Web		: www.skyline.be
	Contact	: Ben Vandenberghe

****************************************************************************
Revision History:

DATE		VERSION		AUTHOR			COMMENTS

23/07/2024	1.0.0.1		LGO, Skyline	Initial version
****************************************************************************
*/

// Ignore Spelling: EPM VSAT
namespace EPM_VSAT_Subscription_Manager_1
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using EPM_VSAT_Subscription_Manager_1.HelperClasses;
	using EPM_VSAT_Subscription_Manager_1.InterappClasses;
	using Skyline.DataMiner.Automation;
	using Skyline.DataMiner.Core.DataMinerSystem.Automation;
	using Skyline.DataMiner.Core.DataMinerSystem.Common;

	/// <summary>
	/// Represents a DataMiner Automation script.
	/// </summary>
	public class Script
	{
		/// <summary>
		/// The script entry point.
		/// </summary>
		/// <param name="engine">Link with SLAutomation process.</param>
		public void Run(IEngine engine)
		{
			try
			{
				RunSafe(engine);
			}
			catch (ScriptAbortException)
			{
				// Catch normal abort exceptions (engine.ExitFail or engine.ExitSuccess)
				throw; // Comment if it should be treated as a normal exit of the script.
			}
			catch (ScriptForceAbortException)
			{
				// Catch forced abort exceptions, caused via external maintenance messages.
				throw;
			}
			catch (ScriptTimeoutException)
			{
				// Catch timeout exceptions for when a script has been running for too long.
				throw;
			}
			catch (InteractiveUserDetachedException)
			{
				// Catch a user detaching from the interactive script by closing the window.
				// Only applicable for interactive scripts, can be removed for non-interactive scripts.
				throw;
			}
			catch (Exception e)
			{
				engine.ExitFail("Run|Something went wrong: " + e);
			}
		}

		private static bool UpdateSubscriptionFile(IEngine engine, string folderPath, string tableRowsCsv, TableType tableTypeEnum)
		{
			if (!Constants.TableFiles.TryGetValue(tableTypeEnum, out var fileName))
			{
				engine.ExitFail("Table Type does not have a file mapped");
				return false;
			}

			if (!Directory.Exists(folderPath))
			{
				Directory.CreateDirectory(folderPath);
			}

			var completePath = $"{folderPath}\\{fileName}";

			// Only allow reading, to avoid conflicts if multiple petitions to update the file (multiple tables call at the same time)
			using (FileStream fs = new FileStream(completePath, FileMode.Create, FileAccess.Write, FileShare.Read))
			{
				using (StreamWriter streamWriter = new StreamWriter(fs))
				{
					streamWriter.Write(tableRowsCsv);
				}
			}

			return true;
		}

		private static string ReadSubscriptionFile(IEngine engine, string folderPath, TableType tableTypeEnum)
		{
			var tableRowsCsv = String.Empty;

			if (!Constants.TableFiles.TryGetValue(tableTypeEnum, out var fileName))
			{
				engine.ExitFail("Table Type does not have a file mapped");
				return null;
			}

			var completePath = $"{folderPath}\\{fileName}";

			// Option 1
			if (!File.Exists(completePath))
			{
				engine.ExitFail("Subscription File does not exists at the path: " + completePath);
				return null;
			}

			// Only allow reading, to avoid conflicts if multiple petitions to update the file (multiple tables call at the same time)
			using (FileStream fs = new FileStream(completePath, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (StreamReader streamReader = new StreamReader(fs))
				{
					tableRowsCsv = streamReader.ReadToEnd();
				}
			}

			return tableRowsCsv;
		}

		private void RunSafe(IEngine engine)
		{
			var folderPath = engine.GetScriptParam(2).Value;
			var tableRowsCsv = engine.GetScriptParam(3).Value;

			if (!Int32.TryParse(engine.GetScriptParam(4).Value, out int tableType))
			{
				engine.ExitFail("Table Type provided is not supported");
				return;
			}

			var tableTypeEnum = (TableType)tableType;

			// if request != -1, means is a change to the table (add, delete, edit rows)
			if(tableRowsCsv != "-1" && UpdateSubscriptionFile(engine, folderPath, tableRowsCsv, tableTypeEnum))
			{
				UpdateAllElements(engine, tableRowsCsv, tableTypeEnum);
			}

			// else, means is a request to get the latest value (sync, no changed needed)
			else
			{
				tableRowsCsv = ReadSubscriptionFile(engine, folderPath, tableTypeEnum);
				if(tableRowsCsv != null)
				{
					UpdateAllElements(engine, tableRowsCsv, tableTypeEnum);
				}
			}
		}

		private void UpdateAllElements(IEngine engine, string tableRowsCsv, TableType tableTypeEnum)
		{
			if (!Constants.TableProtocolNames.TryGetValue(tableTypeEnum, out var protocol))
			{
				engine.ExitFail("Table Type does not have a protocol mapped");
				return;
			}

			var elements = engine.GetDms().GetElements().ToList();
			elements = elements.Where(x => x.Protocol.Name == protocol && x.State == ElementState.Active && x.Protocol.Version == "Production").ToList();

			var tableRows = new SubscriptionTable { SubscriptionTableCsv = tableRowsCsv, SubscriptionTableEnum = Convert.ToString((int)tableTypeEnum) };
			InterappHelper.DistributeInterappMessage(tableRows, elements);
		}
	}
}
