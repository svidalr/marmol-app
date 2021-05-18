using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using marmol.db.cosmos;
using MarmolApp.Model;

namespace AzureFunction
{
    public static class home
    {
        [FunctionName("home")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //validaciones 
            //reglas 
            //persistencia


            log.LogInformation("C# HTTP trigger function processed a request.");

            //string nombre = req.Query["nombre"];
            //string rut = req.Query["rut"];
            //string celular = req.Query["celular"];
            //string correo = req.Query["correo"];

            string id = req.Query["id"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);

            //nombre = nombre ?? data?.nombre;
            //rut = rut ?? data?.rut;
            //celular = celular ?? data?.celular;
            //correo = correo ?? data?.correo;

            id = id ?? data?.id;

            /*crear cosmos sevice*/
            //var cscliente = new CosmosService<Cliente>();
            //var cli = await cscliente.InsertElement(new Cliente
            //{
            //    Nombre = nombre,
            //    Rut = rut,
            //    Celular = Int32.Parse(celular),
            //    EntityName = cscliente.EntityName
            //});
            //Console.WriteLine($"Nuevo id: {cli}");

            //var cspersona  = new CosmosService<Persona>();
            //var per = await cspersona.InsertElement(new Persona { 
            //    Nombre= nombre,
            //    Rut = rut,
            //    Correo = correo,
            //    EntityName = cspersona.EntityName,
            //    Celular = celular
            //});
            //Console.WriteLine($"Nuevo id: {per}");

            var cscliente = new CosmosService<Cliente>();
            var buscar = await cscliente.GetElementById(id, cscliente.EntityName);


            string responseMessage = string.IsNullOrEmpty(id)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : JsonConvert.SerializeObject(buscar) 
                
                ;

            return new OkObjectResult(responseMessage);
        }
    }
}
