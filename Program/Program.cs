using marmol.db.cosmos;
using MarmolApp;
using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static async Task Main(string[] args)

        {
            //var cosmosservices = new CosmosService();
            
            //var item = await cosmosservices.DeleteById("254323");
            //var item = await cosmosservices.CreateCliente("254323", "cristian", 23342343);
            //var item = await cosmosservices.GetCliente("asdasd22");
            //Console.WriteLine(item);


            //CosmosClient client = new CosmosClient("https://marmol-app.documents.azure.com:443/", "IUPaiA9a7bbizD4gJutlRVdzb2Hh2a7C2ezZdfr3pvKUjgTB0JPT5dO3yFv5RS3uIu3juFyiSYJENPHHI90FVA==");
            //Database database = await client.CreateDatabaseIfNotExistsAsync("MarmolDb");
            //Container container = await database.CreateContainerIfNotExistsAsync(
            //    "MarmolContainer",
            //    "/EntityName",
            //    400);

            // Create an item
            //dynamic testItem = new { id = "id43434", EntityName = "cliente", nombre = "Sebastian", telefono = 2323432 };
            //var createResponse = await container.CreateItemAsync(testItem);

            //consultado a cosmos
            //var element = await container.ReadItemAsync<dynamic>("nuevoid2", new PartitionKey( "MyTestPkValue"));
            //Console.WriteLine(element.Resource.details);

            //var elementomodificado = element.Resource;
            //elementomodificado.details = "cualquiercosa";
            //var response = await container.ReplaceItemAsync(elementomodificado, "nuevoid2",new PartitionKey("MyTestPkValue"));

            //element = await container.ReadItemAsync<dynamic>("nuevoid2", new PartitionKey("MyTestPkValue"));
            //Console.WriteLine(element.Resource.details);


            //delete item 
            //var response = await container.DeleteItemAsync<dynamic>("id1234", new PartitionKey("cliente"));
            //Console.WriteLine(response);

        }
    }
}
