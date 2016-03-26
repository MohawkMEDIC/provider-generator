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
using ProviderGenerator.Core.Common;
using ProviderGenerator.Randomizer.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.Randomizer
{
	public class RandomizerService : RandomizerBase<CommonData>, IRandomizerService
	{
		private Random random = new Random();
		private CommonData commonData;
		private IServiceProvider context;

		public RandomizerService()
		{
			commonData = LoadData(ConfigurationManager.AppSettings["CommonFile"]);
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

		public Provider GetRandomProvider()
		{
			GivenNameGenderPair nameGenderPair = commonData.GivenNames[random.Next(commonData.GivenNames.Count - random.Next(1, commonData.GivenNames.Count))];

			string firstName = nameGenderPair.Name;
			string middleName = commonData.GivenNames[random.Next(commonData.GivenNames.Count)].Name;
			string lastName = commonData.FamilyNames[random.Next(commonData.FamilyNames.Count - random.Next(1, commonData.FamilyNames.Count))];

			string postal = null;

			for (int i = 0; i < 6; i++)
			{
				if (i % 2 == 0)
					postal += (char)((byte)'A' + random.Next(20));
				else
					postal += random.Next(10).ToString();
				if (i == 2)
					postal += '-';
			}

			Provider provider = new Provider
			{
				AddressLine = random.Next(400).ToString("##0") + " " + commonData.StreetNames[random.Next(commonData.StreetNames.Count)],
				City = commonData.Cities[random.Next(commonData.Cities.Count)],
				DateOfBirth = new DateTime(random.Next(1950, 1990), random.Next(1, 11), random.Next(1, 28)),
				Email = firstName + "." + lastName + random.Next(1000) + "@example.com",
				FirstName = firstName,
				Gender = nameGenderPair.GenderCode,
				Language = "eng",
				LastName = lastName,
				MiddleName = middleName,
				PhoneNo = "905575" + random.Next(1000, 9999),
				PostalCode = postal,
				PractitionerNo = random.Next(10000, 999999).ToString(),
				Province = "Ontario",
			};

			Trace.TraceInformation(provider.FirstName + " " + provider.LastName + " " + provider.DateOfBirth.ToString("yyyy-MM-dd") + " " + provider.PractitionerNo);

			return provider;
		}
	}
}
