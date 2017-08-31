using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Data.Entity.Infrastructure.Interception;

namespace Tracker.DAL
{
    public class TrackerConfiguration : DbConfiguration
    {
        public TrackerConfiguration()
        {
            // Sets the retry policy
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            // Creates Tranisent errors for testing
            DbInterception.Add(new TrackerInterceptorTransientErrors());
            // Logs database activity
            DbInterception.Add(new TrackerIntercepterLogging());
        }
    }
}