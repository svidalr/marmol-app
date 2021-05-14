using marmol.contracts.db;
using MarmolApp.Model;
using Microsoft.Azure.Cosmos;
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
        
        public async Task<IEnumerable<T>> GetAllElements(string entityname)
        {
            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
               namecontainer,
               "/EntityName",
               400);

            var query = $"SELECT * FROM c WHERE c.EntityName='{entityname}'";
            QueryDefinition queryDefinition = new QueryDefinition(query);


            FeedIterator<T> queryresult = container.GetItemQueryIterator<T>(queryDefinition);
            List<T> list = new List<T>();

            while (queryresult.HasMoreResults) {
                FeedResponse<T> currentResultSet = await queryresult.ReadNextAsync();
                foreach (T t in currentResultSet)
                {
                    list.Add(t);
                } 
            }
            return list;

        }

        /// <summary>
        /// Busca objeto segun id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityname"></param>
        /// <returns> Retorna el objeto segun entidad </returns>
        public async Task<T> GetElementById(string id, string entityname)
        {
            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
                namecontainer,
                "/EntityName",
                400);
           
            var response = await container.ReadItemAsync<T>(id, new PartitionKey(entityname));
            return response;
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

        public async Task<T> DeleteElementById(string id, string entityname)
        {
            Database database = await client.CreateDatabaseIfNotExistsAsync(nombredb);
            Container container = await database.CreateContainerIfNotExistsAsync(
                namecontainer,
                "/EntityName",
                400);

            var response = await container.DeleteItemAsync<T>(id, new PartitionKey(entityname));
            return response;
        }
    }

}
