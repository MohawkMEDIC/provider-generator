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
 * User: Nityan
 * Date: 2016-3-26
 */
using MARC.Everest.Interfaces;
using MARC.Everest.RMIM.CA.R020402.Interactions;
using MARC.Everest.RMIM.UV.NE2008.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.HL7v3
{
	internal static class EverestUtil
	{
		internal static IGraphable GenerateAddProviderRequest()
		{
			return null;
		}

		private static IGraphable GenerateCanadianRequest()
		{
			PRPM_IN301010CA message = new PRPM_IN301010CA
			{

			};

			return message;
		}

		private static IGraphable GenerateUniversalRequest()
		{
			PRPM_IN301010UV01 message = new PRPM_IN301010UV01
			{

			};

			return message;
		}
	}
}
