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
        public async Task<dynamic>  GetItem(string id, string PartitionKey)
        {
            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
                namecontainer,
                "/EntityName",
                400);

            var element = await container.ReadItemAsync<dynamic>(id, new PartitionKey(PartitionKey));
            return element;
        }

        public dynamic GetCliente(string id)
        {
            return GetItem(id,"cliente");
        }
    }
}
