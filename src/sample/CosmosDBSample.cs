using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using CosmosDBBinding.Step1;
using System.Threading.Tasks;

namespace CosmosDBBinding.Sample
{
    public static class CosmosDBSample
    {
        [FunctionName("CosmosDBSample")]
        public static async Task Run(
            [TimerTrigger("*/5 * * * * *")] TimerInfo myTimer,
            [Step1.CosmosDB("Nathan")] string resultString,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            log.LogInformation($"Result: {resultString}");

        }
    }

}
