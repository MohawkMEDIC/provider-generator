using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProviderGenerator.Web.Models.DataModels
{
	public class GenerationDataModel
	{
		public GenerationDataModel()
		{
		}

		[Display(Name = "Client Registry")]
		public bool ClientRegistry { get; set; }

		public bool HNS { get; set; }

		public bool OLIS { get; set; }

		[Display(Name = "Provider Registry")]
		public bool ProviderRegistry { get; set; }

		[Display(Name = "Age Distribution")]
		public double[] AgeDistribution { get; set; }

		[Display(Name = "Gender Distribution")]
		public double[] GenderDistribution { get; set; }

		[Display(Name = "Number of Records")]
		public int NumberOfRecords { get; set; }

		[Display(Name = "% of Providers in Organizations")]
		public double ProviderOrganizationPercentage { get; set; }
	}
}