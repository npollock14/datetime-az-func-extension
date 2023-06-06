using System;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;

namespace CosmosDBBinding.Step2
{
    public class CosmosDBBindingCollectorFactory : ICosmosDBBindingCollectorFactory
    {
        public string CreateClient(
            string myName)
        {
            if (string.IsNullOrEmpty(myName))
            {
                throw new ArgumentNullException(nameof(myName));
            }

            string fullString = buildString(myName);

            // print the full string to the console


            return fullString;
        }

        private string buildString(string myName)
        {
            return $"Hello {myName}! The current time is {DateTime.Now}";
        }
    }
}
