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
using ProviderGenerator.Core;
using ProviderGenerator.Persistence.DAL;
using ProviderGenerator.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.Persistence
{
	public class PersistenceService : IPersistenceService
	{
		private IServiceProvider context;
		private IUnitOfWork unitOfWork;

		public PersistenceService()
		{
			this.unitOfWork = new EntityUnitOfWork(new ApplicationDbContext());
		}

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

		public void Save(Core.Common.IPersistable model)
		{
			// HACK
			if (model.ComponentType == typeof(Session))
			{
				unitOfWork.SessionRepository.Add(model as Session);
			}
			else if (model.ComponentType == typeof(Provider))
			{
				unitOfWork.ProviderRepository.Add(model as Provider);
			}

			unitOfWork.Save();
		}
	}
}
