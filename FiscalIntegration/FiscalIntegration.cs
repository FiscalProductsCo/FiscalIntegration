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

            //Se crea el modelo de Nomina 
            DocumentoNomina documentoNomina = new DocumentoNomina()
            {
                empleador = new Empleador()
                {
                    razonSocial = "BYTHEWAVE SAS",  //Razón social de la empresa 
                    primerApellido = null,
                    segundoApellido = null,
                    primerNombre = null,
                    otrosNombres = null,
                    nit = "900665411",              //NIT de la empresa 
                    dv = "2",                       //Dígito de verificación
                    pais = "CO",
                    departamentoEstado = "05",
                    municipioCiudad = "05001",
                    direccion = "Calle 49 Sur 45A 300 Oficina 2009 Centro",
                },
                trabajadores = new List<Trabajadores>
                        {
                            new Trabajadores
                            {
                                trabajador = new Trabajador
                                {
                                    tipoTrabajador = "01",      //Corresponde a la clasificación de PILA para conocer en que calidad se realizan las cotizaciones a la seguridad social. 
                                    subTipoTrabajador = "00",   //Corresponde a una sub clasificación de PILA para conocer en que calidad se realizan las cotizaciones a la seguridad social.
                                    fechaIngreso = "2020-01-01",          
                                    _fechaRetiro = null,
                                    fechaRetiro = null,
                                    tiempoLaborado = null,
                                    altoRiesgoPension = false,
                                    tipoDocumento = "13",             //Tipo de documento de identificación que actualmente tiene el trabajador o aprendiz
                                    numeroDocumento = "1002339948",   //Debe ir el Numero de documento del trabajador, sin puntos ni comas ni espacios
                                    primerApellido = "Test",
                                    segundoApellido = "Test",
                                    primerNombre = "Test",
                                    otrosNombres = "Test",
                                    lugarTrabajoPais = "CO",                    //Código del país actual donde se encontraba ubicado el trabajador o aprendiz en el mes reportado. Se debe colocar el Codigo alfa-2
                                    lugarTrabajoMunicipioCiudad = "05088",      //Código del departamento actual donde se encontraba ubicado el trabajador o aprendiz en el mes reportado.
                                    lugarTrabajoDepartamentoEstado  = "05",     //Código del municipio o ciudad actual donde se encontraba ubicado el trabajador o aprendiz en el mes reportado.
                                    lugarTrabajoDireccion  = "cl 49 sur 45 a 300 envigado",
                                    salarioIntegral  = false,
                                    tipoContrato = 1,           //1. Termino Fijo  - 2.Término Indefinido  - 3. Obra o Labor - 4. Aprendizaje - 5. Prácticas
                                    sueldo = 2000000,           
                                    codigoTrabajador = "",      //Campo Opcional queda a manejo Interno del Empleador.
                                    email = "",
                                },
                                numeroSecuenciaXML = new NumeroSecuenciaXML
                                {
                                    prefijo = "NE",        //Debe corresponder a un Prefijo elegido por el Emisor del documento
                                    consecutivo = "1",     //Debe corresponder a un Consecutivo elegido por el Emisor del documento
                                    numero = "NE1",        //Debe corresponder al Prefijo y consecutivo manejado por el Empleador - No se permiten caracteres adicionales como espacios o guiones. Prefijo + Número
                                },
                                informacionGeneral = new InformacionGeneral
                                {
                                    comprobanteTotal = 220900,      //Debe ser la Diferencia entre DevengadosTotal - DeduccionesTotal
                                    deduccionesTotal = 12333,       //Debe ir el valor Total de Todos las Deducciones del Trabajador   
                                    devengadosTotal = 233233,       //Debe ir el valor Total de Todos los Devengados del Trabajador
                                    fechaGen = "2023-03-10",        //Fecha de emisión: Fecha de emisión del documento. AAAA-MM-DDTHH:mm:ss
                                    fechaPagoFin = "2023-02-28",    //Fecha fin del pago. AAAA-MM-DDTHH:mm:ss
                                    fechaPagoInicio = "2023-02-01",       //Fecha de inicio del pago. AAAA-MM-DDTHH:mm:ss
                                    notas = "",                           //Campo de libre uso para Observaciones en el documento
                                    numDocNovedad= null,                //Indica si existe alguna Novedad Contractual en el Documento Soporte de Pago de Nómina Electrónica
                                    periodoNomina = "4",                //1 Semanal - 2 Decenal - 3 Catorcenal - 4 Quincenal - 5 Mensual
                                    tipoMoneda = "COP",
                                    tipoNomina = "102",                 //Corresponde al Codigo de Tipo de Nómina - 102 Nomina Individual 103 Nomina Individual de Ajuste
                                    tipoNota = null,                    //Corresponde al tipo de Nota de Ajuste de Documento Soporte de Pago de Nómina Electrónica 
                                    trm = 0,
                                },
                                documentRef = new DocumentRef
                                {
                                    cuneRef = null,         //Debe corresponder al Numero de Documento Soporte de Pago de Nómina Electrónica a Reemplazar o eliminar
                                    fechaGenPred = null,    //Debe ir la fecha del documento a Reemplazar o eliminar, en formato AAAA-MM-DD
                                    numRef = null,          //Debe ir el CUNE del documento a Reemplazar o eliminar
                                },
                                fechasPagos = new List<FechasPago>
                                {
                                    new FechasPago
                                    {
                                        fecha = "2022-08-31"    //Fecha en el que se realizó el pago
                                    }
                                },
                                basicoDevengados = new BasicoDevengados
                                {
                                    diasTrabajados = 23,
                                    sueldoTrabajado = 1116664
                                },
                                cesantias = new Cesantias
                                {
                                    pago = 130907,
                                    pagoIntereses = 1265,
                                    porcentaje = 0.97m
                                },
                                compensaciones = new List<Compensaciones>
                                {
                                    new Compensaciones
                                    {
                                        compensacionE = null,
                                        compensacionO = null
                                    }
                                },
                                deducciones = new List<Deducciones>
                                {
                                    new Deducciones
                                    {
                                        porcentaje = 4.00m,
                                        deduccion = 58296,
                                        descripcion = "",   //Descripción del tipo de deducción opcional
                                        tipo = 1,           //código de clasificación de las deducciones ya sea salud, fondoPension, Sindicato, Libranza, PagoTerceros, Anticipos
                                        valorBase = 1206644,
                                    }
                                },
                                devengados = new List<Devengados>
                                {
                                    new Devengados
                                    {
                                        tipo = 2,       //código de clasificación de los devengados
                                        cantidad = 1,
                                        fechaFin = null,
                                        fechaInicio = null,
                                        pago = 48588,
                                        _fechaFin = DateTime.Now,
                                    }
                                },
                                fondoSP = new List<FondoSP>
                                {
                                    new FondoSP
                                    {
                                        deduccionSP = 20378,    //Todo trabajador que devengue un sueldo que sea igual o superior a 4 salarios mininos, debe aportar un 1% al Fondo de solidaridad pensional.
                                        deduccionSub = 20377,   //Valor Pagado correspondiente a Fondo de Subsistencia por parte del trabajador
                                        porcentaje = 0.50m,     //Debe corresponder al porcentaje de deducción de fondo de seguridad pensional que paga el trabajador
                                        porcentajeSub = 0.50m   //Se debe colocar el Porcentaje que correspondiente al Fondo de Subsistencia correspondiente
                                    }
                                },
                                horasExtras = new List<HorasExtras>
                                {
                                    new HorasExtras
                                    {
                                        tipo = "HEDs",      //Clasificación de horas extras en este ejemplo HEDs se usa para Horas Extras Diarias
                                        horaInicio = null,  //En formato YYYY-MM-DDTHH:MM:SS
                                        horaFin = null,     //En formato YYYY-MM-DDTHH:MM:SS
                                        cantidad = 4,       //Cantidad de Horas, Debe ser la diferencia entre HoraInicio y HoraFin
                                        porcentaje = 25,    //Porcentaje según clasificación de horas extras
                                        pago = 28909,       //Es el valor pagado por el tiempo que se trabaja adicional a la jornada legal
                                    }
                                },
                                huelgasLegales = new List<HuelgasLegales>
                                {
                                    new HuelgasLegales
                                    {
                                        fechaInicio = null,
                                        fechaFin = null,
                                        cantidad = null                                        
                                    }
                                },
                                notas = new List<Nota>
                                {
                                    new Nota
                                    {
                                        nota = ""      //Campo de libre uso para Observaciones en el documento
                                    }
                                },
                                otrasDeducciones = new List<OtrasDeducciones>
                                {
                                    new OtrasDeducciones
                                    {
                                        afc = 0,        //Valor Pagado correspondiente a AFC por parte del trabajador
                                        anticipo = 0,   //Deduccion por Anticipos de Nómina. Solo aplica cuando el tipo es "6: Anticipos"
                                        cooperativa = 0,    //Valor Pagado correspondiente a Cooperativas por parte del trabajador
                                        deuda = 0,          //Valor que se deba pagar por las obligaciones que el empleado tenga con su empresa, como puede ser un crédito que ésta le haya otorgado, o como compensación por algún perjuicio o detrimento económico que el empleado le haya causado a la empresa.
                                        educacion = 0,      //Valor de servicios educativos que el trabajador autorice descuento
                                        embargoFiscal = 0,  //Valor Pagado correspondiente aEmbargos Fiscales por parte del trabajador
                                        ica = 0,            //Valor Pagado correspondiente a ICA por parte del trabajador
                                        otraDeduccion = 0,  //Otro tipo de deducción dentro de la Nomina.
                                        pagoTercero = 0,    //Deducciones en cabeza del Trabjador que se pagan a un proveedor o tercero. Solo aplica cuando el tipo es "5: PagosTerceros"
                                        pensionVoluntaria = 0,      //Valor correspondiente al ahorro que hace el trabajador para complementar su pension obligatoria o cumplir metas especificas.
                                        planComplementarios = 0,    //Valor de planes complementarios de salud al que el trabajador se encuentran afiliado, siempre que medie autorización del empleado.
                                        reintegro = 0,              //Valor que le regresa la empresa al trabajador por una deducción mal realizada en otro pago de nómina
                                        retencionFuente = 0,        //Valor Pagado correspondiente a Retención en la Fuente por parte del trabajador
                                    }
                                },
                                otrosConceptos = new List<OtrosConceptos>
                                {
                                    new OtrosConceptos
                                    {
                                        conceptoNS = 0,     //Valor Pagado por Conceptos No Salariales
                                        conceptoS = 0,      //Valor Pagado por Conceptos Salariales
                                        descripcionConcepto = "",   //Debe ir la Descripcion del Concepto
                                        tipo = 0, 
                                    }
                                },
                                otrosDevengados = new List<OtrosDevengados>
                                {
                                    new OtrosDevengados
                                    {
                                        anticipo = 0,
                                        apoyoSost = 0,      //Valor Pagado por Apoyo a Sostenimiento
                                        bonifRetiro = 0,    //Valor Pagado por Retiro de la empresa   
                                        comision = 0,       //Valor Pagado por comisiones
                                        dotacion = 0,       //Valor Pagado por dotacion
                                        indemnizacion = 0,  //Valor Pagado por Indemnización
                                        pagoTercero = 0,    
                                        reintegro = 0,      //Valor Pagado por Reintegro a la empresa
                                        teletrabajo = 0,    //Valor Pagado por trabajo en Teletrabajo
                                    }
                                },
                                pago = new Pago
                                {
                                    banco = "",     //Banco
                                    forma = 1,      //1 para contado - código de clasificación del tipo de pago
                                    metodo = "20",  //Metodos de Pago del Documento según clasificación 
                                    numeroCuenta = "",  //Numero de Cuenta Bancaria del Empleado donde se realiza la consignación
                                    tipoCuenta = "A",   //Tipo de Cuenta Bancaria del Empleado donde se realiza la consignación
                                },
                                primas = new List<Primas>
                                {
                                    new Primas
                                    {
                                        cantidad = 0,   //Cantidad de dias trabajados para calculo de Pago de Corte de Prima
                                        pago = 0,       //Valor Pagado por Prima Legal con respecto a Cantidad de Dias
                                        pagoNS = 0,     //Valor Pagado por Prima No Salarial
                                    }
                                },
                                sanciones = new List<Sanciones>
                                {
                                    new Sanciones
                                    {
                                        sancionPriv = 0,    //Valor por el del incumplimiento de una regla o norma de conducta obligatoria (Privada o Ordinaria)
                                        sancionPublic = 0,  //Valor por el del incumplimiento de una regla o norma de conducta obligatoria (Publica)
                                    }
                                },
                                transporte = new List<Transporte>
                                {
                                    new Transporte
                                    {
                                        auxilioTransporte = 0,  
                                        viaticoManuAlojNS = 0,  //Valor de Viaticos, Manutención y Alojamiento de carácter No Salarial. Parte de los viáticos pagado al trabajador correspondientes a manutención y/o alojamiento No Salariales.
                                        viaticoManuAlojS = 0,   //Valor de Viaticos, Manutención y Alojamiento de carácter Salarial. Parte de los viáticos pagado al trabajador correspondientes a manutención y/o alojamiento.
                                    }
                                }
                            },
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
        }
    }
}
