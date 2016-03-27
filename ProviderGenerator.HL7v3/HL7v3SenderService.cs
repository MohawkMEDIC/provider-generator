﻿/*
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
using ProviderGenerator.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProviderGenerator.Core.Common;

namespace ProviderGenerator.HL7v3
{
	public class HL7v3SenderService : IHL7v3SenderService
	{
		private IServiceProvider context;

		public IServiceProvider Context
		{
			get
			{
				return this.context;
			}
			set
			{
				this.context = value;
			}
		}

		#region IHL7v3SenderService Members

		public void Send(IEnumerable<Provider> providers)
		{
			foreach (var provider in providers)
			{
				var graphable = EverestUtil.GenerateAddProviderRequest(provider);

				EverestUtil.Sendv3Messages(graphable, "pr");
			}
		}

		public void Send(Provider provider)
		{
		}

		#endregion

	}
}
