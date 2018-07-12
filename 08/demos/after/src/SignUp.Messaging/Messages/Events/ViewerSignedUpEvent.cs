using SignUp.Entities;
using System;

namespace SignUp.Messaging.Messages.Events
{
    public class ViewerSignedUpEvent : Message
    {
        public override string Subject { get { return MessageSubject; } }

        public DateTime SignedUpAt { get; set; }

        public Viewer Viewer { get; set; }

        public static string MessageSubject = "events.viewer.signedup";
    }
}
