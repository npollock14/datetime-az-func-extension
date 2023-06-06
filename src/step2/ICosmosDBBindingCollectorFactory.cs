using System;

namespace CosmosDBBinding.Step2
{
    public interface ICosmosDBBindingCollectorFactory
    {
        string CreateClient(
            string myName);
    }
}
