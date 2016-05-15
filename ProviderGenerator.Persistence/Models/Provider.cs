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
using ProviderGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.Persistence.Models
{
	[Table("Provider")]
	public class Provider : IPersistable
	{
		public Provider()
		{
		}

		[Required]
		public string AddressLine { get; set; }

		[Required]
		public string City { get; set; }

		[NotMapped]
		public Type ComponentType
		{
			get
			{
				return typeof(Provider);
			}
		}

		[Required]
		public string Country { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		[Required]
		public string Email { get; set; }

		[Required]
		public string FirstName { get; set; }

		[Required]
		public string Gender { get; set; }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[Required]
		public string Language { get; set; }

		[Required]
		public string LastName { get; set; }

		[Required]
		public string MiddleName { get; set; }

		[Required]
		public string PostalCode { get; set; }

		[Required]
		public string PhoneNo { get; set; }

		[Required]
		public string PractitionerNo { get; set; }

		[Required]
		public string Province { get; set; }

		[Required]
		public int SessionId { get; set; }

		[ForeignKey("SessionId")]
		public virtual Session Session { get; set; }
	}
}
