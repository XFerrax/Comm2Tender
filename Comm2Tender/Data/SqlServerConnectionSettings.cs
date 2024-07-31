using LinqToDB.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace Comm2Tender.Data
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class SqlServerConnectionSettings : ILinqToDBSettings
    {
        private readonly string ConnectionString;
        public IEnumerable<IDataProviderSettings> DataProviders => Enumerable.Empty<IDataProviderSettings>();
        public string DefaultConfiguration => "PostgreSQL";
        public string DefaultDataProvider => "PostgreSQL";

        public SqlServerConnectionSettings(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "Comm2Tender",
                        ProviderName = "PostgreSQL",
                        ConnectionString = ConnectionString
                    };
            }
        }
    }
}
