## FiscalIntegrationCo
FiscalIntegrationCo es una librería desarrollada en C# con soporte para .NET Standar en su version 2.0, que permite el envío de documentos nómina electrónica y eventos de RADIAN a la DIAN a través de los servicios ofrecidos por el proveedor tecnológico avalado por 
la DIAN, BTW SAS.

**ANTES DE EMPEZAR**

Recomendamos validar la documentacion oficial de Microsoft sobre la compatibilidad de **.NET Standard 2.0** con las demas implentaciones de .NET, con el fin de que pueda identificar si la version de destino de su codigo esta soportada.

Documentacion oficial **[.NET Standard 2.0 ](https://learn.microsoft.com/es-es/dotnet/standard/net-standard?tabs=net-standard-2-0)**


____
## USO

La clase **SendDocument** contiene un método único **Send** para el envio de los documentos electrónicos, el cual retorna un objeto del tipo **PetitionResponse** (Modelo incluido en la librería) con el estado del envío del documento.


**NET Framework 4.7.32+ **

```
 //Deserealización de la estructura JSON a un objeto del tipo DocumentoNomina.
 var objeto = JsonConvert.DeserializeObject<DocumentoNomina>(json);
```
```
 //Deserealización de la estructura JSON a un objeto del tipo BasicStructure.
 var objeto = JsonConvert.DeserializeObject<BasicStructure>(json);
```

```
 // Llamado desde la clase SendDocument al método Send.
 // Se pasa como parámetro al constructor de SendDocument el ambiente al que se enviará el documento.
 // Al método Send se pasa el objeto con la información y el tipo de documento.

 //Nómina electrónica
 var request = new SendDocument(EnvironmentType.UAT).Send<dynamic>(objeto, DocumentType.Nomina);
 request?.Wait();

 //Eventos Radian
 var request = new SendDocument(EnvironmentType.UAT).Send<dynamic>(objeto, DocumentType.Radian);
 request?.Wait();
```

```
 //Captura de la respuesta del tipo PetitionResponse
 var resultXMLERP = request?.Result;
```

**.NET y .NET Core	2.0+ **
```
```
____
## Dependencias
Si se esta referneciando directamenre en su poryecto .NET las DLL de la libreria **FiscalIntegrationCo** es necesario agaregar las siguientes dependencias desde el administrador de paquetes NuGet.
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

## Modelos incluídos en la librería 

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
|PRD      | PRODUCCIPIÓN |
| HAB     | HABILITACIÓN |
| UAT     | PRUEBAS |
| PLT     | PILOTO |
| NA      | NO APLICA |


**Estructura del modelo PetitionResponse**

```
	success : boolean,
	message : string
	module : string,
	URL : string,
	Tracer : string
	result : object
```
____
**Estructuras de Nómina Electrónica**

**Estructura de DocumentoNomina (Documento de Nómina)**
```
	empleador : Empleador,
	trabajadores : List<Trabajadores>
```

**Estructura de Empleador (Información de la Empresa o Empleador)**
```
	razonSocial : string,
	primerApellido : string,
	segundoApellido : string,
	primerNombre : string,
	otrosNombres : string,
	nit : string,
	dv : string,
	pais : string,
	departamentoEstado : string,
	municipioCiudad : string,
	direccion : string
```

**Estructura de Trabajadores (Documento de Nómina)**
```

	trabajador : Trabajador,
	numeroSecuenciaXML : NumeroSecuenciaXML,
	informacionGeneral : InformacionGeneral,
	documentRef : DocumentRef,
	fechasPagos : List<FechasPago>,
	basicoDevengados : BasicoDevengados,
	cesantias : Cesantias,
	compensaciones : List<Compensaciones>,
	deducciones : List<Deducciones>,
	devengados : List<Devengados>,
	fondoSP : List<FondoSP>,
	horasExtras : List<HorasExtras>,
	huelgasLegales : List<HuelgasLegales>,
	notas : List<Nota>,
	otrasDeducciones : List<OtrasDeducciones>,
	otrosConceptos : List<OtrosConceptos>,
	otrosDevengados : List<OtrosDevengados>,
	pago : Pago,
	primas : List<Primas>,
	sanciones : List<Sanciones>,
	transporte : List<Transporte>

```

**Estructura de BasicoDevengados (Básicos devengados)**
```

	diasTrabajados : int,
	sueldoTrabajado : decimal

```

**Estructura de Cesantias**
```

	pago : decimal,
	porcentaje : decimal,
	pagoIntereses : decimal

```

**Estructura de Compensaciones**
```

	compensacionO : decimal,
	compensacionE : decimal

```

**Estructura de Deducciones**
```

	tipo : byte,
	porcentaje : decimal,
	valorBase : decimal,
	deduccion : decimal,
	descripcion : string

```

**Estructura de Devengados**
```

	tipo : byte,
	fechaInicio : string,
	_fechaFin : DateTime,
	fechaFin : string,
	cantidad : decimal,
	pago : string

```

**Estructura de DocumentRef (Documento de referencia)**
```

	numRef : string,
	fechaGenPred : DateTime,
	cuneRef : string

```

**Estructura de FechaPago (Información de las Fechas de Pago)**
```

	fecha : string

```

**Estructura de FondoSP**
```

	porcentaje : decimal,
	deduccionSP : decimal,
	porcentajeSub : decimal,
	deduccionSub : decimal

```

**Estructura de HorasExtras**
```

	tipo : string,
	horaInicio : string,
	horaFin : string,
	cantidad : decimal,
	porcentaje : decimal,
	pago : decimal

```

**Estructura de HuelgasLegales**
```

	fechaInicio : string,
	fechaFin : string,
	cantidad : decimal

```

**Estructura de InformacionGeneral**
```

	fechaGen : string,
	fechaPagoInicio : string,
	fechaPagoFin : string,
	tipoNomina : string,
	periodoNomina : string,
	tipoMoneda : string,
	tipoNota : string,
	notas : string,
	numDocNovedad : string,
	trm : decimal,
	devengadosTotal : decimal,
	deduccionesTotal : decimal,
	comprobanteTotal : decimal

```

**Estructura de Nota**
```

	nota : string,

```

**Estructura de NumeroSecuenciaXML**
```

	prefijo : string,
	consecutivo : string,
	numero : string

```

**Estructura de OtrasDeducciones**
```

	otraDeduccion : decimal,
	pensionVoluntaria : decimal,
	retencionFuente : decimal,
	ica : decimal,
	afc : decimal,
	cooperativa : decimal,
	embargoFiscal : decimal,
	planComplementarios : decimal,
	educacion : decimal,
	reintegro : decimal,
	deuda : decimal,
	pagoTercero : decimal,
	anticipo : decimal

```

**Estructura de OtrasDeducciones**
```

	otraDeduccion : decimal,
	pensionVoluntaria : decimal,
	retencionFuente : decimal,
	ica : decimal,
	afc : decimal,
	cooperativa : decimal,
	embargoFiscal : decimal,
	planComplementarios : decimal,
	educacion : decimal,
	reintegro : decimal,
	deuda : decimal,
	pagoTercero : decimal,
	anticipo : decimal

```

**Estructura de OtrosConceptos**
```

	tipo : byte,
	descripcionConcepto : string,
	conceptoS : decimal,
	conceptoNS : decimal

```

**Estructura de OtrosDevengados**
```

	dotacion : byte,
	apoyoSost : string,
	teletrabajo : decimal,
	bonifRetiro : decimal,
	reintegro : byte,
	indemnizacion : string,
	pagoTercero : decimal,
	anticipo : decimal,
	comision : decimal,

```

**Estructura de Pago**
```

	forma : byte,
	metodo : string,
	banco : string,
	tipoCuenta : string,
	numeroCuenta : string

```

**Estructura de Primas**
```

	cantidad : decimal,
	pago : decimal,
	pagoNS : decimal

```

**Estructura de Sanciones**
```

	sancionPublic : decimal,
	sancionPriv : decimal

```

**Estructura de Trabajador**
```

	tipoTrabajador : string,
	subTipoTrabajador : string,
	fechaIngreso : string,
	_fechaRetiro : DateTime,
	fechaRetiro : string,
	tiempoLaborado : string,
	altoRiesgoPension : bool,
	numeroDocumento : string,
	primerApellido : string,
	segundoApellido : string,
	primerNombre : string,
	otrosNombres : string,
	lugarTrabajoPais : string,
	lugarTrabajoMunicipioCiudad : string,
	lugarTrabajoDepartamentoEstado : string,
	lugarTrabajoDireccion : string,
	salarioIntegral : bool,
	tipoContrato : byte,
	sueldo : decimal,
	codigoTrabajador : string,
	email : string,

```

**Estructura de Transporte**
```

	auxilioTransporte : decimal,
	viaticoManuAlojS : decimal,
	viaticoManuAlojNS : decimal,

```
____

**Estructuras de Eventos RADIAN**

**Estructura de BasicStructure**
```

	FromHead : FromHead,
	FromSenderTaxScheme : FromSenderTaxScheme,
	FromSenderParty : IEnumerable<FromSenderParty>,
	FromReceiverTaxScheme : IEnumerable<FromReceiverTaxScheme>,
	FromReceiverParty : IEnumerable<FromReceiverParty>,
	FromIssuerParty : IEnumerable<FromIssuerParty>,
	FromDRIssuerLegalEntity : IEnumerable<FromDRIssuerLegalEntity>,
	FromSenderLegalEntity : IEnumerable<FromSenderLegalEntity>,
	FromReceiverLegalEntity : IEnumerable<FromReceiverLegalEntity>,
	FromCustomTagGeneral : IEnumerable<FromCustomTagGeneral>,
	FromSenderPerson : IEnumerable<FromSenderPerson>,
	FromReceiverPerson : IEnumerable<FromReceiverPerson>,
	FromSenderPAttorney : IEnumerable<FromSenderPAttorney>,
	FromDRIssuerPAttorney : IEnumerable<FromDRIssuerPAttorney>,
	FromDRIssuerPAttorneyPerson : IEnumerable<FromDRIssuerPAttorneyPerson>,
	FromDRIssuerTaxScheme : IEnumerable<FromDRIssuerTaxScheme>,
	FromDocumentReference : IEnumerable<FromDocumentReference>,
	Notes : IEnumerable<FromNote> Notes,
	FromAttachment : IEnumerable<FromAttachment>

```

**Estructura de FromHead**
```

	ID : string,
	IssueDate : DateTime,
	ResponseCode : string,
	ResponseCodeListID : string,
	OperationType_c : string,
	CustomizationSchemeID : string,
	EffectiveDateMandate : DateTime,
	PublicEffectiveDate : DateTime,
	Email : string,
	ConsecutiveTerm : string,
	Attachment : string,
	ValidityNote : string,
	CurrencyCode : string

```

**Estructura de FromSenderTaxScheme**
```

	RegistrationName : string,
	CompanyID : string,
	SenderIDType : string,
	OrganizationIDType : string,
	StockAmount1 : decimal,
	Currency1 : string

```
**Estructura de FromSenderParty**
```

	ID : string,
	RegistrationName : string,
	SenderIDType : string,
	OrganizationIDType : string,
	CompanyLegalFormCode : string,
	StockAmount : decimal,
	SenderMandateType : string

```

**Estructura de FromReceiverParty**
```

	ID : string,
	RegistrationName : string,
	ReceiverIDType : string,
	OrganizationIDType : string,
	CompanyLegalFormCode : string,
	StockAmount : decimal,
	ReceiverMandateType : string

```

**Estructura de FromIssuerParty**
```

	ID : string,
	Name : string,
	IdentificationType : string,
	OrganizationIDType : string,
	StockAmount : decimal

```

**Estructura de FromDRIssuerLegalEntity**
```

	ID : string,
	Name : string,
	IdentificationType : string,
	CompanyType_c : string,
	StockAmount1 : decimal,
	Currency1 : string

```

**Estructura de FromSenderLegalEntity**
```

	ID : string,
	Name : string,
	IdentificationType : string,
	CompanyType_c : string,
	StockAmount1 : decimal,
	Currency1 : string

```

**Estructura de FromReceiverLegalEntity**
```

	LegalFormCode : string,
	ID : string,
	Name : string,
	IdentificationType : string,
	CompanyType_c : string,
	StockAmount1 : decimal,
	Currency1 : string

```

**Estructura de FromCustomTagGeneral**
```

	Name : string,
	Value : string

```

**Estructura de FromDRPerson**
```

	ID : string,
	IssuerIDType : string,
	FirstName : string,
	FamilyName : string,
	JobTitle : string,
	OrganizationDepartment : string,
	Nationality : string

```

**Estructura de FromSenderPerson**
```

	ID : string,
	IdentificationType : string,
	FirstName : string,
	FamilyName : string,
	JobTitle : string,
	Nationality : string,
	OrganizationDepartment : string

```

**Estructura de FromReceiverPerson**
```

	ID : string,
	IdentificationType : string,
	FirstName : string,
	FamilyName : string,
	JobTitle : string,
	Nationality : string,
	OrganizationDepartment : string

```

**Estructura de FromSenderPAttorney**
```

	ID : string,
	IdentificationType : string,
	TipoMandante : string,
	Description : string

```

**Estructura de FromDRIssuerPAttorney**
```

	ID : string,
	IdentificationType : string,
	TipoMandante : string,
	Description : string

```

**Estructura de FromDRIssuerPAttorneyPerson**
```

	ID : string,
	IssuerIDType : string,
	FirstName : string,
	FamilyName : string,
	JobTitle : string,
	OrganizationDepartment : string,
	Nationality : string

```

**Estructura de FromDRIssuerTaxScheme**
```

	ID : string,
	Name : string,
	IdentificationType : string,
	OrganizationIDType : string,
	StockAmount : decimal

```

**Estructura de FromDocumentReference**
```
	LegalNumRef : string,
	CUFERef : string,
	DocumentTypeCodeRef : string,
	StartDate : DateTime,
	EndDate : DateTime,
	DescriptionCode : string,
	Description : string,
	ScopeMandate : decimal
```

**Estructura de FromNote**
```
	Note : string
```

**Estructura de FromAttachment**
```
	ID : string
	DocumentBinary : string
	ResponseDescription : string
	DocumentDescription : string
	EffectiveDate : DateTime
```
