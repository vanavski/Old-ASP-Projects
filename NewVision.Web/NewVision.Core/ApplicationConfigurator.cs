using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace NewVision.Core
{
    public class ApplicationConfigurator
    {
        public IConfigurationRoot Root { get; set; }

        public ApplicationConfigurator()
        {
            Root = new ConfigurationBuilder()
                .AddJsonFile("appconfig.json")
                .Build();
        }
    }
}
