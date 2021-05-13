using marmol.contracts.db;
using MarmolApp.Model;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace marmol.db.cosmos
{
    public class CosmosService<T> : IMarmolRepository<T> where T : EntityBase
    {
        CosmosClient client;
  
        //obtener la metadata de la clase T, el nombre de clase
        public string EntityName { get; set; } = typeof(T).Name;
        public string nombredb { get; set; }
        public string namecontainer { get; set; }

        public CosmosService(string url= "https://marmol-app.documents.azure.com:443/", string key= "IUPaiA9a7bbizD4gJutlRVdzb2Hh2a7C2ezZdfr3pvKUjgTB0JPT5dO3yFv5RS3uIu3juFyiSYJENPHHI90FVA==", string nombredb ="MarmolDb", string namecontainer= "MarmolContainer")
        {
            client = new CosmosClient(url,key);
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
            
            return response;

        }
       
        public Task<IEnumerable<T>> GetAllElements()
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetElementById(string id, string entityname)
        {
            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
                namecontainer,
                "/EntityName",
                400);

            var element = await container.ReadItemAsync<dynamic>(id, new PartitionKey(entityname));

            //var response  = JsonConvert.SerializeObject(element.Resource);
            //var response = element.Resource.Root;
            var response = JObject.Parse((string)element);
            return (T)element;
        }

        public async Task<string> InsertElement(T element)
        {
            //generacion de un id unico "xxxx-xxx-xxx-xxxx", sin los guiones
            element.Id = Guid.NewGuid().ToString("N");

            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
                namecontainer,
                "/EntityName",
                400);
            
            await container.CreateItemAsync(element);
            return element.Id;
        }

        public Task<T> UpdateElement(T element)
        {
            throw new NotImplementedException(); 
        }
    }

}
