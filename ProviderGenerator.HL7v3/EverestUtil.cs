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
 * User: Nityan
 * Date: 2016-3-26
 */
using MARC.Everest.Connectors;
using MARC.Everest.Connectors.WCF;
using MARC.Everest.DataTypes;
using MARC.Everest.Formatters.XML.Datatypes.R1;
using MARC.Everest.Formatters.XML.ITS1;
using MARC.Everest.Interfaces;
using MARC.Everest.RMIM.CA.R020402.Interactions;
using MARC.Everest.RMIM.UV.NE2008.Interactions;
using MARC.Everest.Xml;
using ProviderGenerator.Core.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProviderGenerator.HL7v3
{
	internal static class EverestUtil
	{
		internal static IGraphable GenerateAddProviderRequest(Provider provider)
		{
			return GenerateCanadianRequest(provider);
		}

		private static AD CreateAddress(Provider provider)
		{
			AD address = new AD(PostalAddressUse.PrimaryHome, new List<ADXP>
			{
				new ADXP
				{
					Type = AddressPartType.City,
					Value = provider.City
				},
				new ADXP
				{
					Type = AddressPartType.Country,
					Value = "Canada"
				},
				new ADXP
				{
					Type = AddressPartType.PostalCode,
					Value = provider.PostalCode
				},
				new ADXP
				{
					Type = AddressPartType.StreetAddressLine,
					Value = provider.AddressLine
				}
			});

			return address;
		}

		private static MARC.Everest.RMIM.CA.R020402.Vocabulary.AdministrativeGender CreateGender(Provider provider)
		{
			return provider.Gender == "M" ? MARC.Everest.RMIM.CA.R020402.Vocabulary.AdministrativeGender.Male : MARC.Everest.RMIM.CA.R020402.Vocabulary.AdministrativeGender.Female;
		}

		private static PN CreateName(Provider provider)
		{
			PN personName = new PN(new List<ENXP>
			{
				new ENXP
				{
					Type = EntityNamePartType.Family,
					Value = provider.LastName
				},
				new ENXP
				{
					Type = EntityNamePartType.Given,
					Value = provider.FirstName,
				},
				new ENXP
				{
					Type = EntityNamePartType.Given,
					Value = provider.MiddleName
				}
			});

			return personName;
		}

		private static IGraphable GenerateCanadianRequest(Provider provider)
		{
			PRPM_IN301010CA message = new PRPM_IN301010CA
			{
				AcceptAckCode = new CS<MARC.Everest.RMIM.CA.R020402.Vocabulary.AcknowledgementCondition>
				{
					Code = new MARC.Everest.DataTypes.Primitives.CodeValue<MARC.Everest.RMIM.CA.R020402.Vocabulary.AcknowledgementCondition>(MARC.Everest.RMIM.CA.R020402.Vocabulary.AcknowledgementCondition.Never)
				},
				controlActEvent = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700711CA.ControlActEvent<MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.RoleChoice>
				{
					Author = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700751CA.Author
					{
						AuthorPerson = new MARC.Everest.RMIM.CA.R020402.COCT_MT090102CA.AssignedEntity
						{
							AssignedPerson = new MARC.Everest.RMIM.CA.R020402.COCT_MT090102CA.Person
							{
								Name = new PN(EntityNameUse.Legal, new List<ENXP>
								 {
									 new ENXP
									 {
										 Type = EntityNamePartType.Family,
										 Value = "Khanna"
									 },
									 new ENXP
									 {
										 Type = EntityNamePartType.Given,
										 Value = "Nityan"
									 }
								 })
							},
							Id = new SET<II>
							 {
								 new II("1.3.6.1.4.1.33349.3.1.3.201203.1.0", "1234")
							 }
						},
						Time = new TS(DateTime.Now)
					},
					Code = PRPM_IN301010CA.GetTriggerEvent(),
					EffectiveTime = new IVL<TS>(new TS(DateTime.Now)),
					Id = new II(Guid.NewGuid()),
					Subject = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700711CA.Subject2<MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.RoleChoice>
					{
						ContextConductionInd = new BL(true),
						RegistrationRequest = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700711CA.RegistrationRequest<MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.RoleChoice>
						{
							Subject = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700711CA.Subject4<MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.RoleChoice>
							{
								registeredRole = PRPM_IN301010CA.CreateAssignedEntity(
									new II
									{
										Displayable = true,
										Root = "1.3.6.1.4.1.33349.3.1.6.2016.03.27.1",
										Extension = "12384" + new Random().Next(100, 10000)
									},
									new CV<MARC.Everest.RMIM.CA.R020402.Vocabulary.AssignedRoleType>(MARC.Everest.RMIM.CA.R020402.Vocabulary.AssignedRoleType.StaffPhysician),
									new LIST<PN>
									{
										CreateName(provider)
									},
									new LIST<AD>
									{
										CreateAddress(provider)
									},
									new LIST<TEL>
									{
										new TEL(provider.PhoneNo)
									},
									new CS<MARC.Everest.RMIM.CA.R020402.Vocabulary.RoleStatus>
									{
										Code = new MARC.Everest.DataTypes.Primitives.CodeValue<MARC.Everest.RMIM.CA.R020402.Vocabulary.RoleStatus>(MARC.Everest.RMIM.CA.R020402.Vocabulary.RoleStatus.Active)
									},
									new IVL<TS>
									{
										Value = new TS(DateTime.Now)
									},
									new MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.PrincipalPerson
									{
										AdministrativeGenderCode = new CV<MARC.Everest.RMIM.CA.R020402.Vocabulary.AdministrativeGender>(CreateGender(provider)),
										Birthplace = new MARC.Everest.RMIM.CA.R020402.PRPM_MT303010CA.Birthplace
										{
											Addr = new AD(PostalAddressUse.Public, new List<ADXP>
											{
												new ADXP
												{
													Type = AddressPartType.AddressLine,
													Value = "200 Elizabeth Street"
												},
												new ADXP
												{
													Type = AddressPartType.City,
													Value = "Toronto"
												},
												new ADXP
												{
													Type = AddressPartType.State,
													Value = "Ontario"
												},
												new ADXP
												{
													Type = AddressPartType.Country,
													Value = "Canada"
												},
												new ADXP
												{
													Type = AddressPartType.PostalCode,
													Value = "M5G 2C4"
												}
											})
										},
										BirthTime = new TS(provider.DateOfBirth),
										DeceasedInd = new BL(false),
										Id = new II
										{
											Displayable = true,
											; ; Extension = Guid.NewGuid().ToString(),
											Root = Guid.NewGuid().ToString()
										},
										LanguageCommunication = new List<MARC.Everest.RMIM.CA.R020402.PRPM_MT303010CA.LanguageCommunication>
										{
											new MARC.Everest.RMIM.CA.R020402.PRPM_MT303010CA.LanguageCommunication
											{
												LanguageCode = new CV<string>("en")
											},
											new MARC.Everest.RMIM.CA.R020402.PRPM_MT303010CA.LanguageCommunication
											{
												LanguageCode = "fr"
											}
										},
										Name = new LIST<PN>
										{
											new PN(EntityNameUse.Legal, new LIST<ENXP>
											{
												new ENXP
												{
													Type = EntityNamePartType.Family,
													Value = "Khanna"
												},
												new ENXP
												{
													Type = EntityNamePartType.Given,
													Value = "Nityan"
												},
												new ENXP
												{
													Type = EntityNamePartType.Delimiter,
													Value = "Dave"
												},
												new ENXP
												{
													Type = EntityNamePartType.Delimiter,
													Value = "Paul"
												},
												new ENXP
												{
													Qualifier = new SET<CS<EntityNamePartQualifier>>(new CS<EntityNamePartQualifier>(EntityNamePartQualifier.Suffix)),
													Value = "M.D."
												}
											})
										}
									},
									new MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.PrimaryPerformer3
									{
										NullFlavor = NullFlavor.NoInformation
									}
								)
							},
							Custodian = new MARC.Everest.RMIM.CA.R020402.REPC_MT000007CA.Custodian
							{
								AssignedDevice = new MARC.Everest.RMIM.CA.R020402.COCT_MT090310CA.AssignedDevice
								{
									AssignedRepository = new MARC.Everest.RMIM.CA.R020402.COCT_MT090310CA.Repository
									{
										Name = "KNG"
									},
									Id = new II("2.16.840.1.113883.3.239.18.61", Guid.NewGuid().ToString("N")),
									RepresentedRepositoryJurisdiction = new MARC.Everest.RMIM.CA.R020402.COCT_MT090310CA.RepositoryJurisdiction
									{
										Name = new ST
										{
											Language = "eng",
											Value = "KGHD",
										}
									}
								}
							}
						}
					}
				},
				CreationTime = new TS(DateTime.Now),
				Id = new II(Guid.NewGuid()),
				InteractionId = PRPM_IN301010CA.GetInteractionId(),
				ProcessingCode = new CS<MARC.Everest.RMIM.CA.R020402.Vocabulary.ProcessingID>(MARC.Everest.RMIM.CA.R020402.Vocabulary.ProcessingID.Production),
				ProfileId = PRPM_IN301010CA.GetProfileId(),
				RealmCode = new SET<CS<string>>(new CS<string>("CA")),
				Receiver = new MARC.Everest.RMIM.CA.R020402.MCCI_MT002200CA.Receiver
				{
					Device = new MARC.Everest.RMIM.CA.R020402.MCCI_MT002200CA.Device2
					{
						Id = new II("1.3.6.1.4.1.33349.3.1.6.2016.03.06.1", "PR1")
					}
				},
				ResponseModeCode = new CS<MARC.Everest.RMIM.CA.R020402.Vocabulary.ResponseMode>(MARC.Everest.RMIM.CA.R020402.Vocabulary.ResponseMode.Immediate),
				Sender = new MARC.Everest.RMIM.CA.R020402.MCCI_MT002200CA.Sender
				{
					Device = new MARC.Everest.RMIM.CA.R020402.MCCI_MT002200CA.Device1
					{
						Id = new II("1.3.6.1.4.1.33349.3.1.99.0", "Nityan-PC")
					}
				}
			};

			return message;
		}

		private static IGraphable GenerateUniversalRequest()
		{
			PRPM_IN301010UV01 message = new PRPM_IN301010UV01
			{
				AcceptAckCode = new CS<MARC.Everest.RMIM.UV.NE2008.Vocabulary.AcknowledgementCondition>
				{
					Code = new MARC.Everest.DataTypes.Primitives.CodeValue<MARC.Everest.RMIM.UV.NE2008.Vocabulary.AcknowledgementCondition>(MARC.Everest.RMIM.UV.NE2008.Vocabulary.AcknowledgementCondition.Never)
				},
				controlActProcess = null,
				CreationTime = new TS(DateTime.Now),
				Id = new II(Guid.NewGuid()),
				InteractionId = PRPM_IN301010UV01.GetInteractionId(),
				ProcessingCode = new CS<MARC.Everest.RMIM.UV.NE2008.Vocabulary.ProcessingID>(MARC.Everest.RMIM.UV.NE2008.Vocabulary.ProcessingID.Production),
				//ProfileId = PRPM_IN301010UV01.GetProfileId(),
				RealmCode = new SET<CS<string>>(new CS<string>("UV")),
				Receiver = new List<MARC.Everest.RMIM.UV.NE2008.MCCI_MT100200UV01.Receiver>
				{
					new MARC.Everest.RMIM.UV.NE2008.MCCI_MT100200UV01.Receiver
					{
						Device = new MARC.Everest.RMIM.UV.NE2008.MCCI_MT100200UV01.Device
						{
							Id = new SET<II>
							{
								new II("", "")
							}
						}
					}
				},
				Sender = new MARC.Everest.RMIM.UV.NE2008.MCCI_MT100200UV01.Sender
				{
					Device = new MARC.Everest.RMIM.UV.NE2008.MCCI_MT100200UV01.Device
					{
						Id = new SET<II>
						{
							new II("", "")
						}
					}
				}
			};

			return message;
		}

		/// <summary>
		/// Logs an IGraphable message.
		/// </summary>
		/// <param name="graphable">The IGraphable message to log.</param>
		internal static void LogGraphable(IGraphable graphable)
		{
			XmlWriter writer = null;

			XmlIts1Formatter formatter = new XmlIts1Formatter
			{
				ValidateConformance = false
			};

			DatatypeFormatter dtf = new DatatypeFormatter();

			formatter.GraphAides.Add(dtf);

			StringBuilder sb = new StringBuilder();

			writer = XmlWriter.Create(sb, new XmlWriterSettings() { Indent = true, OmitXmlDeclaration = true });

			XmlStateWriter stateWriter = new XmlStateWriter(writer);

			var result = formatter.Graph(stateWriter, graphable);

			stateWriter.Flush();

			Trace.TraceInformation(sb.ToString());
		}

		/// <summary>
		/// Send HL7v3 messages to a specified endpoint.
		/// </summary>
		/// <param name="epName">The endpoint name.</param>
		internal static bool Sendv3Messages(IGraphable graphable, string endpointName)
		{
			bool retVal = true;

			WcfClientConnector client = new WcfClientConnector(string.Format("endpointName={0}", endpointName));

			XmlIts1Formatter formatter = new XmlIts1Formatter
			{
				ValidateConformance = true
			};

			client.Formatter = formatter;
			client.Formatter.GraphAides.Add(new DatatypeFormatter());

			client.Open();

			var sendResult = client.Send(graphable);

#if DEBUG
			Trace.TraceInformation("Sending HL7v3 message to endpoint: " + client.ConnectionString);
			LogGraphable(graphable);
#endif

			if (sendResult.Code != ResultCode.Accepted && sendResult.Code != ResultCode.AcceptedNonConformant)
			{
				Trace.TraceError("Send result: " + Enum.GetName(typeof(ResultCode), sendResult.Code));
				retVal = false;

				// show send result errors
				foreach (var detail in sendResult.Details.Where(x => x.Type == ResultDetailType.Error))
				{
					Trace.TraceError(detail.Message);
					Console.WriteLine(Environment.NewLine);
					Trace.TraceError(detail.Location);
					Console.WriteLine(Environment.NewLine);

					if (detail.Exception != null)
					{
						Trace.TraceError(detail.Exception.StackTrace);
					}
				}
			}

			var recvResult = client.Receive(sendResult);

			if (recvResult.Code != ResultCode.Accepted && recvResult.Code != ResultCode.AcceptedNonConformant)
			{
				Trace.TraceError("Receive result: " + Enum.GetName(typeof(ResultCode), recvResult.Code));
				retVal = false;

				// show receive result errors
				foreach (var detail in recvResult.Details.Where(x => x.Type == ResultDetailType.Error))
				{
					Trace.TraceError(detail.Message);

					if (detail.Exception != null)
					{
						Trace.TraceError(detail.Exception.StackTrace);
					}
				}
			}

			var result = recvResult.Structure;

			if (result == null)
			{
				Trace.TraceError("Receive result structure is null");
				retVal = false;
			}

			client.Close();

#if DEBUG
			LogGraphable(recvResult.Structure);
#endif

			return retVal;
		}
	}
}
