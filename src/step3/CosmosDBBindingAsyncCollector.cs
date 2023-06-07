using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CosmosDBBinding.Step1;

namespace CosmosDBBinding.Step3
{
    public class CosmosDBBindingAsyncCollector : IAsyncCollector<int>
    {
        private CosmosDBBindingContext cosmosContext;
        private CosmosDBAttribute attr;

        public CosmosDBBindingAsyncCollector(CosmosDBBindingContext cosmosContext, CosmosDBAttribute attr)
        {
            this.cosmosContext = cosmosContext;
            this.attr = attr;

        }

        public async Task AddAsync(
            int item,
            CancellationToken cancellationToken = default(CancellationToken))
        {

            Console.WriteLine($"CosmosDBBindingAsyncCollector.AddAsync: {item}");
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }



            // await UpsertDocument(this.cosmosContext, item);
        }

        public Task FlushAsync(CancellationToken cancellationToken = default(CancellationToken))
        {

            Console.WriteLine($"CosmosDBBindingAsyncCollector.FlushAsync");

            // no-op
            return Task.FromResult(0);
        }



        private static async Task UpsertDocument(CosmosDBBindingContext context, int item)
        {

            Console.WriteLine($"CosmosDBBindingAsyncCollector.UpsertDocument: {item}");
            // // DocumentClient does not accept strings directly.
            // object convertedItem = item;
            // if (item is string)
            // {
            //     convertedItem = JObject.Parse(item.ToString());
            // }

            // await context.CosmosClient
            //     .GetContainer(context.ResolvedAttribute.DatabaseName,
            //     context.ResolvedAttribute.ContainerName)
            //     .UpsertItemAsync<T>(item);
        }
    }
}
