using System.Collections.Generic;

namespace SignUp.Entities
{
    public class Interest
    {
        public int InterestId { get; set; }

        public string InterestCode { get; set; }

        public string InterestName { get; set; }

        public bool IsActive { get; set; }
    }
}
