using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.Messaging.Model
{
	[DataContract]
	public class GenerationRequest
	{
		public GenerationRequest()
		{

		}

		[Required]
		[DataMember]
		public DateTime DateOfBirthStart { get; set; }

		[Required]
		[DataMember]
		public DateTime DateOfBirthEnd { get; set; }

		[Required]
		[DataMember]
		public double[] AgeDistribution { get; set; }

		[Required]
		[DataMember]
		public double[] GenderDistribution { get; set; }

		[Required]
		[DataMember]
		public int NumberOfRecords { get; set; }

		[DataMember(IsRequired = true)]
		public Guid SessionId { get; set; }

	}
}
