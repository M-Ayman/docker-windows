using System;
using System.Collections.Generic;

namespace SignUp.Model
{
    public class Config : Core.Config
    {
        public static string DbConnectionString { get { return Get("DB_CONNECTION_STRING"); } }

        public static string DbMaxRetryCount { get { return Get("DB_MAX_RETRY_COUNT"); } }

        public static string DbMaxDelaySeconds { get { return Get("DB_MAX_DELAY_SECONDS"); } }
    }
}