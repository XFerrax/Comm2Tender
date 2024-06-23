using Comm2Tender.Logic.Models;
using LinqToDB.Data;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Comm2Tender.Data
{
    public partial class DataService : IDataService
    {
        IConfiguration Configuration { get; set; }
        public DataService(IConfiguration configuration) 
        {
            Configuration = configuration;
            DataConnection.DefaultSettings = new SqlServerConnectionSettings(Configuration["DataService:ConnectionString"]);
        }

        private Comm2TenderDB GetDatabase(int? commandTimeout = null)
        {
            
            var db = new Comm2TenderDB() { CommandTimeout = Configuration.GetValue<int>("DataService:CommandTimeout") };
            if (commandTimeout != null)
            {
                db.CommandTimeout = commandTimeout.Value;
            }
            return db;
        }
    }
}
