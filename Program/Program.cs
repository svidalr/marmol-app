﻿using marmol.db.cosmos;
using MarmolApp;
using MarmolApp.Model;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static async Task Main(string[] args)

        {

            /*Creacion de una entidad tipo Cliente*/
            //var cosmosservices = new CosmosService<Cliente>();
            //var item = await cosmosservices.InsertElement(new Cliente { 
            //    Nombre = "alejandro",
            //    Rut = "23.332.443-4",
            //    Celular = 233423432,
            //    EntityName= cosmosservices.EntityName
            //});
            //Console.WriteLine($"Nuevo id: {item}");

            /*Creacion de una entidad tipo Persona*/
            //var cosmosservices = new CosmosService<Persona>();
            //var item = await cosmosservices.InsertElement(new Persona
            //{
            //    Nombre = "Camila",
            //    Rut = "11.334.554-k",
            //    Correo = "camila.vidal@gmail.com",
            //    Celular = 34425511,
            //    EntityName = cosmosservices.EntityName
            //});
            //Console.WriteLine($"Nuevo id: {item}");

            /*Obtener de la bd mediante id y nombre entidad el elemento*/
            //var cosmoss = new CosmosService<Persona>();
            //var response = await cosmoss.GetElementById("c6c357292033417db06e6af89247cc1e", cosmoss.EntityName);
            //Console.WriteLine($"{response.Nombre} - {response.Rut} - {response.Celular}");

            /*Eliminar un elemento, parametros id y nombre de la entidad*/
            //var response  = await cosmoss.DeleteElementById("c6c357292033417db06e6af89247cc1e", cosmoss.EntityName);
            //Console.WriteLine($"Elemento eliminado {response}");

            /*Obtener todos los elementos de tipo Persona*/
            //var cosmos = new CosmosService<Persona>();
            //var lista = await cosmos.GetAllElements(cosmos.EntityName);
            //foreach (var item in lista)
            //{
            //    Console.WriteLine($"Nombre: {item.Nombre} - Rut: {item.Rut} - Cel: {item.Celular} - Correo: {item.Correo}");
            //}




            //var elementomodificado = element.Resource;
            //elementomodificado.details = "cualquiercosa";
            //var response = await container.ReplaceItemAsync(elementomodificado, "nuevoid2",new PartitionKey("MyTestPkValue"));

            //element = await container.ReadItemAsync<dynamic>("nuevoid2", new PartitionKey("MyTestPkValue"));
            //Console.WriteLine(element.Resource.details);

            var cosmosservice = new CosmosService<Persona>();
            var request = await cosmosservice.GetElementById("df274b68e5bf49a79abec61e3b1303ef", cosmosservice.EntityName);
            Console.WriteLine(request);
            request.Nombre = "José";
        

        }
    }
}
