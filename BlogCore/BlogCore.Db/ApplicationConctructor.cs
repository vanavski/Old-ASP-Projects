using Microsoft.Extensions.Configuration;

namespace BlogCore.Db
{
    public class ApplicationConstructor
    {
        public IConfigurationRoot ConfigurationRoot { get; set; }

        public ApplicationConstructor()
        {
            ConfigurationRoot = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
