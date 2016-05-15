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
using MARC.HI.EHRS.SVC.Core;
using ProviderGenerator.Core;
using ProviderGenerator.Core.Common;
using ProviderGenerator.Messaging.Model;
using ProviderGenerator.Messaging.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.Messaging.MessageReceiver
{
	/// <summary>
	/// Provides operations to generate providers.
	/// </summary>
	public class GenerationService : IGenerationService, IDisposable
	{
		private HostContext context;

		private IHL7v3SenderService hl7v3SenderService;
		private IRandomizerService randomizerService;

		/// <summary>
		/// Initializes a new instance of the GenerationService class.
		/// </summary>
		public GenerationService()
		{
			context = new HostContext();
			ApplicationContext.Context = context;

			hl7v3SenderService = context.GetService(typeof(IHL7v3SenderService)) as IHL7v3SenderService;
			randomizerService = context.GetService(typeof(IRandomizerService)) as IRandomizerService;
		}

		#region IGenerationService Members

		public GenerationResponse GenerateProviders(GenerationRequest request)
		{
			GenerationResponse response = new GenerationResponse();

			List<Provider> providers = new List<Provider>();

			for (int i = 0; i < request.NumberOfRecords; i++)
			{
				providers.Add(randomizerService.GetRandomProvider());
			}

			hl7v3SenderService.Send(providers);

			return response;
		}

		public async Task<GenerationResponse> GenerateProvidersAsync(int count)
		{
			GenerationResponse response = new GenerationResponse();

			return response;
		}

		#endregion IGenerationService Members

		#region IDisposable Support

		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					context.Dispose();
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~GenerationService() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}

		#endregion IDisposable Support
	}
}
