using System;

namespace SignUp.MessageHandlers.IndexProspect.Documents
{
    public class Viewer
    {
        public string FullName { get; set; }        

        public string EmailAddress { get; set; }

        public string Role { get; set; }

        public string Country { get; set; }

        public string[] Interests { get; set; }

        public DateTime SignUpDate { get; set; }
    }
}
