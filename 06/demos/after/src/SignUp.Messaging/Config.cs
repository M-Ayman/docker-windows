using System;
using System.Collections.Generic;

namespace SignUp.Messaging
{
    public class Config : Core.Config
    {
        public static string MessageQueueUrl { get { return Get("MESSAGE_QUEUE_URL"); } }
    }
}