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

using System.Collections.Generic;
using System.Xml.Serialization;

namespace ProviderGenerator.Randomizer.Common
{
	[XmlRoot("CommonData")]
	public class CommonData
	{
		[XmlElement("City")]
		public List<string> Cities { get; set; }

		[XmlElement("FamilyName")]
		public List<string> FamilyNames { get; set; }

		[XmlElement("GivenName")]
		public List<GivenNameGenderPair> GivenNames { get; set; }

		[XmlElement("StreetName")]
		public List<string> StreetNames { get; set; }
	}
}
