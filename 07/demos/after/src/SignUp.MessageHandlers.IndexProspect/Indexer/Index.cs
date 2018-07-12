using Nest;
using SignUp.Core.Logging;
using SignUp.MessageHandlers.IndexProspect.Documents;
using System;

namespace SignUp.MessageHandlers.IndexProspect.Indexer
{
    public class Index
    {
        public static void Setup()
        {
            var node = new Uri(Config.ElasticsearchUrl);
            var settings = new ConnectionSettings(node);
            var client = new ElasticClient(settings);
            client.CreateIndex("viewers");
        }        

        public static void CreateDocument(Viewer viewer)
        {
            try
            {
                var node = new Uri(Config.ElasticsearchUrl);
                var client = new ElasticClient(node);                
                client.Index(viewer, idx => idx.Index("viewers"));
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Index viewer FAILED, email address: {0}", viewer.EmailAddress);
            }
        }
    }
}
