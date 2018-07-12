using SignUp.Core.Logging;
using System;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace SignUp.Model
{
    public class WebinarContextConfiguration : DbConfiguration
    {
        public WebinarContextConfiguration()
        {
            int maxRetryCount = int.TryParse(Config.DbMaxRetryCount, out maxRetryCount) ? maxRetryCount : 5;
            int maxDelaySeconds = int.TryParse(Config.DbMaxDelaySeconds, out maxDelaySeconds) ? maxDelaySeconds : 30;

            Log.Info("- Setting DbConfiguration - maxRetryCount: {0}, maxDelaySeconds: {1}", maxRetryCount, maxDelaySeconds);

            SetExecutionStrategy("System.Data.SqlClient", () =>
                new SqlAzureExecutionStrategy(maxRetryCount, TimeSpan.FromSeconds(maxDelaySeconds)));
        }
    }
}
