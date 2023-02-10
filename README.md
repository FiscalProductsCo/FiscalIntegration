## FiscalIntegrationCo
FiscalIntegrationCo es una librería desarrollada en C# con soporte para `.NET Standar` en su version 2.0, que permite el envío de documentos nómina electrónica y eventos de RADIAN a la DIAN a través de los servicios ofrecidos por el proveedor tecnológico avalado por 
la DIAN, BTW SAS.

*ANTES DE EMPEZAR*

Se recomienda validar la documentación oficial de Microsoft sobre la compatibilidad de `.NET Standard 2.0` con las demas implentaciones de `.NET`, con el fin de que pueda identificar si la versión de destino de su codigo esta soportada.

Documentación oficial Microsoft *[.NET Standard 2.0 ](https://learn.microsoft.com/es-es/dotnet/standard/net-standard?tabs=net-standard-2-0)*


____
## USO

La clase `SendDocument` contiene un método único `Send` para el envio de los documentos electrónicos, el cual retorna un objeto del tipo `PetitionResponse` (Modelo incluido en la librería) con el estado del envío del documento.


**NET Framework 4.7.32+**

```csharp
 /*Llamado al método Send desde la clase SendDocument.
 Se carga como parámetro al constructor de SendDocument el ambiente (EnvironmentType) al que se enviará el documento.
 Se carga al método Send el objeto (DocumentoNomina o BasicStructure) con la información y el tipo de documento (DocumentType).*/

//Nómina electrónica

//Objeto del tipo DocumentoNomina cargado con la informacin requerida para el timbrado.
DocumentoNomina documentoNomina = new DocumentoNomina();

//Llamado al metodo Send
var request = new SendDocument(EnvironmentType.UAT).Send<PetitionResponse>(documentoNomina, DocumentType.Nomina);
request?.Wait();

//Eventos Radian

//Objeto del tipo BasicStructure cargado con la informacin requerida para el timbrado.
BasicStructure basicStructure = new BasicStructure();

//Llamado al metodo Send
var request = new SendDocument(EnvironmentType.UAT).Send<PetitionResponse>(basicStructure, DocumentType.Radian);
request?.Wait();

//Captura de la respuesta del tipo PetitionResponse
  var resultRequest = request?.Result;
```

**.NET y .NET Core	2.0+**
```csharp
/*Llamado al método Send desde la clase SendDocument.
 Se carga como parámetro al constructor de SendDocument el ambiente (EnvironmentType) al que se enviará el documento.
 Se carga al método Send el objeto (DocumentoNomina o BasicStructure) con la información y el tipo de documento (DocumentType).*/

//Instancia de la clase SendDocument.
 SendDocument sendDocument = new SendDocument(EnvironmentType.UAT);

//Nómina electrónica.

//Objeto del tipo DocumentoNomina cargado con la informacin requerida para el timbrado.
DocumentoNomina documentoNomina = new ();

//Llamado al metodo Send desde el Objeto sendDocument y captura de respuesta.
PetitionResponse response = await sendDocument.Send<PetitionResponse>(documentoNomina, DocumentType.Nomina);

//Eventos Radian.

//Objeto del tipo BasicStructure cargado con la informacin requerida para el timbrado.
BasicStructure basicStructure = new ();

//Llamado al metodo Send desde el Objeto sendDocument y captura de respuesta.
PetitionResponse response = await sendDocument.Send<PetitionResponse>(basicStructure, DocumentType.Radian);
```


### NET Core 6 Implementación paso a paso en una web API

**Archivo Program.cs**

```csharp
//Creación de la web API en NET Core 6
//Ubicarse en el archivo Program.cs
//Agregar referencias de los componentes a usar desde la librería

using Fiscal.Library.Core;
using Fiscal.Library.Models.InputModels;

//Realizar inyeccion de la clase SendDocument

builder.Services.AddSingleton<SendDocument>(A => {
    return new(EnvironmentType.UAT);
});

//Si el código no ha sido modificado, debe verse asi

using Fiscal.Library.Core;
using Fiscal.Library.Models.InputModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<SendDocument>(A => {
    return new(EnvironmentType.UAT);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
```



**Controlador**

```csharp
//Se debe crear una propiedad de solo lectura (readonly) del tipo de la clase SendDocument

private readonly SendDocument _sendDocument;

//Se debe crear el constructor del controlador, en donde se recibe un parámetro del tipo de la clase SendDocument
//Se debe asignar el valor a la propiedad anteriormente declarada.

public WeatherForecastController(SendDocument sendDocument)
        {
            _sendDocument = sendDocument;
        }
//Se debe crear un endpoint del tipo Post en el cual se recibe por URL el tipo de documento a enviar y por Body la información del documento a emitir
//Como respuesta se retorna la información en un objeto del tipo PetitionResponse
//Se realiza llamado al método Send, asignado los  parametros correspondientes

[HttpPost("SendDocument/{documentType}")]
        public async Task<PetitionResponse> Post([FromBody] DocumentoNomina documentoNomina, DocumentType documentType)
        {
            return await sendDocument1.Send<PetitionResponse>(documentoNomina, documentType);
        }
```      

____
### Dependencias
Si esta referenciando directamente en su proyecto `.NET` las `DLL` de la librería `FiscalIntegrationCo` es necesario agaregar las siguientes dependencias desde el administrador de paquetes `NuGet`.
- Newtonsoft.Json
- System.Text.Json
- Microsoft.AspNetCore.Http
- Microsoft.Extensions.Hosting
- Microsoft.AspNetCore.Http.Abstractions
- Microsoft.CSharp
- Microsoft.Extensions.Http
- Newtonsoft.Json.Bson
- Polly
- Polly.Extensions.Http
- RestSharp
- Serilog
- System.Net.Http
- System.Threading.Tasks
____

### Modelos incluídos en la librería 

**DocumentType** (tipos de documento)

- Nomina
- Radian

**EnvironmentType** (tipos de ambiente)

- PRD
- HAB
- UAT
- PLT
- NA

**Descripción de los ambientes**

| EnvironmentType Value  | Descripción |
| ------------- |:-------------:|
|PRD      | PRODUCCIÓN |
| HAB     | HABILITACIÓN |
| UAT     | PRUEBAS |
| PLT     | PILOTO |
| NA      | NO APLICA |


**Estructura del modelo PetitionResponse**

```csharp
public class PetitionResponse
    {
        public bool success { get; set; }
        public string message { get; set; }
        public string module { get; set; }
        public string URL { get; set; }
        public string Tracer { get; set; }
        public object result { get; set; }
	}
```

____
### Estructuras de Nómina Electrónica

**Estructura de DocumentoNomina (Documento de Nómina)**
```csharp
	public class DocumentoNomina
    {
        public Empleador empleador { get; set; }
        public List<Trabajadores> trabajadores { get; set; }
    }
```


**Estructura de Empleador (Información de la Empresa o Empleador)**
```csharp
public class Empleador
    {
        public string razonSocial { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string primerNombre { get; set; }
        public string otrosNombres { get; set; }
        public string nit { get; set; }
        public string dv { get; set; }
        public string pais { get; set; }
        public string departamentoEstado { get; set; }
        public string municipioCiudad { get; set; }
        public string direccion { get; set; }
    }
```


**Estructura de Trabajadores (Documento de Nómina)**
```csharp
	public class Trabajadores
    {
        public Trabajador trabajador { get; set; }
        public NumeroSecuenciaXML numeroSecuenciaXML { get; set; }
        public InformacionGeneral informacionGeneral { get; set; }
        public DocumentRef documentRef { get; set; }
        public List<FechasPago> fechasPagos { get; set; }
        public BasicoDevengados basicoDevengados { get; set; }
        public Cesantias cesantias { get; set; }
        public List<Compensaciones> compensaciones { get; set; }
        public List<Deducciones> deducciones { get; set; }
        public List<Devengados> devengados { get; set; }
        public List<FondoSP> fondoSP { get; set; }
        public List<HorasExtras> horasExtras { get; set; }
        public List<HuelgasLegales> huelgasLegales { get; set; }
        public List<Nota> notas { get; set; }
        public List<OtrasDeducciones> otrasDeducciones { get; set; }
        public List<OtrosConceptos> otrosConceptos { get; set; }
        public List<OtrosDevengados> otrosDevengados { get; set; }
        public Pago pago { get; set; }
        public List<Primas> primas { get; set; }
        public List<Sanciones> sanciones { get; set; }
        public List<Transporte> transporte { get; set; }
    }
```



**Estructura de BasicoDevengados (Básicos devengados)**
```csharp
	public class BasicoDevengados
    {
        public int? diasTrabajados { get; set; }
        public decimal? sueldoTrabajado { get; set; }
    }
```



**Estructura de Cesantias**
```csharp
	public class Cesantias
    {
        public decimal? pago { get; set; }
        public decimal? porcentaje { get; set; }
        public decimal? pagoIntereses { get; set; }
    }
```


**Estructura de Compensaciones**
```csharp
	public class Compensaciones
    {
        public decimal? compensacionO { get; set; }
        public decimal? compensacionE { get; set; }
    }
```



**Estructura de Deducciones**
```csharp
	public class Deducciones
    {
        public byte tipo { get; set; }
        public decimal? porcentaje { get; set; }
        public decimal? valorBase { get; set; }
        public decimal? deduccion { get; set; }
        public string descripcion { get; set; }
    }
```



**Estructura de Devengados**
```csharp
	public class Devengados
    {
        public byte tipo { get; set; }
        public string fechaInicio { get; set; }
        public DateTime _fechaFin { get; set; }
        public string fechaFin { get; set; }
        public decimal? cantidad { get; set; }
        public decimal? pago { get; set; }
    }
```


**Estructura de DocumentRef (Documento de referencia)**
```csharp
	public class DocumentRef
    {
        public string numRef { get; set; }
        public DateTime? fechaGenPred { get; set; }
        public string cuneRef { get; set; }
    }
```



**Estructura de FechaPago (Información de las Fechas de Pago)**
```csharp
	public class FechasPago
    {
        public string fecha { get; set; }
    }
```


**Estructura de FondoSP**
```csharp
	public class FondoSP
    {
        public decimal? porcentaje { get; set; }
        public decimal? deduccionSP { get; set; }
        public decimal? porcentajeSub { get; set; }
        public decimal? deduccionSub { get; set; }
    }
```



**Estructura de HorasExtras**
```csharp
	public class HorasExtras
    {
        public string tipo { get; set; }
        public string horaInicio { get; set; }
        public string horaFin { get; set; }
        public decimal? cantidad { get; set; }
        public decimal? porcentaje { get; set; }
        public decimal? pago { get; set; }
    }
```



**Estructura de HuelgasLegales**
```csharp
	public class HuelgasLegales
    {
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public decimal? cantidad { get; set; }
    }
```



**Estructura de InformacionGeneral**
```csharp
	public class InformacionGeneral
    {
        public string fechaGen { get; set; }
        public string fechaPagoInicio { get; set; }
        public string fechaPagoFin { get; set; }
        public string tipoNomina { get; set; }
        public string periodoNomina { get; set; }
        public string tipoMoneda { get; set; }
        public string tipoNota { get; set; }
        public string notas { get; set; }
        public string numDocNovedad { get; set; }
        public decimal? trm { get; set; }
        public decimal? devengadosTotal { get; set; }
        public decimal? deduccionesTotal { get; set; }
        public decimal? comprobanteTotal { get; set; }
    }
```



**Estructura de Nota**
```csharp
	public class Nota
    {
        public string nota { get; set; }
    }
```



**Estructura de NumeroSecuenciaXML**
```csharp
	public class NumeroSecuenciaXML
    {
        public string prefijo { get; set; }
        public string consecutivo { get; set; }
        public string numero { get; set; }
    }
```



**Estructura de OtrasDeducciones**
```csharp
	public class OtrasDeducciones
    {
        public decimal? otraDeduccion { get; set; }
        public decimal? pensionVoluntaria { get; set; }
        public decimal? retencionFuente { get; set; }
        public decimal? ica { get; set; }
        public decimal? afc { get; set; }
        public decimal? cooperativa { get; set; }
        public decimal? embargoFiscal { get; set; }
        public decimal? planComplementarios { get; set; }
        public decimal? educacion { get; set; }
        public decimal? reintegro { get; set; }
        public decimal? deuda { get; set; }
        public decimal? pagoTercero { get; set; }
        public decimal? anticipo { get; set; }
    }
```



**Estructura de OtrosConceptos**
```csharp
	public class OtrosConceptos
    {
        public byte tipo { get; set; }
        public string descripcionConcepto { get; set; }
        public decimal? conceptoS { get; set; }
        public decimal? conceptoNS { get; set; }
    }
```



**Estructura de OtrosDevengados**
```csharp
	public class OtrosDevengados
    {
        public decimal? dotacion { get; set; }
        public decimal? apoyoSost { get; set; }
        public decimal? teletrabajo { get; set; }
        public decimal? bonifRetiro { get; set; }
        public decimal? reintegro { get; set; }
        public decimal? indemnizacion { get; set; }
        public decimal? pagoTercero { get; set; }
        public decimal? anticipo { get; set; }
        public decimal? comision { get; set; }
    }
```



**Estructura de Pago**
```csharp
	public class Pago
    {
        public byte? forma { get; set; }
        public string metodo { get; set; }
        public string banco { get; set; }
        public string tipoCuenta { get; set; }
        public string numeroCuenta { get; set; }
    }
```



**Estructura de Primas**
```csharp
	public class Primas
    {
        public decimal? cantidad { get; set; }
        public decimal? pago { get; set; }
        public decimal? pagoNS { get; set; }
    }
```



**Estructura de Sanciones**
```csharp
	public class Sanciones
    {
        public decimal? sancionPublic { get; set; }
        public decimal? sancionPriv { get; set; }
    }
```



**Estructura de Trabajador**
```csharp
    public class Trabajador
    {
        public string tipoTrabajador { get; set; }
        public string subTipoTrabajador { get; set; }
        public string fechaIngreso { get; set; }
        public DateTime? _fechaRetiro { get; set; }
        public string fechaRetiro { get; set; }
        public string tiempoLaborado { get; set; }
        public bool? altoRiesgoPension { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string primerNombre { get; set; }
        public string otrosNombres { get; set; }
        public string lugarTrabajoPais { get; set; }
        public string lugarTrabajoMunicipioCiudad { get; set; }
        public string lugarTrabajoDepartamentoEstado { get; set; }
        public string lugarTrabajoDireccion { get; set; }
        public bool? salarioIntegral { get; set; }
        public byte? tipoContrato { get; set; }
        public decimal? sueldo { get; set; }
        public string codigoTrabajador { get; set; }
        public string email { get; set; }
    }
```



**Estructura de Transporte**
```csharp
	public class Transporte
    {
        public decimal? auxilioTransporte { get; set; }
        public decimal? viaticoManuAlojS { get; set; }
        public decimal? viaticoManuAlojNS { get; set; }
    }
```


____

### Estructuras de Eventos RADIAN

**Estructura de BasicStructure**
```csharp
	public class BasicStructure
    {
        public FromHead FromHead { get; set; }
        public FromSenderTaxScheme FromSenderTaxScheme { get; set; }
        public IEnumerable<FromSenderParty> FromSenderParty { get; set; }
        public IEnumerable<FromReceiverTaxScheme> FromReceiverTaxScheme { get; set; }
        public IEnumerable<FromReceiverParty> FromReceiverParty { get; set; }
        public IEnumerable<FromIssuerParty> FromIssuerParty { get; set; }
        public IEnumerable<FromDRIssuerLegalEntity> FromDRIssuerLegalEntity { get; set; }
        public IEnumerable<FromSenderLegalEntity> FromSenderLegalEntity { get; set; }
        public IEnumerable<FromReceiverLegalEntity> FromReceiverLegalEntity { get; set; }
        public IEnumerable<FromCustomTagGeneral> FromCustomTagGeneral { get; set; }
        public IEnumerable<FromDRPerson> FromDRPerson { get; set; }
        public IEnumerable<FromSenderPerson> FromSenderPerson { get; set; }
        public IEnumerable<FromReceiverPerson> FromReceiverPerson { get; set; }
        public IEnumerable<FromSenderPAttorney> FromSenderPAttorney { get; set; }
        public IEnumerable<FromDRIssuerPAttorney> FromDRIssuerPAttorney { get; set; }
        public IEnumerable<FromDRIssuerPAttorneyPerson> FromDRIssuerPAttorneyPerson { get; set; }
        public IEnumerable<FromDRIssuerTaxScheme> FromDRIssuerTaxScheme { get; set; }
        public IEnumerable<FromDocumentReference> FromDocumentReference { get; set; }
        public IEnumerable<FromNote> Notes { get; set; }
        public IEnumerable<FromAttachment> FromAttachment { get; set; }
    }
```



**Estructura de FromHead**
```csharp
    public class FromHead
    {
        public string ID { get; set; }
        public DateTime? IssueDate { get; set; }
        /// <summary>
        /// 035: "Aval"
        /// 036: "Inscripción de la factura electrónica de venta como título valor - RADIAN"
        /// 037: "Endoso en propiedad"
        /// 038: "Endoso en garantía"
        /// 039: "Endoso en procuración"
        /// 040: "Cancelación de endoso"
        /// 041: "Limitaciones a la circulación de la factura electrónica de venta como título"
        /// 042: "Terminación de las limitaciones a la circulación de la factura electrónica de venta como título"
        /// 043: "Mandato"
        /// 044: "Terminación del mandato"
        /// 045: "Pago de la factura electrónica de venta como título valor"
        /// 046: "Informe para el pago"
        /// </summary>
        public string ResponseCode { get; set; }
        /// <summary>
        /// Endosos: - "1" Completo - "2" En blanco
        /// Recibo: "01" Documento con inconsistencias - "02" Mercancía no entregada totalmente - "03" Mercancía no entregada parcialmente - "04" Servicio no prestado
        /// Mandato: Referencia a documentos electronicos, "1" Un documento electrónico - "2" Maximo 20 documentos electrónicos "3" - Todos los documentos de tipo invoice.
        /// Pago: "1" Sin limitacion - "2" con limitacion 
        /// Reclamo: Tipo de identificación del rechazo. "01" - Documento con inconsistencias "02" - Mercancía no entregada totalmente "03" - Mercancía no entregada parcialmente "04" - Servicio no prestado
        /// </summary>
        public string ResponseCodeListID { get; set; } = string.Empty;
        public string OperationType_c { get; set; } = string.Empty;
        /// <summary>
        /// Mandatos: Referencia a la naturaleza de los mandatos.
        /// 1. Mandato por Poder Especial 
        /// 2. Mandato por Poder General
        /// </summary>
        public string CustomizationSchemeID { get; set; }
        /// <summary>
        /// Mandato: Fecha desde cuando puede actuar el Mandatario
        /// </summary>
        public DateTime? EffectiveDateMandate { get; set; }
        /// <summary>
        /// Mandato: Fecha de la escritura pública
        /// </summary>
        public DateTime? PublicEffectiveDate { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// Mandato: Debe ser informado el consecutivo del contrato de mandato
        /// </summary>
        public string ConsecutiveTerm { get; set; }
        /// <summary>
        /// Mandato: Contrato del mandatos entre las partes. Corresponde al contrato entre las partes (Mandante y Mandatario) el cual debe ser informado en Base64 en formato .PDF.
        /// </summary>
        public string Attachment { get; set; }
        /// <summary>
        /// Mandato: Debe ser informado el consecutivo de la nota de vigencia delcontrato de Mandato 
        /// </summary>
        public string ValidityNote { get; set; }
        public string CurrencyCode { get; set; }
    }
```



**Estructura de FromSenderTaxScheme**
```csharp
	public class FromSenderTaxScheme
    {
        public string RegistrationName { get; set; } = string.Empty;
        public string CompanyID { get; set; } = string.Empty;
       //public string ID { get; set; } = string.Empty;
        public string SenderIDType { get; set; } = string.Empty;
        public string OrganizationIDType { get; set; } = string.Empty;
        /// <summary>
        /// Aval: Valor del monto a avalar. Si no se indica el monto se entiende que responde por la totalidad del valor de la FEV.
        /// </summary>
        public decimal StockAmount1 { get; set; } = 0;
        public string Currency1 { get; set; } = string.Empty;
    }
```

**Estructura de FromSenderParty**
```csharp
    public class FromSenderParty
    {
        /// <summary>
        /// NIT del titular del evento
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Nombre o Razón Social del titular el evento
        /// </summary>
        public string RegistrationName { get; set; }
        /// <summary>
        /// Tipo de identificación del titular del evento
        /// </summary>
        public string SenderIDType { get; set; }
        /// <summary>
        /// 1: Persona Jurídica y asimiladas
        /// 2: Persona Natural y asimiladas
        /// </summary>
        public string OrganizationIDType { get; set; }
        /// <summary>
        /// 1: Factoring
        /// 2: Confirming
        /// </summary>
        public string CompanyLegalFormCode { get; set; }
        /// <summary>
        /// Endoso: Valor sobre el cual participa en el endoso como Endosante. El valor informado debe ser difente de (0.00).
        /// </summary>
        public decimal? StockAmount { get; set; }
        /// <summary>
        /// Mandante-FE: Mandante Facturador Electrónico
        /// Mandante-LT: Mandante Legitimo Tenedor
        /// Mandante-AV: Mandante Avalista
        /// Mandante-AD: Mandante Adquirente/Deudor
        /// </summary>
        public string SenderMandateType { get; set; }
    }
```



**Estructura de FromReceiverParty**
```csharp
    public class FromReceiverTaxScheme
    {
        public string RegistrationName { get; set; } = string.Empty;
        public string CompanyID { get; set; } = string.Empty;
        public string ReceiverIDType { get; set; } = string.Empty;
        public string OrganizationIDType { get; set; } = string.Empty;
        public decimal StockAmount1 { get; set; } = 0;
        public string Currency1 { get; set; } = string.Empty;
    }
```



**Estructura de FromIssuerParty**
```csharp
    public class FromIssuerParty
    {
        /// <summary>
        /// Endoso: Número de identificación del endosatario
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// Endoso: Nombre o Razón Social del endosatario
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Tipo de identificador de identidad[NIT, CC, TI, etc.]
        /// </summary>
        public string IdentificationType { get; set; }
        /// <summary>
        /// Endoso: Tipo de identificador de organización. [1: Persona Jurídica y asimiladas] [2: Persona Natural y asimiladas]
        /// </summary>
        public string OrganizationIDType { get; set; }
        /// <summary>
        /// Aval: Se debe informar el valor a avalar para cada avalado 
        /// </summary>
        public decimal? StockAmount { get; set; }
    }
```


**Estructura de FromDRIssuerLegalEntity**
```csharp
    public class FromDRIssuerLegalEntity
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string IdentificationType { get; set; }
        public string CompanyType_c { get; set; }
        public decimal StockAmount1 { get; set; }
        public string Currency1 { get; set; }
    }
```


**Estructura de FromSenderLegalEntity**
```csharp
    public class FromSenderLegalEntity 
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string IdentificationType { get; set; }
        public string CompanyType_c { get; set; }
        public decimal StockAmount1 { get; set; }
        public string Currency1 { get; set; }
    }
```


**Estructura de FromReceiverLegalEntity**
```csharp
    public class FromReceiverLegalEntity
    {
        /// <summary>
        /// Informar cuando el endoso es generado hacia un Factor
		/// 1 Factoring
		///	2 Confirming
        /// </summary>
        public string LegalFormCode { get; set; } = string.Empty;
        public string ID { get; set; }
        public string Name { get; set; }
        public string IdentificationType { get; set; }
        public string CompanyType_c { get; set; }
        public decimal StockAmount1 { get; set; }
        public string Currency1 { get; set; }
    }
```


**Estructura de FromCustomTagGeneral**
```csharp
    public class FromCustomTagGeneral
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
```


**Estructura de FromDRPerson**
```csharp
    public class FromDRPerson
    {
        public string ID { get; set; } = string.Empty;
        public string IssuerIDType { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string OrganizationDepartment { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
    }
```


**Estructura de FromSenderPerson**
```csharp
    public class FromSenderPerson
    {
        public string ID { get; set; } = string.Empty;
        public string IdentificationType { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string OrganizationDepartment { get; set; } = string.Empty;
    }
```


**Estructura de FromReceiverPerson**
```csharp
    public class FromReceiverPerson
    {
        public string ID { get; set; } = string.Empty;
        public string IdentificationType { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string OrganizationDepartment { get; set; } = string.Empty;
    }
```


**Estructura de FromSenderPAttorney**
```csharp
    public class FromSenderPAttorney
    {
        public string ID { get; set; } = string.Empty;
        public string IdentificationType { get; set; } = string.Empty;
        /// <summary>
        /// Mandante-FE
        /// Mandante-LT
        /// Mandante-AV
        /// Mandante-AD
        /// </summary>
        public string TipoMandante { get; set; } = string.Empty;
        /// <summary>
        /// Mandante Facturador Electrónico
        /// Mandante Legitimo Tenedor
        /// Mandante Aval
        /// Mandante Adquirente/Deudor
        /// </summary>
        public string Description { get; set; } = string.Empty;
    }
```


**Estructura de FromDRIssuerPAttorney**
```csharp
    public class FromDRIssuerPAttorney
    {
        public string ID { get; set; }
        public string IdentificationType { get; set; }
        public string TipoMandante { get; set; }
        public string Description { get; set; }
    }
```


**Estructura de FromDRIssuerPAttorneyPerson**
```csharp
    public class FromDRIssuerPAttorneyPerson
    {
        public string ID { get; set; } = string.Empty;
        public string IssuerIDType { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string FamilyName { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public string OrganizationDepartment { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
    }
```


**Estructura de FromDRIssuerTaxScheme**
```csharp
    public class FromDRIssuerTaxScheme
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string IdentificationType { get; set; }
        /// <summary>
        /// 1: Persona Jurídica y asimiladas
        /// 2: Persona Natural y asimiladas
        /// </summary>
        public string OrganizationIDType { get; set; }
        /// <summary>
        /// Aval: Se debe informar el valor a avalar para cada avalado
        /// </summary>
        public decimal? StockAmount { get; set; }
    }
```


**Estructura de FromDocumentReference**
```csharp
	public class FromDocumentReference
    {
        /// <summary>
        /// Prefijo y Número del documento referenciado
        /// </summary>
        public string LegalNumRef { get; set; }
        /// <summary>
        /// Este campo debe venir desde la base de datos de FE. EVALUAR POSIBILIDAD
        /// </summary>
        public string CUFERef { get; set; }
        /// <summary>
        /// Este campo debe venir desde la base de datos de FE. EVALUAR POSIBILIDAD
        /// </summary>
        public string DocumentTypeCodeRef { get; set; }
        /// <summary>
        /// opcional.
        /// Usado para indicar el documento al que pertenece la fecha indicada
        /// Mandato: Fecha de inicio del mandato
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// Mandato: Fecha de fin del mandato
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// En mandatos obdedece a Tiempo del mandato
        /// </summary>
        public string DescriptionCode { get; set; }
        /// <summary>
        /// applicationresponse/cac:DocumentResponse/cac:DocumentReference/cac:ValidityPeriod/cbc:Description
        /// En mandatos obdedece a Descripción del mandato
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Debe corresponder a un valor de las columnas “Sistema de Negociación “SNE””, “Proveedor Tecnológico “PT””, “Factor “F”” del numeral 13.2.4. 
        /// Para reportar varias facultades se deben reportar seperando cada uno de los valores de la lista con ; 
        /// Ejemplo R05-PT;R07-PT;R08-PT
        /// </summary>
        public string ScopeMandate { get; set; }
    }
```


**Estructura de FromNote**
```csharp
	public class FromNote
    {
        public string Note { get; set; } = string.Empty;
    }
```


**Estructura de FromAttachment**
```csharp
	public class FromAttachment
    {
        public string ID { get; set; }
        public string DocumentBinary { get; set; }
        public string ResponseDescription { get; set; }
        public string DocumentDescription { get; set; }
        public System.DateTime? EffectiveDate { get; set; }
    }
```
