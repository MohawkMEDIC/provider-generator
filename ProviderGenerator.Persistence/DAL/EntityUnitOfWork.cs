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
using ProviderGenerator.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProviderGenerator.Persistence.DAL
{
	public class EntityUnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext context;

		private IRepository<Provider> providerRepository;
		private IRepository<Session> sessionRepository;

		#region Repositories

		public IRepository<Provider> ProviderRepository
		{
			get
			{
				if (this.providerRepository == null)
				{
					this.providerRepository = new EntityRepository<Provider>(context);
				}

				return providerRepository;
			}
		}

		public IRepository<Session> SessionRepository
		{
			get
			{
				if (this.sessionRepository == null)
				{
					this.sessionRepository = new EntityRepository<Session>(context);
				}

				return sessionRepository;
			}
		}

		#endregion


		public EntityUnitOfWork()
			: this(new ApplicationDbContext())
		{
		}

		public EntityUnitOfWork(ApplicationDbContext context)
		{
			this.context = context;
		}

		public void Save()
		{
			context.SaveChanges();
		}

		#region IDisposable
		private bool disposed = false;

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion
	}
}