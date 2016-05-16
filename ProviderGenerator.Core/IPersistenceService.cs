/*
 * Copyright 2016-2016 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: khannan
 * Date: 2016-5-15
 */
using MARC.HI.EHRS.SVC.Core.Services;
using ProviderGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.Core
{
	public interface IPersistenceService : IUsesHostContext
	{
		/// <summary>
		/// Gets a list of providers for a given session id.
		/// </summary>
		/// <param name="sessionId">The id of the session.</param>
		/// <returns>Returns a list of providers generated with the given session id.</returns>
		IEnumerable<Provider> GetProviders(Guid sessionId);

		/// <summary>
		/// Saves any pending changes to the database.
		/// </summary>
		/// <returns>Returns true if saved successfully.</returns>
		void Save(IPersistable model);
	}
}
