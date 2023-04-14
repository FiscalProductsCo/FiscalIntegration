using Fiscal.Library.Core;
using Fiscal.Library.Models.InputModels;
using Fiscal.Library.Models.InputModels.Radian.Events.ARInput;
using Fiscal.Library.Models.InputModels.Radian.Events.ViewModels;
using Fiscal.Library.Models.OutputModels.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiscalIntegrationRADIAN
{
    internal class FiscalIntegrationRADIAN
    {
        static async Task Main(string[] args)
        {

            //Se crea el modelo de RADIAN
            BasicStructure basicStructure = new BasicStructure()
            {
                FromHead = new FromHead
                {
                    ID = "",
                    IssueDate = null,
                    ResponseCode = "",
                    ResponseCodeListID = "",
                    OperationType_c = "",
                    CustomizationSchemeID = "",
                    EffectiveDateMandate = null,
                    PublicEffectiveDate = null,
                    Email = "",
                    ConsecutiveTerm = "",
                    Attachment = "",
                    ValidityNote = "",
                    CurrencyCode = "",
                },
                FromSenderTaxScheme = new FromSenderTaxScheme
                {
                    CompanyID = "",
                    Currency1 = "",
                    OrganizationIDType = "",
                    RegistrationName = "",
                    SenderIDType = "",
                    StockAmount1 = 0,
                },
                FromSenderParty = new List<FromSenderParty>
                        {
                            new FromSenderParty
                            {
                                ID = "",
                                SenderIDType = "",
                                RegistrationName = "",
                                OrganizationIDType = "",
                                CompanyLegalFormCode = "",
                                SenderMandateType = "",
                                StockAmount = 0,
                            }

                        },
                FromReceiverTaxScheme = new List<FromReceiverTaxScheme>
                        {
                            new FromReceiverTaxScheme
                            {
                                RegistrationName = "",
                                CompanyID = "",
                                ReceiverIDType = "",
                                OrganizationIDType = "",
                                Currency1 = "",
                                StockAmount1 = 0
                            }
                        },
                FromReceiverParty = new List<FromReceiverParty>
                        {
                            new FromReceiverParty
                            {
                                ID = "",
                                RegistrationName = "",
                                ReceiverIDType = "",
                                OrganizationIDType = "",
                                CompanyLegalFormCode = "",
                                ReceiverMandateType = "",
                                StockAmount = 0,
                            }
                        },
                FromIssuerParty = new List<FromIssuerParty>
                        {
                            new FromIssuerParty
                            {
                                ID = "",
                                Name = "",
                                IdentificationType = "",
                                OrganizationIDType = "",
                                StockAmount = 0,
                            }
                        },
                FromDRIssuerLegalEntity = new List<FromDRIssuerLegalEntity>
                        {
                            new FromDRIssuerLegalEntity
                            {
                                ID = "",
                                Name = "",
                                IdentificationType = "",
                                CompanyType_c = "",
                                Currency1 = "",
                                StockAmount1 = 0,
                            }
                        },
                FromSenderLegalEntity = new List<FromSenderLegalEntity>
                        {
                            new FromSenderLegalEntity
                            {
                                ID = "",
                                Name = "",
                                IdentificationType = "",
                                CompanyType_c = "",
                                Currency1 = "",
                                StockAmount1 = 0,
                            }
                        },
                FromReceiverLegalEntity = new List<FromReceiverLegalEntity>
                        {
                            new FromReceiverLegalEntity
                            {
                                LegalFormCode = "",
                                ID = "",
                                Name = "",
                                IdentificationType = "",
                                CompanyType_c = "",
                                Currency1 = "",
                                StockAmount1 = 0,
                            }
                        },
                FromCustomTagGeneral = new List<FromCustomTagGeneral>
                        {
                            new FromCustomTagGeneral
                            {
                                Name = "",
                                Value = "",
                            }
                        },
                FromDRPerson = new List<FromDRPerson>
                        {
                            new FromDRPerson
                            {
                                ID = "",
                                IssuerIDType = "",
                                FirstName = "",
                                FamilyName = "",
                                JobTitle = "",
                                OrganizationDepartment = "",
                                Nationality = "",
                            }
                        },
                FromSenderPerson = new List<FromSenderPerson>
                        {
                            new FromSenderPerson
                            {
                                ID = "",
                                IdentificationType = "",
                                FirstName = "",
                                FamilyName = "",
                                JobTitle = "",
                                Nationality = "",
                                OrganizationDepartment = "",
                            }
                        },
                FromReceiverPerson = new List<FromReceiverPerson>
                        {
                          new FromReceiverPerson
                          {
                              ID = "",
                              IdentificationType = "",
                              FirstName = "",
                              FamilyName = "",
                              JobTitle = "",
                              Nationality = "",
                              OrganizationDepartment = "",
                          }
                        },
                FromSenderPAttorney = new List<FromSenderPAttorney>
                        {
                            new FromSenderPAttorney
                            {
                                ID = "",
                                IdentificationType = "",
                                TipoMandante = "",
                                Description = "",
                            }
                        },
                FromDRIssuerPAttorney = new List<FromDRIssuerPAttorney>
                        {
                            new FromDRIssuerPAttorney
                            {
                                ID = "",
                                IdentificationType = "",
                                TipoMandante = "",
                                Description = "",
                            }
                        },
                FromDRIssuerPAttorneyPerson = new List<FromDRIssuerPAttorneyPerson>
                        {
                            new FromDRIssuerPAttorneyPerson
                            {
                                ID = "",
                                IssuerIDType = "",
                                FirstName = "",
                                FamilyName = "",
                                JobTitle = "",
                                OrganizationDepartment = "",
                                Nationality = "",
                            }
                        },
                FromDRIssuerTaxScheme = new List<FromDRIssuerTaxScheme>
                        {
                            new FromDRIssuerTaxScheme
                            {
                                ID = "",
                                Name = "",
                                IdentificationType = "",
                                OrganizationIDType = "",
                                StockAmount = 0,
                            }
                        },
                FromDocumentReference = new List<FromDocumentReference>
                        {
                            new FromDocumentReference
                            {
                                LegalNumRef = "",
                                CUFERef = "",
                                DocumentTypeCodeRef = "",
                                StartDate = null,
                                EndDate = null,
                                DescriptionCode = "",
                                Description = "",
                                ScopeMandate = "",

                            }
                        },
                Notes = new List<FromNote>
                        {
                            new FromNote
                            {
                                Note = "",
                            }
                        },
                FromAttachment = new List<FromAttachment>
                        {
                            new FromAttachment
                            {
                                ID = "",
                                DocumentBinary = "",
                                ResponseDescription = "",
                                DocumentDescription = "",
                                EffectiveDate = null,
                            }
                        }
            };


            //Se instancian las clase SendDocument instalada en la libreria la cual posee los métodos de envío 
            //PetitionResponse modelo que retorna el método de envío

            SendDocument sendDIAN = new SendDocument();
            PetitionResponse request = new PetitionResponse();

            //---------------------------------------------RADIAN-----------------------------------------------------//

            //Se realiza el envio del evento con el método Send expuesto por la librería
            request = await sendDIAN.Send<PetitionResponse>(basicStructure, DocumentType.Radian);

            //Se captura el PetitionResponse.Result de la petición
            var resultRequestRadian = request?.result;
        }
    }
}
