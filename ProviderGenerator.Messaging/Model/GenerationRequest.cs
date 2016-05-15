using System;
using System.Collections.Generic;
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

		[DataMember(IsRequired = true)]
		public DateTime DateOfBirthStart { get; set; }

		[DataMember(IsRequired = true)]
		public DateTime DateOfBirthEnd { get; set; }

		[DataMember(IsRequired = true)]
		public double[] AgeDistribution { get; set; }

		[DataMember(IsRequired = true)]
		public double[] GenderDistribution { get; set; }

		[DataMember(IsRequired = true)]
		public int NumberOfRecords { get; set; }

		[DataMember(IsRequired = true)]
		public Guid SessionId { get; set; }

	}
}
