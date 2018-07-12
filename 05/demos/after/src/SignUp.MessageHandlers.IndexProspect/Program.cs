using NATS.Client;
using SignUp.Core.Logging;
using SignUp.MessageHandlers.IndexProspect.Indexer;
using SignUp.Messaging;
using SignUp.Messaging.Messages.Events;
using System.Linq;
using System.Threading;

namespace SignUp.MessageHandlers.IndexProspect
{
    class Program
    {
        private static ManualResetEvent _ResetEvent = new ManualResetEvent(false);

        private const string QUEUE_GROUP = "index-handler";

        static void Main(string[] args)
        {
            Log.Info("Initializing Elasticsearch. url: {0}", Config.ElasticsearchUrl);
            Index.Setup();

            Log.Info("Connecting to message queue url: {0}", Messaging.Config.MessageQueueUrl);
            using (var connection = MessageQueue.CreateConnection())
            {
                var subscription = connection.SubscribeAsync(ViewerSignedUpEvent.MessageSubject, QUEUE_GROUP);
                subscription.MessageHandler += IndexProspect;
                subscription.Start();
                Log.Info("Listening on subject: {0}, queue: {1}", ViewerSignedUpEvent.MessageSubject, QUEUE_GROUP);

                _ResetEvent.WaitOne();
                connection.Close();
            }
        }

        private static void IndexProspect(object sender, MsgHandlerEventArgs e)
        {
            var eventMessage = MessageHelper.FromData<ViewerSignedUpEvent>(e.Message.Data);
            Log.Info("Indexing viewer, signed up at: {0}; event ID: {1}", eventMessage.SignedUpAt, eventMessage.CorrelationId);

            var viewer = new Documents.Viewer
            {
                Country = eventMessage.Viewer.Country.CountryName,
                EmailAddress = eventMessage.Viewer.EmailAddress,
                FullName = $"{eventMessage.Viewer.FirstName} {eventMessage.Viewer.LastName}",
                Role = eventMessage.Viewer.Role.RoleName,
                Interests = eventMessage.Viewer.Interests.Select(x => x.InterestName).ToArray(),
                SignUpDate = eventMessage.SignedUpAt
            };

            Index.CreateDocument(viewer);
            Log.Info("Viewer indexed; event ID: {0}", eventMessage.CorrelationId);
        }
    }
}
