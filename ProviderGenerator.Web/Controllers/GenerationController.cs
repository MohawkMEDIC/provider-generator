using ProviderGenerator.Web.Models.DataModels;
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
		// GET: Generation
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Generate(GenerationDataModel model)
		{
			if (ModelState.IsValid)
			{
				GenerationService.GenerationServiceClient client = new GenerationService.GenerationServiceClient();

				AsyncManager.OutstandingOperations.Increment();

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
							NumberOfRecords = model.NumberOfRecords
						}
					});
				});

				return RedirectToAction("Session");
			}
			else
			{
				return View(model);
			}
		}
	}
}