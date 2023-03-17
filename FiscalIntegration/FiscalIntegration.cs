using Fiscal.Library.Core;
using Fiscal.Library.Models.InputModels;
using Fiscal.Library.Models.InputModels.NE;
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
            //Se instancian la clase SendDocument instalada en la libreria
            SendDocument sendDIAN = new SendDocument();

            //Se genera una lista con 2 clases DocumentoNomina
            DocumentoNomina documento = new DocumentoNomina();

            //Se realiza el envio de las nóminas mediante el método Send expuesto por la librería
            PetitionResponse request = await sendDIAN.Send<PetitionResponse>(documento, DocumentType.Nomina);

            //Se captura el PetitionResponse.Result de la petición
            var resultRequest = request?.result;
        }
    }
}
