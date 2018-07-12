using NATS.Client;
using Prometheus;
using Prometheus.Advanced;
using SignUp.Core.Logging;
using SignUp.Messaging;
using SignUp.Messaging.Messages.Events;
using SignUp.Model;
using System;
using System.Linq;
using System.Threading;

namespace SignUp.MessageHandlers.SaveProspect
{
    class Program
    {
        private static ManualResetEvent _ResetEvent = new ManualResetEvent(false);

        private const string QUEUE_GROUP = "save-handler";

        private static Counter _EventCounter = Metrics.CreateCounter(
            "SaveHandler_Events", "Event count", "host", "status");
        private static string _Host = Environment.MachineName;

        static void Main(string[] args)
        {
            Log.Info("Initializing Prometheus server");
            var server = new MetricServer(50505, new IOnDemandCollector[] { new DotNetStatsCollector() });
            server.Start();
            Log.Info("Metrics server listening on port 50505");

            Log.Info("Connecting to message queue url: {0}", Config.MessageQueueUrl);
            using (var connection = MessageQueue.CreateConnection())
            {
                var subscription = connection.SubscribeAsync(ViewerSignedUpEvent.MessageSubject, QUEUE_GROUP);
                subscription.MessageHandler += SaveViewer;
                subscription.Start();
                Log.Info("Listening on subject: {0}, queue: {1}", ViewerSignedUpEvent.MessageSubject, QUEUE_GROUP);

                _ResetEvent.WaitOne();
                connection.Close();
            }
        }

        private static void SaveViewer(object sender, MsgHandlerEventArgs e)
        {
            _EventCounter.Labels(_Host, "received").Inc();

            Log.Debug("Received message, subject: {0}", e.Message.Subject);
            var eventMessage = MessageHelper.FromData<ViewerSignedUpEvent>(e.Message.Data);
            Log.Info("Saving new viewer, signed up at: {0}; event ID: {1}", eventMessage.SignedUpAt, eventMessage.CorrelationId);

            var viewer = eventMessage.Viewer;
            try
            {                
                using (var context = new WebinarContext())
                {
                    //reload child objects:
                    viewer.Country = context.Countries.Single(x => x.CountryCode == viewer.Country.CountryCode);
                    viewer.Role = context.Roles.Single(x => x.RoleCode == viewer.Role.RoleCode);
                    var interestCodes = viewer.Interests.Select(y => y.InterestCode);
                    viewer.Interests = context.Interests.Where(x => interestCodes.Contains(x.InterestCode)).ToList();

                    context.Viewers.Add(viewer);
                    context.SaveChanges();
                }
                Log.Info("Viewer saved. Viewer ID: {0}; event ID: {1}", eventMessage.Viewer.ViewerId, eventMessage.CorrelationId);            
                _EventCounter.Labels(_Host, "processed").Inc();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Save viewer FAILED, email address: {0}", viewer.EmailAddress);
                _EventCounter.Labels(_Host, "failed").Inc();
            }
        }
    }
}