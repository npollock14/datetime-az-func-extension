using CosmosDBBinding.Step1;
using CosmosDBBinding.Step3;
using Microsoft.Azure.WebJobs;

namespace CosmosDBBinding.Step4
{
    public class CosmosDBBindingConverter : IConverter<CosmosDBAttribute, string>
    {
        private readonly CosmosDBBindingConfigProvider configProvider;

        public CosmosDBBindingConverter(CosmosDBBindingConfigProvider configProvider)
        {
            this.configProvider = configProvider;
        }

        public string Convert(CosmosDBAttribute attribute)
        {
            var context = this.configProvider.CreateContext(attribute);
            return context.FullString;
        }
    }
}
