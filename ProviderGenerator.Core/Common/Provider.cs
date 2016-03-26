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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.Core.Common
{
	public class Provider
	{
		public Provider()
		{

		}

		public string AddressLine { get; set; }

		public string City { get; set; }

		public DateTime DateOfBirth { get; set; }

		public string Email { get; set; }

		public string FirstName { get; set; }

		public string Gender { get; set; }

		public string Language { get; set; }

		public string LastName { get; set; }

		public string MiddleName { get; set; }

		public string PhoneNo { get; set; }

		public string PostalCode { get; set; }

		public string PractitionerNo { get; set; }

		public string Province { get; set; }
	}
}
