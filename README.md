## FiscalIntegrationCo
FiscalIntegrationCo es una librería desarrollada en C# con soporte en .NET Standar en su version 2.0, que permite el envío de documentos nómina electrónica y eventos de RADIAN a la DIAN a través de los servicios ofrecidos por el proveedor tecnológico avalado por 
la DIAN, BTW SAS.
____
**_ANTES DE EMPEZAR_**

Recomendamos validar la documentacion oficial de Microsoft sobre la compatibilidad de **.NET Standard 2.0** con las demas implentaciones de .NET, con el fin de que pueda identificar si la version de destino de su codigo esta soportada.

Documentacion oficial **[.NET Standard 2.0 ](https://learn.microsoft.com/es-es/dotnet/standard/net-standard?tabs=net-standard-2-0)**


____
## USO

La clase **SendDocument** contiene un método único **Send** para el envio de los documentos electrónicos, el cual retorna un objeto del tipo **PetitionResponse** (Modelo incluido en la librería) con el estado del envío del documento.


**NET Framework 4.7.32**
```
//Estructura JSON a enviar con la información del documento.
 string json = @"{}";
```

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

**.NET y .NET Core	2.0**
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

## Modelos usados 

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
{
	success : boolean,
	message : string
	module : string,
	URL : string,
	Tracer : string
	result : object
}
```
____