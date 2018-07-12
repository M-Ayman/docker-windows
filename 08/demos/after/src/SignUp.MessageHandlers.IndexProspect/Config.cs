using System;
using System.Collections.Generic;

namespace SignUp.MessageHandlers.IndexProspect
{
    public class Config : Core.Config
    {
        public static string ElasticsearchUrl { get { return Get("ELASTICSEARCH_URL"); } }
    }
}