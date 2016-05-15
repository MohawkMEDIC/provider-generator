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