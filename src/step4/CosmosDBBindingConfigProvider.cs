using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using CosmosDBBinding.Step1;
using CosmosDBBinding.Step2;
using CosmosDBBinding.Step3;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.WebJobs.Host.Bindings;
using Microsoft.Azure.WebJobs.Host.Config;
using Microsoft.Extensions.Configuration;

namespace CosmosDBBinding.Step4
{
    [Extension("CosmosDBV3")]
    public class CosmosDBBindingConfigProvider : IExtensionConfigProvider
    {
        private readonly ICosmosDBBindingCollectorFactory cosmosBindingCollectorFactory;


        public CosmosDBBindingConfigProvider(ICosmosDBBindingCollectorFactory cosmosBindingCollectorFactory)
        {
            this.cosmosBindingCollectorFactory = cosmosBindingCollectorFactory;
        }

        public void Initialize(ExtensionConfigContext context)
        {

            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            var rule = context.AddBindingRule<CosmosDBAttribute>();
            rule.BindToInput<string>(new CosmosDBBindingConverter(this));
        }

        internal CosmosDBBindingContext CreateContext(CosmosDBAttribute attribute)
        {
            string client = GetService(attribute.MyName);

            return new CosmosDBBindingContext
            {
                FullString = client,
                ResolvedAttribute = attribute,
            };
        }

        private string GetService(string myName)
        {
            return this.cosmosBindingCollectorFactory.CreateClient(myName);
        }

    }
}
