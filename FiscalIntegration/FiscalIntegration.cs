using Fiscal.Library.Core;
using Fiscal.Library.Models.InputModels;
using Fiscal.Library.Models.InputModels.NE;
using Fiscal.Library.Models.InputModels.Radian.Events.ARInput;
using Fiscal.Library.Models.InputModels.Radian.Events.ViewModels;
using Fiscal.Library.Models.OutputModels.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FiscalIntegrationNC
{
    public class FiscalIntegrationNC
    {
        static async Task Main(string[] args)
        {

            //Se crean los modelos de Nomina y Radian
            DocumentoNomina documentoNomina = new DocumentoNomina()
            {
                empleador = new Empleador()
                {
                    razonSocial = "",
                    primerApellido = "",
                    segundoApellido = "",
                    primerNombre = "",
                    otrosNombres = "",
                    nit = "",
                    dv = "",
                    pais = "",
                    departamentoEstado = "",
                    municipioCiudad = "",
                    direccion = "",
                },
                trabajadores = new List<Trabajadores>
                        {
                            new Trabajadores
                            {
                                trabajador = new Trabajador
                                {
                                    tipoTrabajador = "",
                                    subTipoTrabajador = "",
                                    fechaIngreso = "",
                                    _fechaRetiro = null,
                                    fechaRetiro = "",
                                    tiempoLaborado = "",
                                    altoRiesgoPension = false,
                                    tipoDocumento = "",
                                    numeroDocumento = "",
                                    primerApellido = "",
                                    segundoApellido = "",
                                    primerNombre = "",
                                    otrosNombres = "",
                                    lugarTrabajoPais = "",
                                    lugarTrabajoMunicipioCiudad = "",
                                    lugarTrabajoDepartamentoEstado  = "",
                                    lugarTrabajoDireccion  = "",
                                    salarioIntegral  = false,
                                    tipoContrato = 1,
                                    sueldo = 2000000,
                                    codigoTrabajador = "",
                                    email = "",
                                },
                                numeroSecuenciaXML = new NumeroSecuenciaXML
                                {
                                    consecutivo = "",
                                    numero = "",
                                    prefijo = "",
                                },
                                informacionGeneral = new InformacionGeneral
                                {
                                    comprobanteTotal = 2000000,
                                    deduccionesTotal = 12333,
                                    devengadosTotal = 233233,
                                    fechaGen = "",
                                    fechaPagoFin = "",
                                    fechaPagoInicio = "",
                                    notas = "",
                                    numDocNovedad= "",
                                    periodoNomina = "",
                                    tipoMoneda = "",
                                    tipoNomina = "",
                                    tipoNota = "",
                                    trm = 0,
                                },
                                documentRef = new DocumentRef
                                {
                                    cuneRef = "",
                                    fechaGenPred = null,
                                    numRef = "",
                                },
                                fechasPagos = new List<FechasPago>
                                {
                                    new FechasPago
                                    {
                                        fecha = ""
                                    }
                                },
                                basicoDevengados = new BasicoDevengados
                                {
                                    diasTrabajados = 2,
                                    sueldoTrabajado = 1232
                                },
                                cesantias = new Cesantias
                                {
                                    pago = 1233,
                                    pagoIntereses = 12313,
                                    porcentaje = 0
                                },
                                compensaciones = new List<Compensaciones>
                                {
                                    new Compensaciones
                                    {
                                        compensacionE = 0,
                                        compensacionO = 0
                                    }
                                },
                                deducciones = new List<Deducciones>
                                {
                                    new Deducciones
                                    {
                                        porcentaje = 0,
                                        deduccion = 0,
                                        descripcion = "",
                                        tipo = 1,
                                        valorBase = 0,
                                    }
                                },
                                devengados = new List<Devengados>
                                {
                                    new Devengados
                                    {
                                        tipo = 1,
                                        cantidad = 0,
                                        fechaFin = "",
                                        fechaInicio = "",
                                        pago = 0,
                                        _fechaFin = DateTime.Now,
                                    }
                                },
                                fondoSP = new List<FondoSP>
                                {
                                    new FondoSP
                                    {
                                        deduccionSP = 0,
                                        deduccionSub = 0,
                                        porcentaje = 0,
                                        porcentajeSub = 0
                                    }
                                },
                                horasExtras = new List<HorasExtras>
                                {
                                    new HorasExtras
                                    {

                                    }
                                },
                                huelgasLegales = new List<HuelgasLegales>
                                {
                                    new HuelgasLegales
                                    {

                                    }
                                },
                                notas = new List<Nota>
                                {
                                    new Nota
                                    {

                                    }
                                },
                                otrasDeducciones = new List<OtrasDeducciones>
                                {
                                    new OtrasDeducciones
                                    {
                                        afc = 0,
                                        anticipo = 0,
                                        cooperativa = 0,
                                        deuda = 0,
                                        educacion = 0,
                                        embargoFiscal = 0,
                                        ica = 0,
                                        otraDeduccion = 0,
                                        pagoTercero = 0,
                                        pensionVoluntaria = 0,
                                        planComplementarios = 0,
                                        reintegro = 0,
                                        retencionFuente = 0,
                                    }
                                },
                                otrosConceptos = new List<OtrosConceptos>
                                {
                                    new OtrosConceptos
                                    {
                                        conceptoNS = 0,
                                        conceptoS = 0,
                                        descripcionConcepto = "",
                                        tipo = 0,
                                    }
                                },
                                otrosDevengados = new List<OtrosDevengados>
                                {
                                    new OtrosDevengados
                                    {
                                        anticipo = 0,
                                        apoyoSost = 0,
                                        bonifRetiro = 0,
                                        comision = 0,
                                        dotacion = 0,
                                        indemnizacion = 0,
                                        pagoTercero = 0,
                                        reintegro = 0,
                                        teletrabajo = 0,
                                    }
                                },
                                pago = new Pago
                                {
                                    banco = "",
                                    forma = 0,
                                    metodo = "",
                                    numeroCuenta = "",
                                    tipoCuenta = "",
                                },
                                primas = new List<Primas>
                                {
                                    new Primas
                                    {
                                        cantidad = 0,
                                        pago = 0,
                                        pagoNS = 0,
                                    }
                                },
                                sanciones = new List<Sanciones>
                                {
                                    new Sanciones
                                    {
                                        sancionPriv = 0,
                                        sancionPublic = 0,
                                    }
                                },
                                transporte = new List<Transporte>
                                {
                                    new Transporte
                                    {
                                        auxilioTransporte = 0,
                                        viaticoManuAlojNS = 0,
                                        viaticoManuAlojS = 0,
                                    }
                                }
                            },
                        }
            };
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

            //---------------------------------------------NOMINA-----------------------------------------------------//

            //Se realiza el envio de la nómina mediante el método Send expuesto por la librería
            request = await sendDIAN.Send<PetitionResponse>(documentoNomina, DocumentType.Nomina);

            //Se captura el PetitionResponse.Result de la petición
            var resultRequestNe = request?.result;

            //-----------------------------------------------RADIAN-----------------------------------------------------//

            //Se realiza el envio del evento mediante el método Send expuesto por la librería
            request = await sendDIAN.Send<PetitionResponse>(basicStructure, DocumentType.Radian);

            //Se captura el PetitionResponse.Result de la petición
            var resultRequestRadian = request?.result;
        }
    }
}
