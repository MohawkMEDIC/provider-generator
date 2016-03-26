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
using MARC.Everest.DataTypes;
using MARC.Everest.Interfaces;
using MARC.Everest.RMIM.CA.R020402.Interactions;
using MARC.Everest.RMIM.UV.NE2008.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProviderGenerator.HL7v3
{
	internal static class EverestUtil
	{
		internal static IGraphable GenerateAddProviderRequest()
		{
			return null;
		}

		private static IGraphable GenerateCanadianRequest()
		{
			PRPM_IN301010CA message = new PRPM_IN301010CA
			{
				AcceptAckCode = new CS<MARC.Everest.RMIM.CA.R020402.Vocabulary.AcknowledgementCondition>
				{
					Code = new MARC.Everest.DataTypes.Primitives.CodeValue<MARC.Everest.RMIM.CA.R020402.Vocabulary.AcknowledgementCondition>(MARC.Everest.RMIM.CA.R020402.Vocabulary.AcknowledgementCondition.Never)
				},
				controlActEvent = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700711CA.ControlActEvent<MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.RoleChoice>
				{
					Author = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700751CA.Author(),
					EffectiveTime = new IVL<TS>(new TS(DateTime.Now)),
					Id = new II(Guid.NewGuid()),
					Subject = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700711CA.Subject2<MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.RoleChoice>
					{
						RegistrationRequest = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700711CA.RegistrationRequest<MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.RoleChoice>
						{
							Subject = new MARC.Everest.RMIM.CA.R020402.MFMI_MT700711CA.Subject4<MARC.Everest.RMIM.CA.R020402.PRPM_MT301010CA.RoleChoice>
							{
								registeredRole = PRPM_IN301010CA.CreateAssignedEntity(
									new II
									{
										Displayable = true,
										Root = "1.3.6.1.4.1.33349.4.100.1.1",
										Extension = "19872639213"
									},
									new CV<MARC.Everest.RMIM.CA.R020402.Vocabulary.AssignedRoleType>(MARC.Everest.RMIM.CA.R020402.Vocabulary.AssignedRoleType.StaffPhysician),
									new LIST<PN>
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
												Type = EntityNamePartType.Given,
												Value = "Dave"
											},
											new ENXP
											{
												Type = EntityNamePartType.Given,
												Value = "Paul"
											},
											new ENXP
											{
												Qualifier = new SET<CS<EntityNamePartQualifier>>(new CS<EntityNamePartQualifier>(EntityNamePartQualifier.Suffix)),
												Value = "M.D."
											}
										})
									},
									new LIST<AD>
									{
										new AD(PostalAddressUse.WorkPlace, new List<ADXP>
										{
											new ADXP
											{
												Type = AddressPartType.AddressLine,
												Value = "711 Concession St"
											},
											new ADXP
											{
												Type = AddressPartType.City,
												Value = "Hamilton"
											},
											new ADXP
											{
												Type = AddressPartType.Country,
												Value = "Canada"
											},
											new ADXP
											{
												Type = AddressPartType.PostalCode,
												Value = "L8V 1C3"
											}
										})
									},
									new LIST<TEL>
									{
										new TEL("905 521 2100")
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
										AdministrativeGenderCode = new CV<MARC.Everest.RMIM.CA.R020402.Vocabulary.AdministrativeGender>(MARC.Everest.RMIM.CA.R020402.Vocabulary.AdministrativeGender.Undifferentiated),
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
										BirthTime = new TS(new DateTime(1965, 03, 05, 11, 23, 09), DatePrecision.Full),
										DeceasedInd = new BL(false),
										Id = new II
										{
											Displayable = true,
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
						Id = new II("", "")
					}
				},
				ResponseModeCode = new CS<MARC.Everest.RMIM.CA.R020402.Vocabulary.ResponseMode>(MARC.Everest.RMIM.CA.R020402.Vocabulary.ResponseMode.Immediate),
				Sender = new MARC.Everest.RMIM.CA.R020402.MCCI_MT002200CA.Sender
				{
					Device = new MARC.Everest.RMIM.CA.R020402.MCCI_MT002200CA.Device1
					{
						Id = new II("", "")
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
	}
}
