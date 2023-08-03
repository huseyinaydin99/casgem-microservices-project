using Casgem_Microservice.Catalog.Settings.Abstracts;

namespace Casgem_Microservice.Catalog.Settings.Concretes
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
    }
}
