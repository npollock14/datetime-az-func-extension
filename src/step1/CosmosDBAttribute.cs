using System;
using Microsoft.Azure.WebJobs.Description;

namespace CosmosDBBinding.Step1
{
    [AttributeUsage(AttributeTargets.Parameter)]
    [Binding]
    public class CosmosDBAttribute : Attribute
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public CosmosDBAttribute()
        {
        }

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="myName">The User's name.</param>
        public CosmosDBAttribute(string myName)
        {
            MyName = myName;
        }

        /// <summary>
        /// Gets or sets the User's name.
        /// </summary>
        [AutoResolve]
        public string MyName { get; set; }

    }
}
