using Microsoft.Azure.Cosmos;
using System;
using System.Threading.Tasks;

namespace MarmolApp
{
    public class CosmosService
    {
        CosmosClient client;
        Database database;
        Container container;

        public string nombredb { get; set; }
        public string namecontainer { get; set; }

        public CosmosService(string url= "https://marmol-app.documents.azure.com:443/", string key= "IUPaiA9a7bbizD4gJutlRVdzb2Hh2a7C2ezZdfr3pvKUjgTB0JPT5dO3yFv5RS3uIu3juFyiSYJENPHHI90FVA==", string nombredb ="MarmolDb", string namecontainer= "MarmolContainer")
        {
            client = new CosmosClient(url,key );
            this.nombredb = nombredb;
            this.namecontainer = namecontainer;
            
        }
        public dynamic GetCliente(string id)
        {
            return GetItem(id,"cliente");
        }
        public async Task<dynamic>  GetItem(string id, string PartitionKey)
        {
            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
                namecontainer,
                "/EntityName",
                400);

            var element = await container.ReadItemAsync<dynamic>(id, new PartitionKey(PartitionKey));
            return element.Resource;
        }
        public async Task<dynamic> CreateCliente(string id, string nombre, int telefono, string EntityName="cliente") 
        {
            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
                namecontainer,
                "/EntityName",
                400);

            dynamic Item = new { id = id, EntityName = EntityName, nombre = nombre, telefono = telefono };
            var createResponse = await container.CreateItemAsync(Item);
            return createResponse;
        }
           
        public async Task<dynamic> DeleteById(string id) 
        {
            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
                namecontainer,
                "/EntityName",
                400);

            var response = await container.DeleteItemAsync<dynamic>(id, new PartitionKey("cliente"));
            return response.Resource;

        }
    }
}
