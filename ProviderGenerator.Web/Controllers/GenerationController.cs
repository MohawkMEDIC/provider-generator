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
using ProviderGenerator.Web.Models;
using ProviderGenerator.Web.Models.DataModels;
using ProviderGenerator.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ProviderGenerator.Web.Controllers
{
	public class GenerationController : Controller
	{
		[HttpGet]
		public ActionResult Index()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Generate(GenerationDataModel model)
		{
			if (ModelState.IsValid)
			{
				GenerationService.GenerationServiceClient client = new GenerationService.GenerationServiceClient();

				AsyncManager.OutstandingOperations.Increment();

				Guid sessionId = Guid.NewGuid();

				Task task = Task.Factory.StartNew(() =>
				{
					client.GenerateProviders(new GenerationService.GenerateProvidersRequest
					{
						request = new GenerationService.GenerationRequest
						{
							AgeDistribution = model.AgeDistribution.ToList(),
							DateOfBirthEnd = DateTime.Now,
							DateOfBirthStart = new DateTime(1950, 01, 01),
							GenderDistribution = model.GenderDistribution.ToList(),
							NumberOfRecords = model.NumberOfRecords,
							SessionId = sessionId
						}
					});
				});

				// This is not a self assignment, the first variable "sessionId" is an anonymous object variable
				return RedirectToAction("Session", new { sessionId = sessionId });
			}
			else
			{
				return View(model);
			}
		}

		public ActionResult Session(Guid sessionId)
		{
			SessionViewModel viewModel = new SessionViewModel();

			viewModel.SessionId = sessionId;
			viewModel.ProviderViewModels = new List<ProviderViewModel>();

			TempData["success"] = "Generating data";

			return View(viewModel);
		}
	}
}